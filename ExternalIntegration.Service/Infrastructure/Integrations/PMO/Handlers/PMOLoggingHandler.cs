using ExternalIntegration.Service.Infrastructure.Logging.Abstractions;
using ExternalIntegration.Service.Infrastructure.Logging.Abstractions.Models;
using System.Diagnostics;
using System.Text;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Handlers
{
    public sealed class PMOLoggingHandler : DelegatingHandler
    {
        private readonly IIntegrationActivityLogger _activityLogger;
        private readonly ILogger<PMOLoggingHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PMOLoggingHandler(
            IIntegrationActivityLogger activityLogger,
            ILogger<PMOLoggingHandler> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _activityLogger = activityLogger;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var startedAtUtc = DateTime.UtcNow;
            var stopwatch = Stopwatch.StartNew();

            var requestBody = await ReadRequestBodyAsync(request, cancellationToken);

            HttpResponseMessage? response = null;
            string? responseBody = null;
            string? errorMessage = null;
            int? statusCode = null;
            var isSuccess = false;

            try
            {
                response = await base.SendAsync(request, cancellationToken);
                statusCode = (int)response.StatusCode;
                isSuccess = response.IsSuccessStatusCode;
                responseBody = await ReadAndRestoreResponseBodyAsync(response, cancellationToken);

                return response;
            }
            catch (Exception ex)
            {
                errorMessage = ex.ToString();
                _logger.LogError(ex, "External HTTP call failed: {Method} {Url}", request.Method.Method, request.RequestUri);
                throw;
            }
            finally
            {
                stopwatch.Stop();

                var entry = new PMOLogEntry
                {
                    SystemName = ResolveSystemName(request),
                    OperationName = ResolveOperationName(request),
                    HttpMethod = request.Method.Method,
                    Url = request.RequestUri?.ToString() ?? string.Empty,
                    RequestBody = requestBody,
                    ResponseBody = responseBody,
                    StatusCode = statusCode,
                    IsSuccess = isSuccess,
                    ErrorMessage = errorMessage,
                    DurationMs = stopwatch.ElapsedMilliseconds,
                    CorrelationId = ResolveCorrelationId(),
                    CreatedAtUtc = startedAtUtc
                };

                await _activityLogger.LogAsync(entry, CancellationToken.None);
            }
        }

        private string? ResolveCorrelationId()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext is null)
            {
                return null;
            }

            if (httpContext.Request.Headers.TryGetValue("X-Correlation-Id", out var correlationId) &&
                !string.IsNullOrWhiteSpace(correlationId))
            {
                return correlationId.ToString();
            }

            return httpContext.TraceIdentifier;
        }

        private static string ResolveSystemName(HttpRequestMessage request)
        {
            if (request.Options.TryGetValue(new HttpRequestOptionsKey<string>("SystemName"), out var systemName) &&
                !string.IsNullOrWhiteSpace(systemName))
            {
                return systemName;
            }

            return request.RequestUri?.Host ?? "ExternalSystem";
        }

        private static string ResolveOperationName(HttpRequestMessage request)
        {
            if (request.Options.TryGetValue(new HttpRequestOptionsKey<string>("OperationName"), out var operationName) &&
                !string.IsNullOrWhiteSpace(operationName))
            {
                return operationName;
            }

            return request.RequestUri?.AbsolutePath ?? "UnknownOperation";
        }

        private static async Task<string?> ReadRequestBodyAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request.Content is null)
            {
                return null;
            }

            return await request.Content.ReadAsStringAsync(cancellationToken);
        }

        private static async Task<string?> ReadAndRestoreResponseBodyAsync(
            HttpResponseMessage response,
            CancellationToken cancellationToken)
        {
            if (response.Content is null)
            {
                return null;
            }

            var contentType = response.Content.Headers.ContentType;
            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            var restoredContent = new StringContent(content, Encoding.UTF8);
            if (contentType is not null)
            {
                restoredContent.Headers.ContentType = contentType;
            }

            foreach (var header in response.Content.Headers)
            {
                if (string.Equals(header.Key, "Content-Type", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                restoredContent.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            response.Content = restoredContent;
            return content;
        }
        
    }
}

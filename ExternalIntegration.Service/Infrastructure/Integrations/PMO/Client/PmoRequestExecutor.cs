using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Auth;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Client
{
    public class PmoRequestExecutor : IPmoRequestExecutor
    {
        private readonly HttpClient _httpClient;
        private readonly PmoAuthService _pmoAuthService;
        //private readonly ILogger<PmoRequestExecutor> _logger;
        private readonly string _baseAddress;

        public PmoRequestExecutor(
            HttpClient httpClient,
            //ILogger<PmoRequestExecutor> logger,
            PmoAuthService pmoAuthService,
            IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _pmoAuthService = pmoAuthService ?? throw new ArgumentNullException(nameof(pmoAuthService));

            _baseAddress = configuration["ServiceProviderConfig:PMO:BaseAddress"]
                ?? throw new InvalidOperationException("PMO base address is not configured. (ServiceProviderConfig:PMO:BaseAddress)");
        }

        public async Task<Response<T>> PostAsync<T>(object requestData, string terminalCode = "", CancellationToken cancellationToken = default)
        {
            var request = await BuildHttpRequestAsync(requestData, terminalCode, cancellationToken);
            request.Options.Set(new HttpRequestOptionsKey<string>("SystemName"), "PMO");
            request.Options.Set(new HttpRequestOptionsKey<string>("OperationName"), GetServiceName(requestData));

            var responseString = await SendAsync(request, cancellationToken);

            var envelope = DeserializeEnvelope(responseString);

            return HandleEnvelope<T>(envelope);
        }

        private async Task<HttpRequestMessage> BuildHttpRequestAsync(object requestData, string terminalCode, CancellationToken cancellationToken)
        {
            var json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, _baseAddress)
            {
                Content = content
            };

            var token = await _pmoAuthService.GetTokenAsync(terminalCode, cancellationToken);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return request;
        }

        private async Task<string> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            using var response = await _httpClient.SendAsync(request, cancellationToken);

            var responseString = await response.Content.ReadAsStringAsync(cancellationToken);

            //if (!response.IsSuccessStatusCode)           
            //_logger.LogError("PMO returned non-success HTTP status code: {Status}. Body: {Body}", response.StatusCode, responseString);

            return responseString;
        }

        private PmoGeneralResponseDto DeserializeEnvelope(string responseString)
        {
            var envelope = JsonConvert.DeserializeObject<PmoGeneralResponseDto>(responseString);

            if (envelope == null)
                throw new InvalidOperationException("Invalid PMO response envelope");

            return envelope;
        }

        private Response<T> HandleEnvelope<T>(PmoGeneralResponseDto envelope)
        {
            if (envelope.ResponseStatusCode == (int)HttpStatusCode.OK && envelope.IsSuccessful)
            {
                var data = JsonConvert.DeserializeObject<T>(envelope.ResponseText!);
                return Response<T>.Success(data);
            }

            //_logger.LogError("PMO error: {Message}", envelope.ResponseText);
            return Response<T>.Error(envelope.ResponseText!);
        }

        private string GetServiceName(object requestData)
        {
            dynamic data = requestData;
            if (data != null)
                return data.Service;

            return string.Empty;


        }

    }
}

using ExternalIntegration.Service.Infrastructure.Logging.Abstractions;
using ExternalIntegration.Service.Infrastructure.Logging.Abstractions.Models;
using ExternalIntegration.Service.Infrastructure.Logging.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;

namespace ExternalIntegration.Service.Infrastructure.Logging.Services
{
    public class IntegrationActivityLogger : IIntegrationActivityLogger
    {
        private readonly GatewayDbContext _dbContext;

        public IntegrationActivityLogger(GatewayDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task LogAsync(PMOLogEntry entry, CancellationToken cancellationToken = default)
        {
            var entity = new PMOLog
            {
                SystemName = entry.SystemName,
                OperationName = entry.OperationName,
                HttpMethod = entry.HttpMethod,
                Url = entry.Url,
                RequestBody = entry.RequestBody,
                ResponseBody = entry.ResponseBody,
                StatusCode = entry.StatusCode,
                IsSuccess = entry.IsSuccess,
                ErrorMessage = entry.ErrorMessage,
                DurationMs = entry.DurationMs,
                CorrelationId = entry.CorrelationId,
                CreatedAtUtc = entry.CreatedAtUtc
            };

            _dbContext.Set<PMOLog>().Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Repositories
{
    public class VesselLoadingListRepository : Repository<VesselLoadingList>, IVesselLoadingListRepository
    {
        public VesselLoadingListRepository(GatewayDbContext context) : base(context)
        {
        }

        public async Task<VesselLoadingList?> GetByPermitIdAsync(
            Guid permitId,
            CancellationToken cancellationToken = default)
        {
            var permitIdText = permitId.ToString();
            var candidates = await _dbSet
                .AsNoTracking()
                .Where(loadingList => loadingList.Permits.Contains(permitIdText))
                .ToListAsync(cancellationToken);

            return candidates
                .Where(loadingList => ContainsPermit(loadingList.Permits, permitId))
                .OrderByDescending(x => x.CreationDate)
                .FirstOrDefault();
        }

        private static bool ContainsPermit(string permitsJson, Guid permitId)
        {
            using var document = JsonDocument.Parse(permitsJson);
            return document.RootElement
                .EnumerateArray()
                .Any(permit => permit.EnumerateObject().Any(property =>
                    string.Equals(property.Name, "LoadingPermitId", StringComparison.OrdinalIgnoreCase)
                    && Guid.TryParse(property.Value.GetString(), out var loadingPermitId)
                    && loadingPermitId == permitId));
        }
    }
}

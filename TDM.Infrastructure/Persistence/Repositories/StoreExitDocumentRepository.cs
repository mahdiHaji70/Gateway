using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class StoreExitDocumentRepository : Repository<StoreExitDocument>, IStoreExitDocumentRepository
    {
        public StoreExitDocumentRepository(TDMDbContext context) : base(context) { }

        public Task<StoreExitDocument?> GetForVesselLoadingAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _dbSet
                .Include(x => x.Voyage)
                .Include(x => x.StoreReceiptOperations).ThenInclude(x => x.StoreReceiptHead).ThenInclude(x => x.Declaration)
                .Include(x => x.StoreReceiptOperations).ThenInclude(x => x.StoreReceiptContainer).ThenInclude(x => x!.Container)
                .Include(x => x.StoreReceiptOperations).ThenInclude(x => x.Store)
                .Include(x => x.StoreReceiptOperations).ThenInclude(x => x.StoreReceiptGood).ThenInclude(x => x!.Commodity)
                .Include(x => x.StoreReceiptOperations).ThenInclude(x => x.StoreReceiptGood).ThenInclude(x => x!.Package)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<StoreExitDocument?> GetForSeaDeliveryAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _dbSet
                .Include(x => x.StoreReceiptOperations).ThenInclude(x => x.StoreReceiptHead).ThenInclude(x => x.ManifestItem)
                .Include(x => x.StoreReceiptOperations).ThenInclude(x => x.StoreReceiptContainer).ThenInclude(x => x!.Container)
                .Include(x => x.StoreReceiptOperations).ThenInclude(x => x.Store)
                .Include(x => x.StoreReceiptOperations).ThenInclude(x => x.StoreReceiptGood).ThenInclude(x => x!.Commodity)
                .Include(x => x.StoreReceiptOperations).ThenInclude(x => x.StoreReceiptGood).ThenInclude(x => x!.Package)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<StoreExitDocument?> GetForLandDeliveryAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _dbSet
                .Include(x => x.StoreReceiptOperations).ThenInclude(x => x.StoreReceiptHead).ThenInclude(x => x.Declaration)
                .Include(x => x.StoreReceiptOperations).ThenInclude(x => x.StoreReceiptContainer).ThenInclude(x => x!.Container)
                .Include(x => x.StoreReceiptOperations).ThenInclude(x => x.Store)
                .Include(x => x.StoreReceiptOperations).ThenInclude(x => x.StoreReceiptGood).ThenInclude(x => x!.Commodity)
                .Include(x => x.StoreReceiptOperations).ThenInclude(x => x.StoreReceiptGood).ThenInclude(x => x!.Package)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}

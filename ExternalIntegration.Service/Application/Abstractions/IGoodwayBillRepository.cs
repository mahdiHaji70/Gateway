using ExternalIntegration.Service.Domain.Entities;

namespace ExternalIntegration.Service.Application.Abstractions
{
 
        public interface IGoodwayBillRepository : IRepository<GoodwayBill>
        {
            Task<List<GoodwayBill?>> GetByStorageAgreementIdAsync(Guid storageAgreementId);
       
    }
}

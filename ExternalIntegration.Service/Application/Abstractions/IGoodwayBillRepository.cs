using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Application.Abstractions
{
 
        public interface IGoodwayBillRepository : IRepository<GoodwayBill>
        {
            Task<List<GoodwayBill?>> GetByStorageAgreementIdAsync(GetGoodwayBillDto dto);
       
    }
}

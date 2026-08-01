using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExternalIntegration.Service.Application.Abstractions
{

    public interface IStoreReceiptRepository : IRepository<StoreReceipt>
    {
      
        Task<DateTime> GetLastDateAsync(string terminalCode);
        Task<List<StoreReceipt>> GetByStorageAgreementNoAsync(string storageAgreementNo);
        Task<StoreReceipt> GetByNoAsync(string no);
    }
}

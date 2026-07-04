using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExternalIntegration.Service.Application.Abstractions
{

    public interface IGoodwayBillRepository : IRepository<GoodwayBill>
    {
        Task<List<GoodwayBill>> GetByStorageAgreementIdAsync(Guid storageAgreementId, string terminalCode);

        Task<DateTime> GetLastDateAsync();

    }
}

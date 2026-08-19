using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExternalIntegration.Service.Application.Abstractions
{

    public interface IIssueRequestRepository : IRepository<IssueRequest>
    {

        Task<DateTime> GetLastDateAsync(string terminalCode);
        Task<List<IssueRequest>> GetByStorageAgreementNoAsync(string storageAgreementNo);
        void UpdateIssueRequestApprovalAsync(Guid requestId, bool IsApproved);
        Task<List<IssueRequest>> GetByIdNoAsync(Guid id);

    }
}

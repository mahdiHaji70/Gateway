using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExternalIntegration.Service.Application.Abstractions
{

    public interface IIssueRequestRepository : IRepository<IssueRequest>
    {

        Task<DateTime> GetLastDateAsync(string terminalCode);
        Task<List<IssueRequest>> GetByStorageAgreementNoAsync(string storageAgreementNo);
        Task UpdateIssueRequestApprovalAsync(Guid requestId, bool isApproved);
        Task<IssueRequest?> GetByRequestIdAsync(Guid requestId, CancellationToken cancellationToken = default);
        Task<List<IssueRequest>> GetByIdNoAsync(Guid id);

    }
}

using System;
using TDM.Application.Common.Models;
using TDM.Application.Doc.Manifests.DTOs;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IManifestRepository : IRepository<Manifest>
    {
        Task<bool> ExistsByNoticeNo(string noticeNo);
        Task<PagedResult<ManifestListDto>> GetPagedManifests(int pageNumber, int pageSize, string terminalCode);
        Task<List<ManifestItemLookupDto>> GetManifestItemsLookup(string terminalCode, CancellationToken cancellationToken = default);
        Task<ManifestItem?> GetManifestItemById(Guid itemId, CancellationToken cancellationToken = default);
    }
}

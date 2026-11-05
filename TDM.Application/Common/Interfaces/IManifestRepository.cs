using System;
using TDM.Application.Common.Models;
using TDM.Application.Doc.Manifests.DTOs;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IManifestRepository : IRepository<Manifest>
    {
        Task<bool> ExistsByNoticeNo(string noticeNo);
        Task<PagedResult<ManifestListDto>> GetPagedManifests(
            int pageNumber, int pageSize, string terminalCode, string? search, DateTime? dateFrom, DateTime? dateTo,
            Guid? trafficId, Guid? consigneeId, Guid? cargoTypeId, Guid? commodityId, Guid? packageId);
        Task<List<ManifestItemLookupDto>> GetManifestItemsLookup(string terminalCode, string? search, CancellationToken cancellationToken = default);
        Task<ManifestItem?> GetManifestItemById(Guid itemId, CancellationToken cancellationToken = default);
    }
}

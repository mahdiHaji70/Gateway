using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Models;
using TDM.Application.Operation.VesselDischarges.DTOs;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IVesselDischargeRepository : IRepository<VesselDischarge>
    {
        Task<PagedResult<VesselDischarge>?> GetPagedFilteredAsync(
            int pageNumber, int pageSize, string? search, DateTime? dateFrom, DateTime? dateTo,
            Guid? manifestItemId, Guid? storeId, Guid? containerId);
        public Task<List<VesselDischarge>> GetUnsentVesselDischargesToIpasAsync(Guid manifestItemId);
        public Task<List<VesselDischarge>> GetByManifestItemIdAsync(Guid manifestItemId, CancellationToken cancellationToken = default);
        public Task<bool> ExistsByManifestContainerIdAsync(Guid manifestContainerId, CancellationToken cancellationToken = default);
        public Task<List<GroupedVesselDischargeDto>> GetGroupedAsync(
            Guid manifestItemId,
            CancellationToken cancellationToken = default);
    }
}

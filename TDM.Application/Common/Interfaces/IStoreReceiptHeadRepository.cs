using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IStoreReceiptHeadRepository:IRepository<StoreReceiptHead>
    {
        Task<PagedResult<StoreReceiptHead>?> GetPagedFilteredAsync(
            int pageNumber, int pageSize, string? search, DateTime? dateFrom, DateTime? dateTo,
            Guid? consigneeId, Guid? consigneeRepId, Guid? trafficId, Guid? cargoTypeId, string? arrivalTypeCode);
        Task<StoreReceiptHead?> GetForAllocationAsync(Guid id);
    }
}

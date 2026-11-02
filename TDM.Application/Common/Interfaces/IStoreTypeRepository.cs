using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IStoreTypeRepository : IRepository<StoreType>
    {
        Task<PagedResult<StoreType>?> GetPagedAsync(int pageNumber, int pageSize, string? search);
    }

}

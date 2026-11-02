using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IStoreRepository : IRepository<Store>
    {
        Task<PagedResult<Store>?> GetPagedAsync(int pageNumber, int pageSize, string? search);
    }
}

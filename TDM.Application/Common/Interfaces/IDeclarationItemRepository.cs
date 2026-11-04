using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IDeclarationItemRepository : IRepository<DeclarationItem>
    {
        Task<PagedResult<DeclarationItem>?> GetLookupAsync(string? search, int pageNumber, int pageSize);
        Task<IEnumerable<DeclarationItem>> GetByDeclarationId(Guid declarationId);
        Task<bool> ExistsByDeclarationId(Guid declarationId);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IDeclarationItemRepository : IRepository<DeclarationItem>
    {
        Task<IEnumerable<DeclarationItem>> GetByDeclarationId(Guid declarationId);
        Task<bool> ExistsByDeclarationId(Guid declarationId);
    }
}

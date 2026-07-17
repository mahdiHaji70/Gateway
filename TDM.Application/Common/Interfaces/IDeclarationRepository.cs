using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IDeclarationRepository : IRepository<Declaration>
    {

        bool ExistsByIpasDeclarationNo(string IpasDeclarationNo);
        Task<Declaration?> GetByIpasDeclarationNoAsync(string ipasDeclarationNo);
    }
}

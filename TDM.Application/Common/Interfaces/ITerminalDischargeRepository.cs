using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface ITerminalDischargeRepository : IRepository<TerminalDischarge>
    {
        public Task<List<TerminalDischarge>?> GetByDeclarationIdAsync(Guid id);
        public Task<List<TerminalDischarge>> GetPendingIpasSubmissionByDeclarationIdAsync(Guid declarationId);
        public Task<PagedResult<TerminalDischarge>?> GetTerminalDischargesByDeclarationIdPagedAsync(
            Guid declarationId, int pageNumber, int pageSize);


    }
}

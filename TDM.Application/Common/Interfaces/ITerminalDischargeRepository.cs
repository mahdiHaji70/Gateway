using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface ITerminalDischargeRepository : IRepository<TerminalDischarge>
    {
        public Task<TerminalDischarge?> GetByDeclarationIdAsync(Guid id);
        public Task<List<TerminalDischarge>> GetPendingIpasSubmissionByDeclarationIdAsync(Guid declarationId);
    }
}

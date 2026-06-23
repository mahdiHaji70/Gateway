using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IUserTerminalRepository : IRepository<UserTerminal>
    {
        Task<bool> ExistsByNationalId(string nationalId);
        Task<UserTerminal?> GetByNationalId(string nationalId);
    }
}
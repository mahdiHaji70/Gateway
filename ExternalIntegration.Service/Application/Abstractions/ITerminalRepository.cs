using ExternalIntegration.Service.Domain.Entities;

namespace ExternalIntegration.Service.Application.Abstractions
{
    public interface ITerminalRepository : IRepository<Terminal>
    {
        Task<Terminal?> GetByCodeAsync(string code); 
    }
}

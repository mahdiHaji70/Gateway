using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;

namespace ExternalIntegration.Service.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GatewayDbContext _context;

        public UnitOfWork(GatewayDbContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => _context.SaveChangesAsync(cancellationToken);
    }
}

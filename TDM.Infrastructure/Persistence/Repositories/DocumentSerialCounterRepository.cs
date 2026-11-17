using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;
using TDM.Domain.Enums;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class DocumentSerialCounterRepository : IDocumentSerialCounterRepository
    {
        private readonly DbSet<DocumentSerialCounter> _counters;

        public DocumentSerialCounterRepository(TDMDbContext context)
        {
            _counters = context.Set<DocumentSerialCounter>();
        }

        public async Task<long> GetNextCounterAsync(
            DocumentSerialType serialType,
            string terminalCode,
            int jalaliYear,
            CancellationToken cancellationToken)
        {
            var counter = await _counters.SingleOrDefaultAsync(
                x => x.SerialType == serialType
                    && x.TerminalCode == terminalCode
                    && x.JalaliYear == jalaliYear,
                cancellationToken);

            if (counter == null)
            {
                counter = new DocumentSerialCounter(serialType, terminalCode, jalaliYear);
                await _counters.AddAsync(counter, cancellationToken);
                return counter.LastCounter;
            }

            return counter.Increment();
        }
    }
}

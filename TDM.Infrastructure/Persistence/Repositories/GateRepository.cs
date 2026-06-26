

using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class GateRepository : Repository<Gate>, IGateRepository
    {
        public GateRepository(TDMDbContext context) : base(context)
        {
        }
              
    }
}



using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class CargoTypeRepository : Repository<CargoType>, ICargoTypeRepository
    {
        public CargoTypeRepository(TDMDbContext context) : base(context)
        {
        }
              
    }
}

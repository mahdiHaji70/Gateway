using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class StoreTypeRepository : Repository<StoreType>, IStoreTypeRepository
    {
        public StoreTypeRepository(TDMDbContext context) : base(context)
        {
        }

    }
}

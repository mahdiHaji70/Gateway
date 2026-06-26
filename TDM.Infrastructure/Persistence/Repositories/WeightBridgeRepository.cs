using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
   
    public class WeightBridgeRepository : Repository<WeightBridge>, IWeightBridgeRepository
    {
        public WeightBridgeRepository(TDMDbContext context) : base(context)
        {
        }

    }
}

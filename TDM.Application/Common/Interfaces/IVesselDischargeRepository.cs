using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IVesselDischargeRepository : IRepository<VesselDischarge>
    {
        public Task<List<VesselDischarge>> GetUnsentVesselDischargesToIpasAsync(Guid manifestItemId);
    }
}

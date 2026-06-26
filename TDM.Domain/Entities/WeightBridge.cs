using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class WeightBridge : BaseEntity
    {
        public Guid DeclarationId { get; set; }
        public Declaration Declaration { get; set; }
        public Guid GateId { get; set; }
        public string Vehicle { get; set; }
        public Decimal? GrossWeight { get; set; }
        public Decimal? TareWeight { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public WeightBridge(Guid declarationId, Guid gateId, string vehicle,
      decimal? grossWeight, decimal? tareWeight, DateTime? startDate, DateTime? endDate)
      => SetProperty(declarationId, gateId, vehicle, grossWeight, tareWeight, startDate, endDate);

        public void Update(Guid declarationId, Guid gateId, string vehicle,
            decimal? grossWeight, decimal? tareWeight, DateTime? startDate, DateTime? endDate)
            => SetProperty(declarationId, gateId, vehicle, grossWeight, tareWeight, startDate, endDate);

        private void SetProperty(Guid declarationId, Guid gateId, string vehicle,
            decimal? grossWeight, decimal? tareWeight, DateTime? startDate, DateTime? endDate)
        {
            DeclarationId = declarationId;
            GateId = gateId;
            Vehicle = vehicle;
            GrossWeight = grossWeight;
            TareWeight = tareWeight;
            StartDate = startDate;
            EndDate = endDate;
        }
        private void Validate(Guid declarationId, Guid gateId, string vehicle, DateTime? startDate, DateTime? endDate)
        {
            if (declarationId == Guid.Empty)
                throw new DomainValidationException("declarationId is required.");

            if (gateId == Guid.Empty)
                throw new DomainValidationException("gateId is required.");

            if (string.IsNullOrWhiteSpace(vehicle))
                throw new DomainValidationException("vehicle is required.");

            if (startDate.HasValue && endDate.HasValue && startDate.Value > endDate.Value)
                throw new DomainValidationException("startdate cannot be greater than enddate.");
        }


    }
}

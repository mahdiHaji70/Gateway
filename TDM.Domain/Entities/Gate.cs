using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Linq;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class Gate : BaseEntity
    {

        public Guid DeclarationId { get; set; }
        public Declaration Declaration { get; set; }
        public string Vehicle { get; set; }
        public Guid? ContainerId { get; set; }
        public DateTime? EnterDate { get; set; }
        public DateTime? ExitDate { get; set; }


        public Gate(Guid id, Guid declarationId, string vehicle,
      Guid containerId, DateTime enterDate, DateTime exitDate)
      => SetProperty(id, declarationId, vehicle, containerId, enterDate, exitDate);

        public void Update(Guid id, Guid declarationId, string vehicle,
      Guid containerId, DateTime enterDate, DateTime exitDate)
      => SetProperty(id, declarationId, vehicle, containerId, enterDate, exitDate);


        private void SetProperty(Guid id, Guid declarationId, string vehicle, Guid containerId,
            DateTime enterDate, DateTime exitDate)
        {
            Id = id;
            DeclarationId = declarationId;
            Vehicle = vehicle;
            ContainerId = containerId;
            EnterDate = enterDate;
            ExitDate = exitDate;
            EnterDate = enterDate;
            ExitDate = exitDate;
        }

        private void Validate(Guid declarationId, string vehicle, DateTime? startDate, DateTime? endDate)
        {
            if (declarationId == Guid.Empty)
                throw new DomainValidationException("DeclarationId is required.");

            if (string.IsNullOrWhiteSpace(vehicle))
                throw new DomainValidationException("Vehicle is required.");

            if (startDate.HasValue && endDate.HasValue && startDate.Value > endDate.Value)
                throw new DomainValidationException("StartDate cannot be greater than EndDate.");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class CargoType : BaseEntity
    {
        public string Name { get; private set; }
        public ICollection<TerminalDischarge> CargoTypeTerminalDischarges { get; private set; } = new List<TerminalDischarge>();

        public CargoType(string name) => SetProperty(name);

        public void Update(string name) => SetProperty(name);

        private void SetProperty(string name)
        {
            Validate(name);
            this.Name = name;
        }
        private void Validate(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainValidationException("Name is required.");
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
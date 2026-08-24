using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }
        public Guid StoreTypeId { get; set; }
        public StoreType StoreType { get; set; } = null!;
        public ICollection<TerminalDischarge> StoreTerminalDischarges { get; private set; } = new List<TerminalDischarge>();
        public ICollection<VesselDischarge> StoreVesselDischarges { get; private set; } = new List<VesselDischarge>();

        public Store(string name, Guid storeTypeId) => SetProperty(name, storeTypeId);

        public void Update(string name, Guid storeTypeId) => SetProperty(name,storeTypeId);

        private void SetProperty(string name, Guid storeTypeId)
        {
            Validate(name,  storeTypeId);
            Name = name;
            StoreTypeId= storeTypeId;
        }
        private void Validate(string name, Guid storeTypeId)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainValidationException("Name is required.");

            if (storeTypeId == Guid.Empty)
                throw new DomainValidationException("StoreType Id is required.");
        }

    }
}

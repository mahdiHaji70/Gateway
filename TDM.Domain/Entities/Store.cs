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
        public string Code { get; private set; }
        public Guid StoreTypeId { get; set; }
        public StoreType StoreType { get; set; } = null!;
        public ICollection<TerminalDischarge> StoreTerminalDischarges { get; private set; } = new List<TerminalDischarge>();
        public ICollection<VesselDischarge> StoreVesselDischarges { get; private set; } = new List<VesselDischarge>();

        public Store(string name, string code, Guid storeTypeId) => SetProperty(name, code, storeTypeId);

        public void Update(string name, string code, Guid storeTypeId) => SetProperty(name, code, storeTypeId);

        private void SetProperty(string name, string code, Guid storeTypeId)
        {
            Validate(name, code, storeTypeId);
            Name = name;
            Code = code;
            StoreTypeId = storeTypeId;
        }
        private void Validate(string name, string code, Guid storeTypeId)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainValidationException("Name is required.");

            if (string.IsNullOrEmpty(code))
                throw new DomainValidationException("Code is required.");

            if (storeTypeId == Guid.Empty)
                throw new DomainValidationException("StoreType Id is required.");
        }

    }
}

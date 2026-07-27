using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class StoreReceiptContainer : BaseEntity
    {
        public Guid StoreReceiptHeadId { get; set; }
        public StoreReceiptHead StoreReceiptHead { get; set; }
        public Guid ContainerId { get; set; }
        public Container Container { get; set; }
        public string SealNumber { get; set; }
        public string  Remark { get; set; }
        public string DangerousCode { get; set; }
        public string Classification { get; set; }
        public decimal IgnitionTemperature { get; set; }
        public string IgnitionTemperatureUnit { get; set; }
      
        public ICollection<StoreReceiptContainerGood> StoreReceiptContainerGoods { get; private set; } = new List<StoreReceiptContainerGood>();
        protected StoreReceiptContainer()
        {
        }

        public StoreReceiptContainer(
            Guid storeReceiptHeadId,
            Guid containerId,
            string sealNumber,
            string remark,
            string dangerousCode,
            string classification,
            decimal ignitionTemperature,
            string ignitionTemperatureUnit)
        {
            SetProperty(
                storeReceiptHeadId,
                containerId,
                sealNumber,
                remark,
                dangerousCode,
                classification,
                ignitionTemperature,
                ignitionTemperatureUnit);
        }

        public void Update(
            Guid storeReceiptHeadId,
            Guid containerId,
            string sealNumber,
            string remark,
            string dangerousCode,
            string classification,
            decimal ignitionTemperature,
            string ignitionTemperatureUnit)
        {
            SetProperty(
                storeReceiptHeadId,
                containerId,
                sealNumber,
                remark,
                dangerousCode,
                classification,
                ignitionTemperature,
                ignitionTemperatureUnit);
        }

        private void SetProperty(
            Guid storeReceiptHeadId,
            Guid containerId,
            string sealNumber,
            string remark,
            string dangerousCode,
            string classification,
            decimal ignitionTemperature,
            string ignitionTemperatureUnit)
        {
            Validate(
                storeReceiptHeadId,
                containerId,
                sealNumber,
                ignitionTemperature,
                ignitionTemperatureUnit);

            StoreReceiptHeadId = storeReceiptHeadId;
            ContainerId = containerId;
            SealNumber = sealNumber;
            Remark = remark;
            DangerousCode = dangerousCode;
            Classification = classification;
            IgnitionTemperature = ignitionTemperature;
            IgnitionTemperatureUnit = ignitionTemperatureUnit;
        }

        private void Validate(
            Guid storeReceiptHeadId,
            Guid containerId,
            string sealNumber,
            decimal ignitionTemperature,
            string ignitionTemperatureUnit)
        {
            if (storeReceiptHeadId == Guid.Empty)
                throw new DomainValidationException("Store receipt head is required.");

            if (containerId == Guid.Empty)
                throw new DomainValidationException("Container is required.");

            if (string.IsNullOrWhiteSpace(sealNumber))
                throw new DomainValidationException("Seal number is required.");

            if (ignitionTemperature < 0)
                throw new DomainValidationException("Ignition temperature cannot be negative.");

            if (!string.IsNullOrWhiteSpace(ignitionTemperatureUnit) &&
                ignitionTemperature == 0)
                throw new DomainValidationException(
                    "Ignition temperature must be greater than zero when a unit is specified.");
        }
    }
}


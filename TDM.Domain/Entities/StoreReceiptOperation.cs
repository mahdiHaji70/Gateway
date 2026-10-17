using System;
using System.Collections.Generic;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class StoreReceiptOperation : BaseEntity
    {
        public Guid ParentId { get; private set; }

        public Guid StoreReceiptHeadId { get; private set; }
        public StoreReceiptHead StoreReceiptHead { get; private set; }

        public Guid StoreReceiptContainerId { get; private set; }
        public StoreReceiptContainer StoreReceiptContainer { get; private set; }

        public Guid OperationTypeId { get; private set; }
        public OperationType OperationType { get; private set; }

        public Guid ServiceId { get; private set; }
        public Service Service { get; private set; }

        public Guid StoreId { get; private set; }
        public Store Store { get; private set; }

        public DateTime Date { get; set; }
        public long PackNb { get; private set; }
        public decimal Weight { get; private set; }
        public decimal Volume { get; private set; }
        public bool IsNonPalletized { get; private set; } = false;
        public bool IsDamaged { get; private set; } = false;
        public bool IsVoluminous { get; private set; } = false;
        public bool IsDangerous { get; private set; } = false;
        public string DangerousCode { get; private set; }
        public string Classification { get; private set; }
        public decimal IgnitionTemperature { get; private set; }
        public string IgnitionTemperatureUnit { get; private set; }
        public decimal UnitWeight { get; private set; } = 0;

        protected StoreReceiptOperation()
        {
        }

        public StoreReceiptOperation(
            Guid parentId,
            Guid storeReceiptHeadId,
            Guid storeReceiptContainerId,
            Guid operationTypeId,
            Guid serviceId,
            Guid storeId,
            DateTime date,
            long packNb,
            decimal weight,
            decimal volume,
            bool isNonPalletized,
            bool isDamaged,
            bool isVoluminous,
            bool isDangerous,
            string dangerousCode,
            string classification,
            decimal ignitionTemperature,
            string ignitionTemperatureUnit,
            decimal unitWeight)
        {
            SetProperty(
                parentId,
                storeReceiptHeadId,
                storeReceiptContainerId,
                operationTypeId,
                serviceId,
                storeId,
                date,
                packNb,
                weight,
                volume,
                isNonPalletized,
                isDamaged,
                isVoluminous,
                isDangerous,
                dangerousCode,
                classification,
                ignitionTemperature,
                ignitionTemperatureUnit,
                unitWeight);
        }

        public void Update(
            Guid parentId,
            Guid storeReceiptHeadId,
            Guid storeReceiptContainerId,
            Guid operationTypeId,
            Guid serviceId,
            Guid storeId,
            DateTime date,
            long packNb,
            decimal weight,
            decimal volume,
            bool isNonPalletized,
            bool isDamaged,
            bool isVoluminous,
            bool isDangerous,
            string dangerousCode,
            string classification,
            decimal ignitionTemperature,
            string ignitionTemperatureUnit,
            decimal unitWeight)
        {
            SetProperty(
                parentId,
                storeReceiptHeadId,
                storeReceiptContainerId,
                operationTypeId,
                serviceId,
                storeId,
                date,
                packNb,
                weight,
                volume,
                isNonPalletized,
                isDamaged,
                isVoluminous,
                isDangerous,
                dangerousCode,
                classification,
                ignitionTemperature,
                ignitionTemperatureUnit,
                unitWeight);
        }

        private void SetProperty(
            Guid parentId,
            Guid storeReceiptHeadId,
            Guid storeReceiptContainerId,
            Guid operationTypeId,
            Guid serviceId,
            Guid storeId,
            DateTime date,
            long packNb,
            decimal weight,
            decimal volume,
            bool isNonPalletized,
            bool isDamaged,
            bool isVoluminous,
            bool isDangerous,
            string dangerousCode,
            string classification,
            decimal ignitionTemperature,
            string ignitionTemperatureUnit,
            decimal unitWeight)
        {
            Validate(
                parentId,
                storeReceiptHeadId,
                storeReceiptContainerId,
                operationTypeId,
                serviceId,
                storeId,
                date,
                packNb,
                weight,
                volume,
                ignitionTemperature,
                ignitionTemperatureUnit,
                unitWeight);

            ParentId = parentId;
            StoreReceiptHeadId = storeReceiptHeadId;
            StoreReceiptContainerId = storeReceiptContainerId;
            OperationTypeId = operationTypeId;
            ServiceId = serviceId;
            StoreId = storeId;
            Date = date;
            PackNb = packNb;
            Weight = weight;
            Volume = volume;
            IsNonPalletized = isNonPalletized;
            IsDamaged = isDamaged;
            IsVoluminous = isVoluminous;
            IsDangerous = isDangerous;
            DangerousCode = dangerousCode;
            Classification = classification;
            IgnitionTemperature = ignitionTemperature;
            IgnitionTemperatureUnit = ignitionTemperatureUnit;
            UnitWeight = unitWeight;
        }

        private static void Validate(
            Guid parentId,
            Guid storeReceiptHeadId,
            Guid storeReceiptContainerId,
            Guid operationTypeId,
            Guid serviceId,
            Guid storeId,
            DateTime date,
            long packNb,
            decimal weight,
            decimal volume,
            decimal ignitionTemperature,
            string ignitionTemperatureUnit,
            decimal unitWeight)
        {
            if (parentId == Guid.Empty)
                throw new DomainValidationException("Parent is required.");

            if (storeReceiptHeadId == Guid.Empty)
                throw new DomainValidationException("Store receipt head is required.");

            if (storeReceiptContainerId == Guid.Empty)
                throw new DomainValidationException("Store receipt container is required.");

            if (operationTypeId == Guid.Empty)
                throw new DomainValidationException("Operation type is required.");

            if (serviceId == Guid.Empty)
                throw new DomainValidationException("Service is required.");

            if (storeId == Guid.Empty)
                throw new DomainValidationException("Store is required.");

            if (date == default)
                throw new DomainValidationException("Date is required.");

            if (packNb < 0 || weight < 0 || volume < 0 || unitWeight < 0)
                throw new DomainValidationException("Operation quantities cannot be negative.");

            if (ignitionTemperature < 0)
                throw new DomainValidationException("Ignition temperature cannot be negative.");

            if (!string.IsNullOrWhiteSpace(ignitionTemperatureUnit) && ignitionTemperature == 0)
                throw new DomainValidationException("Ignition temperature must be greater than zero when a unit is specified.");
        }


    }
}

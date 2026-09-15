using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class StoreReceiptContainer : BaseEntity
    {
        private readonly List<StoreReceiptContainerGood> _storeReceiptContainerGoods = [];

        public Guid StoreReceiptHeadId { get; private set; }

        public StoreReceiptHead StoreReceiptHead { get; private set; }

        public Guid ContainerId { get; private set; }

        public Container Container { get; private set; }

        public string SealNumber { get; private set; }

        public string Remark { get; private set; }

        public string DangerousCode { get; private set; }

        public string Classification { get; private set; }

        public decimal IgnitionTemperature { get; private set; }

        public string IgnitionTemperatureUnit { get; private set; }

        public IReadOnlyCollection<StoreReceiptContainerGood>
            StoreReceiptContainerGoods
            => _storeReceiptContainerGoods.AsReadOnly();
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
        public StoreReceiptContainerGood AddGood(
       Guid commodityId,
       Guid packageId,
       string brandName,
       bool noBrandName,
       decimal packNB,
       decimal grossWeight,
       decimal netWeight,
       decimal volume,
       bool isHeavy,
       bool isNonPalletized,
       bool isDamaged,
       bool isVoluminous,
       bool isDangerous,
       bool dangerousNotNoticed)
        {
            var good = new StoreReceiptContainerGood(
                Id,
                commodityId,
                packageId,
                brandName,
                noBrandName,
                packNB,
                grossWeight,
                netWeight,
                volume,
                isHeavy,
                isNonPalletized,
                isDamaged,
                isVoluminous,
                isDangerous,
                dangerousNotNoticed);

            _storeReceiptContainerGoods.Add(good);

            return good;
        }

        public void RemoveGood(Guid goodId)
        {
            var good = _storeReceiptContainerGoods
                .FirstOrDefault(x => x.Id == goodId);

            if (good is null)
                throw new DomainValidationException(
                    "Store receipt container good not found.");

            _storeReceiptContainerGoods.Remove(good);
        }
    }
}


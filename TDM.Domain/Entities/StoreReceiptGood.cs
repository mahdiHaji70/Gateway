using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class StoreReceiptGood : BaseEntity
    {
        public Guid StoreReceiptHeadId { get; private set; }
        public StoreReceiptHead StoreReceiptHead { get; private set; }
        public Guid CommodityId { get; private set; }
        public Commodity Commodity { get; private set; }
        public Guid PackageId { get; private set; }
        public Package Package { get; private set; }
        public string BrandName { get; private set; }
        public bool NoBrandName { get; private set; }
        public decimal PackNB { get; private set; }
        public decimal GrossWeight { get; private set; }
        public decimal NetWeight { get; private set; }
        public decimal Volume { get; private set; }
        public string Remark { get; private set; }
        public bool IsHeavy { get; private set; } = false;
        public bool IsNonPalletized { get; private set; } = false;
        public bool IsDamaged { get; private set; } = false;
        public bool IsVoluminous { get; private set; } = false;
        public bool IsDangerous { get; private set; } = false;
        public bool DangerousNotNoticed { get; private set; } = false;
        public string DangerousCode { get; private set; }
        public string Classification { get; private set; }
        public decimal IgnitionTemperature { get; private set; }
        public string IgnitionTemperatureUnit { get; private set; }

       public StoreReceiptGood(
           Guid storeReceiptHeadId,
           Guid commodityId,
           Guid packageId,
           string brandName,
           bool noBrandName,
           decimal packNB,
           decimal grossWeight,
           decimal netWeight,
           decimal volume,
           string remark,
           bool isHeavy,
           bool isNonPalletized,
           bool isDamaged,
           bool isVoluminous,
           bool isDangerous,
           bool dangerousNotNoticed,
           string dangerousCode,
           string classification,
           decimal ignitionTemperature,
           string ignitionTemperatureUnit)
        {
            SetProperty(
                storeReceiptHeadId,
                commodityId,
                packageId,
                brandName,
                noBrandName,
                packNB,
                grossWeight,
                netWeight,
                volume,
                remark,
                isHeavy,
                isNonPalletized,
                isDamaged,
                isVoluminous,
                isDangerous,
                dangerousNotNoticed,
                dangerousCode,
                classification,
                ignitionTemperature,
                ignitionTemperatureUnit);
        }

        public void Update(
            Guid storeReceiptHeadId,
            Guid commodityId,
            Guid packageId,
            string brandName,
            bool noBrandName,
            decimal packNB,
            decimal grossWeight,
            decimal netWeight,
            decimal volume,
            string remark,
            bool isHeavy,
            bool isNonPalletized,
            bool isDamaged,
            bool isVoluminous,
            bool isDangerous,
            bool dangerousNotNoticed,
            string dangerousCode,
            string classification,
            decimal ignitionTemperature,
            string ignitionTemperatureUnit)
        {
            SetProperty(
                storeReceiptHeadId,
                commodityId,
                packageId,
                brandName,
                noBrandName,
                packNB,
                grossWeight,
                netWeight,
                volume,
                remark,
                isHeavy,
                isNonPalletized,
                isDamaged,
                isVoluminous,
                isDangerous,
                dangerousNotNoticed,
                dangerousCode,
                classification,
                ignitionTemperature,
                ignitionTemperatureUnit);
        }

        private void SetProperty(
            Guid storeReceiptHeadId,
            Guid commodityId,
            Guid packageId,
            string brandName,
            bool noBrandName,
            decimal packNB,
            decimal grossWeight,
            decimal netWeight,
            decimal volume,
            string remark,
            bool isHeavy,
            bool isNonPalletized,
            bool isDamaged,
            bool isVoluminous,
            bool isDangerous,
            bool dangerousNotNoticed,
            string dangerousCode,
            string classification,
            decimal ignitionTemperature,
            string ignitionTemperatureUnit)
        {
            Validate(
                storeReceiptHeadId,
                commodityId,
                packageId,
                packNB,
                grossWeight,
                netWeight,
                volume,
                isDangerous,
                dangerousCode,
                ignitionTemperature,
                ignitionTemperatureUnit);

            StoreReceiptHeadId = storeReceiptHeadId;
            CommodityId = commodityId;
            PackageId = packageId;
            BrandName = brandName;
            NoBrandName = noBrandName;
            PackNB = packNB;
            GrossWeight = grossWeight;
            NetWeight = netWeight;
            Volume = volume;
            Remark = remark;
            IsHeavy = isHeavy;
            IsNonPalletized = isNonPalletized;
            IsDamaged = isDamaged;
            IsVoluminous = isVoluminous;
            IsDangerous = isDangerous;
            DangerousNotNoticed = dangerousNotNoticed;
            DangerousCode = dangerousCode;
            Classification = classification;
            IgnitionTemperature = ignitionTemperature;
            IgnitionTemperatureUnit = ignitionTemperatureUnit;
        }

        private void Validate(
            Guid storeReceiptHeadId,
            Guid commodityId,
            Guid packageId,
            decimal packNB,
            decimal grossWeight,
            decimal netWeight,
            decimal volume,
            bool isDangerous,
            string dangerousCode,
            decimal ignitionTemperature,
            string ignitionTemperatureUnit)
        {
            if (storeReceiptHeadId == Guid.Empty)
                throw new DomainValidationException("Store receipt head is required.");

            if (commodityId == Guid.Empty)
                throw new DomainValidationException("Commodity is required.");

            if (packageId == Guid.Empty)
                throw new DomainValidationException("Package is required.");

            if (packNB < 0)
                throw new DomainValidationException("Package quantity cannot be negative.");

            if (grossWeight < 0)
                throw new DomainValidationException("Gross weight cannot be negative.");

            if (netWeight < 0)
                throw new DomainValidationException("Net weight cannot be negative.");

            if (volume < 0)
                throw new DomainValidationException("Volume cannot be negative.");

            if (isDangerous)
            {
                if (string.IsNullOrWhiteSpace(dangerousCode))
                    throw new DomainValidationException("Dangerous code is required.");

                if (ignitionTemperature < 0)
                    throw new DomainValidationException("Ignition temperature cannot be negative.");

                if (string.IsNullOrWhiteSpace(ignitionTemperatureUnit))
                    throw new DomainValidationException("Ignition temperature unit is required.");
            }
        }

    }
}

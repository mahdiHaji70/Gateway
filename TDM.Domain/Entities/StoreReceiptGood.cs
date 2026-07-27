using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class StoreReceiptGood : BaseEntity
    {
        public Guid StoreReceiptHeadId { get; set; }
        public StoreReceiptHead StoreReceiptHead { get; set; }
        public Guid CommodityId { get; set; }
        public Commodity Commodity { get; set; }
        public Guid PackageId { get; set; }
        public Package Package { get; set; }
        public string BrandName { get; set; }
        public bool NoBrandName { get; set; }
        public decimal PackageQuantity { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public decimal Volume { get; set; }
        public string Remark { get; set; }
        public bool IsHeavy { get; set; } = false;
        public bool IsNonPalletized { get; set; } = false;
        public bool IsDamaged { get; set; } = false;
        public bool IsVoluminous { get; set; } = false;
        public bool IsDangerous { get; set; } = false;
        public bool DangerousNotNoticed { get; set; } = false;
        public string DangerousCode { get; set; }
        public string Classification { get; set; }
        public decimal IgnitionTemperature { get; set; }
        public string IgnitionTemperatureUnit { get; set; }

       public StoreReceiptGood(
           Guid storeReceiptHeadId,
           Guid commodityId,
           Guid packageId,
           string brandName,
           bool noBrandName,
           decimal packageQuantity,
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
                packageQuantity,
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
            decimal packageQuantity,
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
                packageQuantity,
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
            decimal packageQuantity,
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
                packageQuantity,
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
            PackageQuantity = packageQuantity;
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
            decimal packageQuantity,
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

            if (packageQuantity < 0)
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

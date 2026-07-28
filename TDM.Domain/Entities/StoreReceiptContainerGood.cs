using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class StoreReceiptContainerGood:BaseEntity
    {
        public Guid StoreReceiptContainerId { get; set; } 
        public StoreReceiptContainer StoreReceiptContainer { get; set; }
        public Guid CommodityId { get; set; }
        public Commodity Commodity { get; set; }
        public Guid PackageId { get; set; }
        public Package Package { get; set; }
        public string BrandName { get; set; }
        public bool NoBrandName { get; set; }
        public decimal PackNB { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public decimal Volume { get; set; }
        public bool IsHeavy { get; set; } = false;
        public bool IsNonPalletized { get; set; } = false;
        public bool IsDamaged { get; set; } = false;
        public bool IsVoluminous { get; set; } = false;
        public bool IsDangerous { get; set; } = false;
        public bool DangerousNotNoticed { get; set; } = false;
        StoreReceiptContainerGood()
        {
        }

        public StoreReceiptContainerGood(
            Guid storeReceiptContainerId,
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
            SetProperty(
                storeReceiptContainerId,
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
        }

        public void Update(
            Guid storeReceiptContainerId,
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
            SetProperty(
                storeReceiptContainerId,
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
        }

        private void SetProperty(
            Guid storeReceiptContainerId,
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
            Validate(
                storeReceiptContainerId,
                commodityId,
                packageId,
                packNB,
                grossWeight,
                netWeight,
                volume);

            StoreReceiptContainerId = storeReceiptContainerId;
            CommodityId = commodityId;
            PackageId = packageId;
            BrandName = brandName;
            NoBrandName = noBrandName;
            PackNB = packNB;
            GrossWeight = grossWeight;
            NetWeight = netWeight;
            Volume = volume;
            IsHeavy = isHeavy;
            IsNonPalletized = isNonPalletized;
            IsDamaged = isDamaged;
            IsVoluminous = isVoluminous;
            IsDangerous = isDangerous;
            DangerousNotNoticed = dangerousNotNoticed;
        }

        private void Validate(
            Guid storeReceiptContainerId,
            Guid commodityId,
            Guid packageId,
            decimal packNB,
            decimal grossWeight,
            decimal netWeight,
            decimal volume)
        {
            if (storeReceiptContainerId == Guid.Empty)
                throw new DomainValidationException("Store receipt container is required.");

            if (commodityId == Guid.Empty)
                throw new DomainValidationException("Commodity is required.");

            if (packageId == Guid.Empty)
                throw new DomainValidationException("Package is required.");

            if (packNB <= 0)
                throw new DomainValidationException("Package quantity must be greater than zero.");

            if (grossWeight < 0)
                throw new DomainValidationException("Gross weight cannot be negative.");

            if (netWeight < 0)
                throw new DomainValidationException("Net weight cannot be negative.");

            if (volume <= 0)
                throw new DomainValidationException("Volume must be greater than zero.");
        }
    }
}


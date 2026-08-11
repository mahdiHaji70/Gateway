using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class ManifestGood : BaseEntity
    {
        public long PackNb { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public decimal Volume { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }

        public Guid ManifestItemId { get; set; }
        public ManifestItem ManifestItem { get; set; }

        public Guid CommodityId { get; set; }
        public Commodity Commodity { get; set; }

        public Guid PackageId { get; set; }
        public Package Package { get; set; }

        public ManifestGood(
            Guid manifestItemId,
            long packNb,
            decimal grossWeight,
            decimal netWeight,
            decimal volume,
            string brandName,
            string description,
            Guid commodityId,
            Guid packageId)
        {
            SetProperty(
                manifestItemId,
                packNb,
                grossWeight,
                netWeight,
                volume,
                brandName,
                description,
                commodityId,
                packageId);
        }

        public void Update(
            Guid manifestItemId,
            long packNb,
            decimal grossWeight,
            decimal netWeight,
            decimal volume,
            string brandName,
            string description,
            Guid commodityId,
            Guid packageId)
        {
            SetProperty(
                manifestItemId,
                packNb,
                grossWeight,
                netWeight,
                volume,
                brandName,
                description,
                commodityId,
                packageId);
        }

        private void SetProperty(
            Guid manifestItemId,
            long packNb,
            decimal grossWeight,
            decimal netWeight,
            decimal volume,
            string brandName,
            string description,
            Guid commodityId,
            Guid packageId)
        {
            Validate(
                manifestItemId,
                packNb,
                grossWeight,
                netWeight,
                volume,
                commodityId,
                packageId);

            ManifestItemId = manifestItemId;
            PackNb = packNb;
            GrossWeight = grossWeight;
            NetWeight = netWeight;
            Volume = volume;
            BrandName = brandName;
            Description = description;
            CommodityId = commodityId;
            PackageId = packageId;
        }

        private void Validate(
            Guid manifestItemId,
            long packNb,
            decimal grossWeight,
            decimal netWeight,
            decimal volume,
            Guid commodityId,
            Guid packageId)
        {
            if (manifestItemId == Guid.Empty)
                throw new DomainValidationException("Manifest item is required.");

            if (packNb <= 0)
                throw new DomainValidationException("Package number must be greater than zero.");

            if (grossWeight < 0)
                throw new DomainValidationException("Gross weight cannot be negative.");

            if (netWeight < 0)
                throw new DomainValidationException("Net weight cannot be negative.");

            if (grossWeight < netWeight)
                throw new DomainValidationException("Gross weight cannot be less than net weight.");

            if (volume <= 0)
                throw new DomainValidationException("Volume must be greater than zero.");

            if (commodityId == Guid.Empty)
                throw new DomainValidationException("Commodity is required.");

            if (packageId == Guid.Empty)
                throw new DomainValidationException("Package is required.");
        }
    }
}
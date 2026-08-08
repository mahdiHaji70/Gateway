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

        public Guid CommodityId { get; set; }
        public Commodity Commodity { get; set; }

        public Guid PackageId { get; set; }
        public Package Package { get; set; }

        public ManifestGood(
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
                packNb,
                grossWeight,
                netWeight,
                volume,
                commodityId,
                packageId);

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
            long packNb,
            decimal grossWeight,
            decimal netWeight,
            decimal volume,
            Guid commodityId,
            Guid packageId)
        {           
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
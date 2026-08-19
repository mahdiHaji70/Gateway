using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class ManifestContainerGood : BaseEntity
    {
        public long PackNb { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }

        public Guid ManifestContainerId { get; set; }
        public ManifestContainer ManifestContainer { get; set; }

        public Guid PackageId { get; set; }
        public Package Package { get; set; }

        public Guid CommodityId { get; set; }
        public Commodity Commodity { get; set; }

        ManifestContainerGood()
        {
        }

        public ManifestContainerGood(
            long packNb,
            decimal grossWeight,
            decimal netWeight,
            Guid packageId,
            Guid commodityId)
        {
            SetProperty( packNb, grossWeight, netWeight, packageId, commodityId);
        }

        public void Update(
            long packNb,
            decimal grossWeight,
            decimal netWeight,
            Guid packageId,
            Guid commodityId)
        {
            SetProperty( packNb, grossWeight, netWeight, packageId, commodityId);
        }

        private void SetProperty(
            long packNb,
            decimal grossWeight,
            decimal netWeight,
            Guid packageId,
            Guid commodityId)
        {
            Validate( packNb, grossWeight, netWeight, packageId, commodityId);

            PackNb = packNb;
            GrossWeight = grossWeight;
            NetWeight = netWeight;
            PackageId = packageId;
            CommodityId = commodityId;
        }

        private void Validate(
            long packNb,
            decimal grossWeight,
            decimal netWeight,
            Guid packageId,
            Guid commodityId)
        {            
            if (packNb <= 0)
                throw new DomainValidationException("Package number must be greater than zero.");

            if (grossWeight < 0)
                throw new DomainValidationException("Gross weight cannot be negative.");

            if (netWeight < 0)
                throw new DomainValidationException("Net weight cannot be negative.");

            if (grossWeight < netWeight)
                throw new DomainValidationException("Gross weight cannot be less than net weight.");

            if (packageId == Guid.Empty)
                throw new DomainValidationException("Package is required.");

            if (commodityId == Guid.Empty)
                throw new DomainValidationException("Commodity is required.");
        }
    }
}

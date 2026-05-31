
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class DeclarationItem : BaseEntity
    {
        public long Quantity { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }

        public Guid CommodityId { get; set; }
        public Commodity Commodity { get; set; }

        public Guid PackageId { get; set; }
        public Package Package { get; set; }

        public DeclarationItem(
            long quantity,
             decimal grossWeight,
             decimal netWeight,
            Guid commodityId,
            Guid packageId)
        {
            Validate(quantity, grossWeight, netWeight, commodityId, packageId);

            Quantity = quantity;
            GrossWeight = grossWeight;
            NetWeight = netWeight;
            CommodityId = commodityId;
            PackageId = packageId;
        }

        public void Update(
            long quantity,
             decimal grossWeight,
             decimal netWeight,
            Guid commodityId,
            Guid packageId)
        {
            Validate(quantity, grossWeight, netWeight, commodityId, packageId);

            Quantity = quantity;
            GrossWeight = grossWeight;
            NetWeight = netWeight;
            CommodityId = commodityId;
            PackageId = packageId;
        }

        private void Validate(long quantity, decimal grossWeight, decimal netWeight, Guid commodityId, Guid packageId)
        {
            if (quantity <= 0)
                throw new DomainValidationException("Quantity must be greater than zero.");

            if (grossWeight <= 0)
                throw new DomainValidationException("GrossWeight must be greater than zero.");

            if (netWeight < 0)
                throw new DomainValidationException("NetWeight cannot be negative.");

            if (netWeight > grossWeight)
                throw new DomainValidationException("NetWeight cannot be greater than GrossWeight.");

            if (commodityId == Guid.Empty)
                throw new DomainValidationException("CommodityId is required.");

            if (packageId == Guid.Empty)
                throw new DomainValidationException("PackageId is required.");
        }
    }
}

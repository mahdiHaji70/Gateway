
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class DeclarationContainerGood : BaseEntity
    {
        public long Quantity { get; set; }
        public decimal Weight { get; set; }
        public string? Description { get; set; }

        public Guid DeclarationContainerId { get; set; }
        public DeclarationContainer DeclarationContainer { get; set; }

        public Guid CommodityId { get; set; }
        public Commodity Commodity { get; set; }

        public Guid PackageId { get; set; }
        public Package Package { get; set; }

        
        public DeclarationContainerGood(long quantity, decimal weight, string? description,
            Guid commodityId, Guid packageId)
        {
            Validate(quantity, weight, commodityId, packageId);

            Quantity = quantity;
            Weight = weight;
            Description = description;
            CommodityId = commodityId;
            PackageId = packageId;
        }

        private void Validate(long quantity, decimal weight,
            Guid commodityId, Guid packageId)
        {
            if (quantity <= 0)
                throw new DomainValidationException("Quantity must be greater than zero.");

            if (weight <= 0)
                throw new DomainValidationException("GrossWeight must be greater than zero.");

            if (commodityId == Guid.Empty)
                throw new DomainValidationException("Commodity Id is required.");

            if (packageId == Guid.Empty)
                throw new DomainValidationException("Package Id is required.");
        }
    }
}

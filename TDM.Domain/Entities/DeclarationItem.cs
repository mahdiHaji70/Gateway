
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class DeclarationItem : BaseEntity
    {
        public long Quantity { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }

        public Guid DeclarationId { get; set; }
        public Declaration Declaration { get; set; }

        public Guid CommodityId { get; set; }
        public Commodity Commodity { get; set; }

        public Guid PackageId { get; set; }
        public Package Package { get; set; }

        public ICollection<DeclarationContainer> DeclarationContainers { get; private set; } = new List<DeclarationContainer>();

        public ICollection<TerminalDischarge> TerminalDischarges { get; private set; } = new List<TerminalDischarge>();

        public DeclarationItem(
            long quantity,
            decimal grossWeight,
            decimal netWeight,
            Guid declarationId,
            Guid commodityId,
            Guid packageId)
        {
            Validate(quantity, grossWeight, netWeight, declarationId, commodityId, packageId);

            Quantity = quantity;
            GrossWeight = grossWeight;
            NetWeight = netWeight;
            DeclarationId = declarationId;
            CommodityId = commodityId;
            PackageId = packageId;
        }

        public void Update(
            long quantity,
            decimal grossWeight,
            decimal netWeight,
            Guid declarationId,
            Guid commodityId,
            Guid packageId)
        {
            Validate(quantity, grossWeight, netWeight, declarationId, commodityId, packageId);

            Quantity = quantity;
            GrossWeight = grossWeight;
            NetWeight = netWeight;
            DeclarationId = declarationId;
            CommodityId = commodityId;
            PackageId = packageId;
        }

        public void AddContainer(DeclarationContainer container)
        {
            DeclarationContainers.Add(container);
        }

        private void Validate(long quantity, decimal grossWeight, decimal netWeight, Guid declarationId, Guid commodityId, Guid packageId)
        {
            if (quantity <= 0)
                throw new DomainValidationException("Quantity must be greater than zero.");

            if (grossWeight <= 0)
                throw new DomainValidationException("GrossWeight must be greater than zero.");

            if (netWeight < 0)
                throw new DomainValidationException("NetWeight cannot be negative.");

            if (netWeight > grossWeight)
                throw new DomainValidationException("NetWeight cannot be greater than GrossWeight.");

            if (declarationId == Guid.Empty)
                throw new DomainValidationException("Declaration Id is required.");

            if (commodityId == Guid.Empty)
                throw new DomainValidationException("Commodity Id is required.");

            if (packageId == Guid.Empty)
                throw new DomainValidationException("Package Id is required.");
        }
    }
}

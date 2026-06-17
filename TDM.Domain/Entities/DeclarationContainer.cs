
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class DeclarationContainer : BaseEntity
    {
        public Guid ContainerId { get; set; }
        public Container Container { get; set; }

        public Guid DeclarationItemId { get; set; }
        public DeclarationItem DeclarationItem { get; set; }

        public ICollection<DeclarationContainerGood> DeclarationContainerGoods { get; private set; } = new List<DeclarationContainerGood>();

        public DeclarationContainer()
        {
            
        }

        public DeclarationContainer(Guid containerid)
        {
            Validate(containerid);

            ContainerId = containerid;
        }

        public void AddGood(DeclarationContainerGood containerGood)
        {
            DeclarationContainerGoods.Add(containerGood);
        }

        private void Validate(Guid containerid)
        {
            if (containerid == Guid.Empty)
                throw new DomainValidationException("Container Id is required.");
        }
    }
}


using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class DeclarationContainer : BaseEntity
    {
        public string No { get; set; }
        public string TypeAndSizeCode { get; set; }
        public string TypeAndSize { get; set; }

        public Guid DeclarationItemId { get; set; }
        public DeclarationItem DeclarationItem { get; set; }

        public ICollection<DeclarationContainerGood> DeclarationContainerGoods { get; private set; } = new List<DeclarationContainerGood>();


        public DeclarationContainer(string no, string typeAndSizeCode, string typeAndSize)
        {
            Validate(no, typeAndSizeCode, typeAndSize);

            No = no;
            TypeAndSizeCode = typeAndSizeCode;
            TypeAndSize = typeAndSize;
        }

        public void AddGood(DeclarationContainerGood containerGood)
        {
            DeclarationContainerGoods.Add(containerGood);
        }

        private void Validate(string no, string typeAndSizeCode, string typeAndSize)
        {            
            if (string.IsNullOrEmpty(no))
                throw new DomainValidationException("No is required.");

            if (string.IsNullOrEmpty(typeAndSizeCode))
                throw new DomainValidationException("Type And Size Code is required.");

            if (string.IsNullOrEmpty(typeAndSize))
                throw new DomainValidationException("Type And Size is required.");

        }
    }
}

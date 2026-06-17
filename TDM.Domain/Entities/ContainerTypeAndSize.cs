
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class ContainerTypeAndSize : BaseEntity
    {
        public string TypeAndSize { get; set; }
        public string TypeAndSizeCode { get; set; }

        public ICollection<Container> Containers { get; private set; } = new List<Container>();

        public ContainerTypeAndSize(string typeAndSize, string typeAndSizeCode)
        {
            Validate(typeAndSize, typeAndSizeCode);

            TypeAndSize = typeAndSize;
            TypeAndSizeCode = typeAndSizeCode;
        }

        public void Update(string typeAndSize, string typeAndSizeCode)
        {
            Validate(typeAndSize, typeAndSizeCode);

            TypeAndSize = typeAndSize;
            TypeAndSizeCode = typeAndSizeCode;
        }

        private void Validate(string typeAndSize, string typeAndSizeCode)
        {
            if (string.IsNullOrEmpty(typeAndSize))
                throw new DomainValidationException("Type And Size is required.");

            if (string.IsNullOrEmpty(typeAndSizeCode))
                throw new DomainValidationException("Type And Size Code is required.");
        }
    }
}

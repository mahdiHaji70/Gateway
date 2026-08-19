using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class Traffic : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<Declaration> TrafficDeclarations { get; private set; } = new List<Declaration>();
        public ICollection<StoreReceiptHead> TrafficStoreReceiptHeads { get; private set; } = new List<StoreReceiptHead>();
        public ICollection<ManifestItem> TrafficManifestItems { get; private set; } = new List<ManifestItem>();


        public Traffic(string name, string code)
        {
            Validate(name, code);

            Name = name;
            Code = code;
        }        

        public void Update(string name, string code)
        {
            Validate(name, code);

            Name = name;
            Code = code;
        }

        private void Validate(string name, string code)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainValidationException("Name is required.");

            if (string.IsNullOrEmpty(code))
                throw new DomainValidationException("Code is required.");
        }
    }
}

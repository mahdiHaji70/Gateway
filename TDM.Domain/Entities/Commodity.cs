using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class Commodity : BaseEntity
    {
        public string Name { get; set; }
        public string HsCode { get; set; }

        public ICollection<DeclarationItem> CommodityDeclarationItems { get; private set; } = new List<DeclarationItem>();
        public ICollection<DeclarationContainerGood> CommodityDeclarationContainerGoods { get; private set; } = new List<DeclarationContainerGood>();
        public ICollection<StoreReceiptGood> CommodityStoreReceiptGoods { get; private set; } = new List<StoreReceiptGood>();
        public ICollection<StoreReceiptContainerGood> CommodityStoreReceiptContainerGoods { get; private set; } = new List<StoreReceiptContainerGood>();
        public ICollection<ManifestGood> CommodityManifestGoods { get; private set; } = new List<ManifestGood>();
        public ICollection<ManifestContainerGood> CommodityManifestContainerGoods { get; private set; } = new List<ManifestContainerGood>();


        public Commodity(string name, string hsCode)
        {
            Validate(name, hsCode);

            Name = name;
            HsCode = hsCode;
        }

        public void Update(string name, string hsCode)
        {
            Validate(name, hsCode);

            Name = name;
            HsCode = hsCode;
        }

        private void Validate(string name, string hsCOde)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainValidationException("Name is required.");

            if (string.IsNullOrEmpty(hsCOde))
                throw new DomainValidationException("Post code is required.");

            if (hsCOde.Length != 8)
                throw new DomainValidationException("Post code must be 8 digits.");
        }
    }
}

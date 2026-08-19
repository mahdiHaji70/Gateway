using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class Package : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<DeclarationItem> PackageDeclarationItems { get; private set; } = new List<DeclarationItem>();
        public ICollection<DeclarationContainerGood> PackageDeclarationContainerGoods { get; private set; } = new List<DeclarationContainerGood>();
        public ICollection<StoreReceiptGood> PackageStoreReceiptGoods { get; private set; } = new List<StoreReceiptGood>();
        public ICollection<StoreReceiptContainerGood> PackageStoreReceiptContainerGoods { get; private set; } = new List<StoreReceiptContainerGood>();
        public ICollection<ManifestGood> PackageManifestGoods { get; private set; } = new List<ManifestGood>();
        public ICollection<ManifestContainerGood> PackageManifestContainerGoods { get; private set; } = new List<ManifestContainerGood>();



        public Package(string name, string code)
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

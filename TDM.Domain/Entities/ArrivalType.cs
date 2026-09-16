using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class ArrivalType : BaseEntity
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public ICollection<StoreReceiptHead> ArrivalTypeStoreReceiptHeads { get; private set; } = new List<StoreReceiptHead>();

        public ArrivalType(string name, string code) => SetProperty(name, code);

        public void Update(string name, string code) => SetProperty(name, code);

        private void SetProperty(string name, string code)
        {
            Validate(name, code);
            this.Name = name;
            this.Code = code;
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

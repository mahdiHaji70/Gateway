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
        public ICollection<StoreReceiptHead> ArrivalTypeStoreReceiptHeads { get; private set; } = new List<StoreReceiptHead>();

        public ArrivalType(string name) => SetProperty(name);

        public void Update(string name) => SetProperty(name);

        private void SetProperty(string name)
        {
            Validate(name);
            this.Name = name;
        }
        private void Validate(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainValidationException("Name is required.");
        }

  
    }
  }
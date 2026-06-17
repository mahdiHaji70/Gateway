using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public  class StoreType:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Store> Stores { get; private set; } = new List<Store>();


        public StoreType(string name) => SetProperty(name);
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

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

        public Package(string name, string code)
        {
            Validate(name, code);

            Name = name;
            Code = code;
        }

        public void Update(string name, string code)
        {
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

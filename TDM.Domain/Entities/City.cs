using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; } = null!;

        public City(string name, string code, Guid countryId)
        {
            Validate(name, code, countryId);

            Name = name;
            Code = code;
            CountryId = countryId;
        }

        public void Update(string name, string code, Guid countryId)
        {
            Validate(name, code, countryId);

            Name = name;
            Code = code;
            CountryId = countryId;
        }

        private void Validate(string name, string code, Guid countryId)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainValidationException("Name is required.");

            if (string.IsNullOrEmpty(code))
                throw new DomainValidationException("Code is required.");

            if (countryId == Guid.Empty)
                throw new DomainValidationException("Country Id is required.");
        }
    }
}

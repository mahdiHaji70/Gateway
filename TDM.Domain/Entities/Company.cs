using System.Diagnostics.CodeAnalysis;
using TDM.Domain.Common;
using TDM.Domain.Enums;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class Company : BaseEntity
    {
        public CompanyType CompanyType { get; private set; }
        public string Name { get; private set; }
        public string NationalId { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public string Address { get; private set; }
        public string PostCode { get; private set; }
        public string Mobile { get; private set; }
        public string? EconomicCode { get; private set; }
        public string? RegisterNumber { get; private set; }
        public string? RegisterPlace { get; private set; }
        public string? Phone { get; private set; }

        public Company(CompanyType companyType,
            string name,
            string nationalId,
            DateTime registerDate,
            string address,
            string postCode,
            string mobile,
            string? economicCode,
            string? registerNumber,
            string? registerPlace,
            string? phone)
        {
            Validate(companyType, name, nationalId, registerDate, address, postCode, mobile);

            CompanyType = companyType;
            Name = name;
            NationalId = nationalId;
            RegisterDate = registerDate;
            Address = address;
            PostCode = postCode;
            Mobile = mobile;
            EconomicCode = economicCode;
            RegisterNumber = registerNumber;
            RegisterPlace = registerPlace;
            Phone = phone;
        }

        public void Update(CompanyType companyType,
            string name,
            string nationalId,
            DateTime registerDate,
            string address,
            string postCode,
            string mobile,
            string? economicCode,
            string? registerNumber,
            string? registerPlace,
            string? phone)
        {
            Validate(companyType, name, nationalId, registerDate, address, postCode, mobile);

            CompanyType = companyType;
            Name = name;
            NationalId = nationalId;
            RegisterDate = registerDate;
            Address = address;
            PostCode = postCode;
            Mobile = mobile;
            EconomicCode = economicCode;
            RegisterNumber = registerNumber;
            RegisterPlace = registerPlace;
            Phone = phone;
        }

        private void Validate(
            CompanyType companyType,
            string name,
            string nationalId,            
            DateTime registerDate,
            string address,
            string postCode,
            string mobile)
        {
            if (!Enum.IsDefined(typeof(CompanyType), companyType))
                throw new DomainValidationException("company type is invalid .");

            if (string.IsNullOrEmpty(name))
                throw new DomainValidationException("Name is required.");

            if (string.IsNullOrEmpty(nationalId))
                throw new DomainValidationException("National Id is required.");

            if (string.IsNullOrEmpty(address))
                throw new DomainValidationException("Address Id is required.");

            if (registerDate.Equals(DateTime.MinValue))
                throw new DomainValidationException("Register date invalid.");

            if (string.IsNullOrEmpty(postCode))
                throw new DomainValidationException("Post code is required.");

            if (postCode.Length != 10)
                throw new DomainValidationException("Post code must be 10 digits.");

            if (string.IsNullOrEmpty(mobile))
                throw new DomainValidationException("Mobile is required.");

            if (mobile.Length != 11)
                throw new DomainValidationException("Mobile must be 11 digits.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class Terminal : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string PortCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public ICollection<UserTerminal> UserTerminals { get; private set; } = new List<UserTerminal>();


        public Terminal(string code, string name, string portCode, string username, string password, bool isActive)
        => SetProperties(code, name, portCode, username, password, IsActive);

        public void Update(string code, string name, string portCode, string username, string password, bool isActive)
        => SetProperties(code, name, portCode, username, password, IsActive);

        private void SetProperties(string code, string name, string portCode, string username, string password, bool isActive)
        {
            Validate(code, name, portCode, username, password);
            
            Code = code;
            Name = name;
            PortCode = portCode;
            Username = username;
            Password = password;
            IsActive = isActive;
        }

        private void Validate(string code, string name, string portCode, string username, string password)
        {
            if (string.IsNullOrEmpty(code))
                throw new DomainValidationException("Code is required.");

            if (string.IsNullOrEmpty(name))
                throw new DomainValidationException("Name is required.");

            if (string.IsNullOrEmpty(portCode))
                throw new DomainValidationException("PortCode is required.");

            if (string.IsNullOrEmpty(username))
                throw new DomainValidationException("Username is required.");

            if (string.IsNullOrEmpty(password))
                throw new DomainValidationException("Password is required.");
        }
    }
}

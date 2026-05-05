using ExternalIntegration.Service.Domain.Exceptions;

namespace ExternalIntegration.Service.Domain.Entities
{
    public class Terminal
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required string PortCode { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public bool? IsActive { get; set; }

        public Terminal()
        {            
        }

        public Terminal(string name ,string code, string portCode,string userName, string password)
        {
            Validate(code, portCode, userName, password);

            Id = Guid.NewGuid();
            Name = name;
            Code = code;
            PortCode = portCode;
            UserName = userName;
            Password = password;
        }

        public void UpdateCredentials(string userName, string password)
        {
            Validate(Code, PortCode, userName, password);

            UserName = userName;
            Password = password;
        }

        private void Validate(string code, string portCode, string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new DomainValidationException("Terminal code is required");

            if (code.Length > 5)
                throw new DomainValidationException("Terminal code too long");

            if (string.IsNullOrWhiteSpace(UserName))
                throw new DomainValidationException("Username is required");

            if (userName.Length > 100)
                throw new DomainValidationException("Username code too long");

            if (string.IsNullOrWhiteSpace(password))
                throw new DomainValidationException("Password is required");

            if (string.IsNullOrWhiteSpace(portCode))
                throw new DomainValidationException("Port code code is required");

            if (portCode.Length > 10)
                throw new DomainValidationException("Port code code too long");
        }
    }
}

using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests;

namespace TOS.Services.Gateway.Infrastructure.Integrations.PMO.Requests
{
    internal class PmoRequestBuilder
    {
        private string? _username;
        private string? _password;
        private string? _serviceName;
        private readonly List<Parameter> _parameters = new();

        public PmoRequestBuilder WithCredential(string username, string password)
        {
            _username = username;
            _password = password;
            return this;
        }

        public PmoRequestBuilder WithService(string serviceName)
        {
            _serviceName = serviceName;
            return this;
        }

        public PmoRequestBuilder WithParameter(string name, object value)
        {
            _parameters.Add(new Parameter
            {
                ParameterName = name,
                ParameterValue = value?.ToString()!
            });
            
            return this;
        }

        public PmoRequestBuilder WithParameters(IEnumerable<Parameter> parameters)
        {
            foreach (var p in parameters)
            {
                WithParameter(p.ParameterName, p.ParameterValue);
            }

            return this;
        }

        public PmoRequest Build()
        {
            if (string.IsNullOrWhiteSpace(_username))
                throw new InvalidOperationException("Username not provided");

            if (string.IsNullOrWhiteSpace(_password))
                throw new InvalidOperationException("Password not provided");

            if (string.IsNullOrWhiteSpace(_serviceName))
                throw new InvalidOperationException("Service name not provided");

            return new PmoRequest
            {
                Credential = new CredentialDto(_username, _password),
                Service = _serviceName,
                Parameters = _parameters
            };
        }
    }

    internal record CredentialDto(string Code, string Password);

    internal class PmoRequest
    {
        public required CredentialDto Credential { get; set; }
        public required string Service { get; set; }
        public required List<Parameter> Parameters { get; set; }
    }
}

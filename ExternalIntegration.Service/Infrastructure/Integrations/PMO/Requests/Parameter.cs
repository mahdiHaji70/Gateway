using Newtonsoft.Json;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class Parameter
    {
        [JsonProperty("parameterName")]
        public required string ParameterName { get; set; }

        [JsonProperty("parameterValue")]
        public required object ParameterValue { get; set; }
    }
}

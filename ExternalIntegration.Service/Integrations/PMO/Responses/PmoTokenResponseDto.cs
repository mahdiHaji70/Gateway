using Newtonsoft.Json;

namespace ExternalIntegration.Service.Integrations.PMO.Responses
{
    public class PmoTokenResponseDto
    {
        [JsonProperty("userId")]
        public string? UserId { get; set; }

        [JsonProperty("username")]
        public string? UserName { get; set; }

        [JsonProperty("token")]
        public string? Token { get; set; }

        [JsonProperty("refreshToken")]
        public string? RefreshToken { get; set; }

        [JsonProperty("succeeded")]
        public string? Succeeded { get; set; }
    }
}

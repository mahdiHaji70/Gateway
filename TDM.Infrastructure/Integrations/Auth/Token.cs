using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TDM.Infrastructure.Integrations.Auth
{
    public class Token
    {
        [JsonPropertyName("accessToken")]
        public string? AccessToken { get; set; }
    }
}

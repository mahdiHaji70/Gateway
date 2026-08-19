using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Infrastructure.Integrations.Responses
{
    public class ManifestVoyageNumberResponseDto
    {
        [JsonProperty("id")]
        public Guid ManifestId { get; set; }
        [JsonProperty("noticeNo")]
        public string VoyageNumber { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.Manifests.DTOs
{
    public class ManifestItemDto
    {
        public string ManifestItemNo { get; set; }
        public string ManifestNo { get; set; }
        public string Consignor { get; set; }
        public string ShipLine { get; set; }
        public Guid ManifestId { get; set; }
        
        public Guid TrafficId { get; set; }
        public string TrafficCode { get; set; }
        public string TrafficName { get; set; }

        public Guid ConsigneeId { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeNationalId { get; set; }

        public Guid ShipAgentId { get; set; }
        public string ShipAgentName { get; set; }
        public string ShipAgentNationalId { get; set; }

        public List<ManifestGoodDto> ManifestGoods { get; set; } 
        public List<ManifestContainerDto> ManifestContainers { get; set; }

    }
}

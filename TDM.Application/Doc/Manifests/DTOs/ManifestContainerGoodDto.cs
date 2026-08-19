using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.Manifests.DTOs
{
    public class ManifestContainerGoodDto
    {
        public long PackNb { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }

        public Guid ManifestContainerId { get; set; }

        public Guid CommodityId { get; set; }
        public string HSCode { get; set; }
        public string CommodityName { get; set; }

        public Guid PackageId { get; set; }
        public string PackageCode { get; set; }
        public string PackageName { get; set; }
    }
}

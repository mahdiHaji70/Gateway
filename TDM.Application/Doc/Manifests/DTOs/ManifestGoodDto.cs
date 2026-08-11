using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.Manifests.DTOs
{
    public class ManifestGoodDto
    {
        public long PackNb { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public decimal Volume { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }

        public Guid ManifestItemId { get; set; }        

        public Guid CommodityId { get; set; }
        public string HSCode { get; set; }
        public string CommodityName { get; set; }

        public Guid PackageId { get; set; }
        public string PackageCode { get; set; }
        public string PackageName { get; set; }
    }
}

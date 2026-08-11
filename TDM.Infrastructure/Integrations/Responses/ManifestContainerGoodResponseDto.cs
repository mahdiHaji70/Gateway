using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Infrastructure.Integrations.Responses
{
    public class ManifestContainerGoodResponseDto
    {
        public string HSCode { get; set; }
        public string GoodsDescription { get; set; }
        public string PackageType { get; set; }
        public string PackageTypeCode { get; set; }
        public decimal PackageCount { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
    }
}

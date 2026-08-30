using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Infrastructure.Integrations.Responses
{
    public class StoreReceiptContainerGoodResponseDto
    {
        public string HSCode { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public decimal PackageQuantity { get; set; }
        public string PackageTypeCode { get; set; }
    }
}

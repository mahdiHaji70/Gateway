using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Infrastructure.Integrations.Responses
{
    public class StoreReceiptBulkResponseDto
    {
        public string HsCode { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public decimal? Volume { get; set; }
        public bool? IsDangerous { get; set; }
        public string Remark { get; set; }
        public Guid? BillOfLadingId { get; set; }
        public bool? DangerousNotNoticed { get; set; }
        public DangerousSpecificationResponseDto DangerousSpecification { get; set; }
    }
}

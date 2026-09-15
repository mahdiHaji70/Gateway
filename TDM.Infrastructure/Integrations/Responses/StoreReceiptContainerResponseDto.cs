using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.StoreReceipts.DTOs;

namespace TDM.Infrastructure.Integrations.Responses
{
    public class StoreReceiptContainerResponseDto
    {
        public string ContainerNo { get; set; }
        public string ContainerTypeAndSizeCode { get; set; }
        public string containerTypeAndSize { get; set; }
        public string SealNumber { get; set; }
        public string Remark { get; set; }
        public Guid? billOfLadingId { get; set; }
        public List<StoreReceiptContainerGoodResponseDto> Goods { get; set; }
        public DangerousSpecificationResponseDto DangerousSpecification { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.StoreReceipts.DTOs
{
    public class StoreReceiptContainerDto
    {
        public Guid StoreReceiptHeadId { get; set; }
        public Guid ContainerId { get; set; }
        public string ContainerNo { get; set; }
        public string SealNumber { get; set; }
        public string Remark { get; set; }
        public string DangerousCode { get; set; }
        public string Classification { get; set; }
        public decimal IgnitionTemperature { get; set; }
        public string IgnitionTemperatureUnit { get; set; }

        public List<StoreReceiptContainerGoodDto> StoreReceiptContainerGoods { get;  set; } 

    }
}

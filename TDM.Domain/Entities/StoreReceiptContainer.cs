using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Common;

namespace TDM.Domain.Entities
{
    public class StoreReceiptContainer : BaseEntity
    {
        public Guid ContainerId { get; set; }
        public Container Container { get; set; }
        public string SealNumber { get; set; }
        public string  Remark { get; set; }
        public string DangerousCode { get; set; }
        public string Classification { get; set; }
        public decimal IgnitionTemperature { get; set; }
        public string IgnitionTemperatureUnit { get; set; }
        public Guid StoreReceiptItemId { get; set; }
        public StoreReceiptItem StoreReceiptItem { get; set; }

        public ICollection<StoreReceiptContainerGood> StoreReceiptContainerGoods { get; private set; } = new List<StoreReceiptContainerGood>();
    }
}

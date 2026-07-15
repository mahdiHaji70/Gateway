using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Common;

namespace TDM.Domain.Entities
{
    public class StoreReceiptGood : BaseEntity
    {
        public Guid StoreReceiptHeadId { get; set; }
        public StoreReceiptHead StoreReceiptHead { get; set; }
        public Guid CommodityId { get; set; }
        public Commodity Commodity { get; set; }
        public Guid PackageId { get; set; }
        public Package Package { get; set; }
        public string BrandName { get; set; }
        public bool NoBrandName { get; set; }
        public decimal PackageQuantity { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public decimal Volume { get; set; }
        public string Remark { get; set; }
        public bool IsHeavy { get; set; } = false;
        public bool IsNonPalletized { get; set; } = false;
        public bool IsDamaged { get; set; } = false;
        public bool IsVoluminous { get; set; } = false;
        public bool IsDangerous { get; set; } = false;
        public bool DangerousNotNoticed {  get; set; } = false;
        public string DangerousCode { get; set; }
        public string Classification { get; set; }
        public decimal IgnitionTemperature { get; set; }
        public string IgnitionTemperatureUnit { get; set; }
       
    }
}

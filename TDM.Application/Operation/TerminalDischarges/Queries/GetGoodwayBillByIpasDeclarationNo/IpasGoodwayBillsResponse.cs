using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeByDeclarationNo
{
    public class IpasGoodwayBillsResponse
    {
        public string TerminalCode { get; set; }
        public string IpasDeclarationNo { get; set; }
        public string WaybillNo { get; set; }
        public Guid WaybillId { get; set; }
        public string VehicleNumber { get; set; }
        public string HSCode { get; set; }
        public string CommodityName { get; set; }
        public string PackageCode { get; set; }
        public string PackageName { get; set; }
        public long PackNB { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public string ContainerNo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.StoreReceipts.DTOs
{
    public class StoreReceiptHeadDto
    {
        public string TerminalCode { get; set; }
        public string IPASStoreReceiptNo { get; set; }
        public DateTime IssueDate { get; set; }
        public Guid ConsigneeId { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeNationalId { get; set; }
               
        public Guid ConsigneeRepId { get; set; }
        public string ConsigneeRepName { get; set; }
        public string ConsigneeRepNationalId { get; set; }

        public Guid CargoTypeId { get; set; }
        public string CargoTypeName { get; set; }
        public DateTime? FirstDischargeDate { get; set; }

        public Guid CreatorId { get; set; }
        public string CreatorName { get; set; }
        public Guid TrafficId { get; set; }
        public string TrafficName { get; set; }
        public Guid StoreReceiptStateId { get; set; }
        public string StoreReceiptStateName { get; set; }
        public Guid? RequestId { get; set; }
        public string VoyageNoticeNo { get; set; }
        public Guid ArrivalTypeId { get; set; }
        public string ArrivalTypeName { get; set; }
        public Guid? DeclarationId { get; set; }
        public string? IpasDeclarationNo { get;  set; }
        public Guid? BillOfLadingId { get; set; }
        public List<StoreReceiptGoodDto> StoreReceiptGoods { get;  set; } 
        public List<StoreReceiptContainerDto> StoreReceiptContainers { get;  set; } 

    }
}

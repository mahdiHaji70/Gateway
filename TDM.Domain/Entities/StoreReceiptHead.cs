using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Common;

namespace TDM.Domain.Entities
{
    public class StoreReceiptHead : BaseEntity
    {
        public string TerminalCode { get; set; }
        public string IPASStoreReceiptNo { get; set; }
        public DateTime IssueDate { get; set; }
        public Guid ConsigneeId { get; set; }
        public Company Consignee { get; set; }
        public Guid ConsigneeRepId { get; set; }
        public Company ConsigneeRep { get; set; }
        public Guid CargoTypeId { get; set; }
        public CargoType CargoType { get; set; }
        public DateTime? FirstDischargeDate { get; set; }
        public Guid CreatorId { get; set; }
        public Company Creator { get; set; }
        public Guid TrafficId { get; set; }
        public Traffic Traffic { get; set; }
        public Guid StoreReceiptStateId { get; set; }
        public StoreReceiptState StoreReceiptState { get; set; }
        public Guid? RequestId { get; set; }
        public string VoyageNoticeNo { get; set; }
        public Guid ArrivalTypeId { get; set; }
        public ArrivalType ArrivalType { get; set; }
        public Guid? DeclarationId { get; set; }
        public Declaration? Declaration { get; set; } 
        public Guid? BillOfLadingId { get; set; }
        public ICollection<StoreReceiptGood> StoreReceiptGoods { get; private set; } = new List<StoreReceiptGood>();
        public ICollection<StoreReceiptContainer> StoreReceiptContainers { get; private set; } = new List<StoreReceiptContainer>();

    }
}

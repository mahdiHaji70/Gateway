using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.StoreReceipt.Command.UpdateStoreReceipt
{
   
    public record UpdateStoreReceiptCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string TerminalCode { get; set; }
        public string IPASStoreReceiptNo { get; set; }
        public DateTime IssueDate { get; set; }
        public Guid ConsigneeId { get; set; }
        public Guid ConsigneeRepId { get; set; }
        public Guid CargoTypeId { get; set; }
        public DateTime? FirstDischargeDate { get; set; }
        public Guid CreatorId { get; set; }
        public Guid TrafficId { get; set; }
        public Guid StoreReceiptStateId { get; set; }
        public Guid? RequestId { get; set; }
        public string VoyageNoticeNo { get; set; }
        public Guid ArrivalTypeId { get; set; }
        public Guid? DeclarationId { get; set; }
        public Guid? BillOfLadingId { get; set; }

    }
}

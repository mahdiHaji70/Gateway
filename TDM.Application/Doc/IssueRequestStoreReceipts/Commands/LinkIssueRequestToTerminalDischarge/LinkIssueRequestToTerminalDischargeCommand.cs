using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


namespace TDM.Application.Doc.IssueRequestStoreReceipts.Commands.LinkIssueRequestToTerminalDischarge
{
    public record LinkIssueRequestToTerminalDischargeCommand : IRequest<bool>
    {
        public Guid IssurRequestId { get; set; }
        public string StorageAgreementNo { get; set; }

        public LinkIssueRequestToTerminalDischargeCommand(Guid issurRequestId, string storageAgreementNo)
        {
            IssurRequestId = issurRequestId;
            StorageAgreementNo = storageAgreementNo;
        }
    }
}

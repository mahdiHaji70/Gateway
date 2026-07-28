using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.IssueRequestStoreReceipt.Commands.IssueRequestConfirmation
{
    public class IssueRequestConfirmationRequest
    {
        public string TerminalCode { get; set; }
        public Guid RequestId { get; set; }
        public bool IsApproved { get; set; }
        public string Description { get; set; }
    }
}

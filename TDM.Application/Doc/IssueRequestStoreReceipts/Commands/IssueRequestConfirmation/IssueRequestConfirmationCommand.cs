using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.IssueRequestStoreReceipt.Commands.IssueRequestConfirmation
{
  
    public record IssueRequestConfirmationCommand : IRequest<string>
    {
        public string TerminalCode { get; set; }
        public Guid RequestId { get; set; }
        public bool IsApproved { get; set; }
        public string Description { get; set; }

        public IssueRequestConfirmationCommand(string terminalCode,Guid requestId,bool isApproved, string description)
        {
            TerminalCode = terminalCode;
            RequestId = requestId;
            IsApproved = isApproved;
            Description = description;
        }
    }
}

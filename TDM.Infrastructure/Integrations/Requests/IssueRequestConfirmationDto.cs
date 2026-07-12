using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Infrastructure.Integrations.Requests
{
    public class IssueRequestConfirmationDto
    {
        public string TerminalCode { get; set; }
        public Guid RequestId { get; set; }
        public bool IsApproved { get; set; }
        public string Description { get; set; }
    }
}

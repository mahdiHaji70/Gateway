using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.BasicInformation.UsersTerminal.DTOs
{
    public class UserTerminalDto
    {
        public Guid Id { get; set; }
        public string UserNationalId { get; set; } = default!;
        public Guid TerminalId { get; set; }
        public string TerminalCode { get; set; } = default!;
        public string TerminalName { get; set; } = default!;
        public string TerminalPortCode { get; set; } = default!;
    }
}

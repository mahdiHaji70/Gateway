using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.BasicInformation.Terminals.DTOs
{
    public class TerminalDto
    {
        public Guid Id { get; set; }
        public string Code { get; init; } = default!;
        public string Name { get; init; } = default!;
        public string PortCode { get; init; } = default!;
        public string Username { get; init; } = default!;
        public string Password { get; init; } = default!;
        public bool IsActive { get; init; } = default!;
    }
}

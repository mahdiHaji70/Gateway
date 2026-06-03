using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.Declarations.Commands.RequestIpasDeclarationId
{
    public class IpasDeclarationIdRequest
    {
        public string TerminalCode { get; set; } = default!;
        public DateTime Date { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Traffic { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string ConsigneeName { get; set; } = default!;
        public string ConsigneeNationalId { get; set; } = default!;
        public DateTime ConsigneeRegisterDate { get; set; } = default!;
        public string ConsigneeMobile { get; set; } = default!;
        public string ConsigneePostCode { get; set; } = default!;
        public string ConsigneeAddress { get; set; } = default!;
        public bool ConsigneeIsCompany { get; set; } = default!;
        public string ConsigneeRepName { get; set; } = default!;
        public string ConsigneeRepNationalId { get; set; } = default!;
        public DateTime ConsigneeRepBirthDate { get; set; } = default!;
        public string ConsigneeRepMobile { get; set; } = default!;
        public string ConsigneeRepPostCode { get; set; } = default!;
        public string ConsigneeRepAddress { get; set; } = default!;
        public bool ConsigneeRepIsCompany { get; set; } = default!;
    }
}

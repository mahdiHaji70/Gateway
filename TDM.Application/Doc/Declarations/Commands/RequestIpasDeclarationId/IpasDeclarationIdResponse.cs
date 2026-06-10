using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.Declarations.Commands.RequestIpasDeclarationId
{
    public class IpasDeclarationIdResponse
    {
        public Guid IpasDeclarationId { get; set; }
        public string IpasDeclarationNo { get; set; } = default!;
    }
}

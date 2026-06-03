using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.Declarations.Commands.RequestIpasDeclarationId;

namespace TDM.Application.Common.Interfaces
{
    public interface IDeclarationExternalService
    {
        Task<string> GetIpasDeclarationId(IpasDeclarationIdRequest ipasDeclarationIdRequest, CancellationToken cancellationToken = default);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.DeclarationItems.Commands.RequestIpasDeclarationItems;
using TDM.Application.Doc.Declarations.Commands.RequestIpasDeclarationId;

namespace TDM.Application.Common.Interfaces
{
    public interface IDeclarationExternalService
    {
        Task<IpasDeclarationIdResponse> GetIpasDeclarationId(IpasDeclarationIdRequest ipasDeclarationIdRequest, CancellationToken cancellationToken = default);
        Task<List<IpasDeclarationItemResponse>> GetIpasDeclarationItems(IpasDeclarationItemsRequest ipasDeclarationItemsRequest, CancellationToken cancellationToken = default);
    }
}

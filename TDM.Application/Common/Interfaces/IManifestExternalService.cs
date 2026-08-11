using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.Declarations.Commands.RequestIpasDeclarationId;
using TDM.Application.Doc.Manifests.DTOs;

namespace TDM.Application.Common.Interfaces
{
    public interface IManifestExternalService
    {
        Task<List<ManifestVoyageNumberDto>> GetManifestVoyageNumbers(string terminalCode, CancellationToken cancellationToken = default);
        Task<ManifestDto> GetManifestById(Guid id, CancellationToken cancellationToken = default);
    }
}

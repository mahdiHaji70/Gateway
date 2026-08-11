using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.Manifests.DTOs;

namespace TDM.Application.Doc.Manifests.Queries.GetExternalManifestById
{
    public record GetExternalManifestByIdQuery(Guid id) : IRequest<ManifestDto>;

}

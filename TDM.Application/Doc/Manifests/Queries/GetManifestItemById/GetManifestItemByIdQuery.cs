using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.Manifests.DTOs;

namespace TDM.Application.Doc.Manifests.Queries.GetManifestItemById
{
    public record GetManifestItemByIdQuery(Guid itemId) : IRequest<ManifestItemDto>;

}

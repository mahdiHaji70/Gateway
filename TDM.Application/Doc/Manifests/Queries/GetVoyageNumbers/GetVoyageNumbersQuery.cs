using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.Manifests.DTOs;

namespace TDM.Application.Doc.Manifests.Queries.GetVoyageNumbers
{
    public record GetVoyageNumbersQuery(string terminalCode) : IRequest<List<ManifestVoyageNumberDto>>;   
}

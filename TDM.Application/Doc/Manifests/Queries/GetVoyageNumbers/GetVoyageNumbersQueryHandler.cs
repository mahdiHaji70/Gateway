using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.Manifests.DTOs;

namespace TDM.Application.Doc.Manifests.Queries.GetVoyageNumbers
{
    public class GetVoyageNumbersQueryHandler : IRequestHandler<GetVoyageNumbersQuery, List<ManifestVoyageNumberDto>>
    {
        private readonly IManifestExternalService _manifestExternalService;
        private readonly IMapper _mapper;

        public GetVoyageNumbersQueryHandler(IMapper mapper,
            IManifestExternalService manifestExternalService)
        {
            _manifestExternalService = manifestExternalService;
            _mapper = mapper;
        }

        public async Task<List<ManifestVoyageNumberDto>> Handle(GetVoyageNumbersQuery request, CancellationToken cancellationToken)
        {
            return await _manifestExternalService.GetManifestVoyageNumbers(request.terminalCode);
        }
    }
}

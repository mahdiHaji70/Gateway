using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.Manifests.DTOs;
using TDM.Application.Doc.Manifests.Queries.GetVoyageNumbers;

namespace TDM.Application.Doc.Manifests.Queries.GetExternalManifestById
{
    public class GetExternalManifestByIdQueryHandler : IRequestHandler<GetExternalManifestByIdQuery, ManifestDto>
    {
        private readonly IManifestExternalService _manifestExternalService;
        private readonly IMapper _mapper;

        public GetExternalManifestByIdQueryHandler(IMapper mapper,
            IManifestExternalService manifestExternalService)
        {
            _manifestExternalService = manifestExternalService;
            _mapper = mapper;
        }

        public Task<ManifestDto> Handle(GetExternalManifestByIdQuery request, CancellationToken cancellationToken)
        {
            return _manifestExternalService.GetManifestById(request.id);
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.Manifests.DTOs;

namespace TDM.Application.Doc.Manifests.Queries.GetManifestItemById
{
    public class GetManifestItemByIdQueryHandler : IRequestHandler<GetManifestItemByIdQuery, ManifestItemDto>
    {
        private readonly TDM.Application.Common.Interfaces.IManifestRepository _manifestRepository;
        private readonly AutoMapper.IMapper _mapper;

        public GetManifestItemByIdQueryHandler(
            TDM.Application.Common.Interfaces.IManifestRepository manifestRepository,
            AutoMapper.IMapper mapper)
        {
            _manifestRepository = manifestRepository;
            _mapper = mapper;
        }

        public async Task<ManifestItemDto> Handle(GetManifestItemByIdQuery request, CancellationToken cancellationToken)
        {
            var manifestItem = await _manifestRepository.GetManifestItemById(request.itemId, cancellationToken);

            if (manifestItem == null)
                throw new TDM.Application.Common.Exceptions.NotFoundException("Manifest item");

            return _mapper.Map<ManifestItemDto>(manifestItem);
        }
    }
}

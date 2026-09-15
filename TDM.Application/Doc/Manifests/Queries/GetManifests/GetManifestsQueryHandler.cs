using AutoMapper;
using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Application.Doc.Declarations.DTOs;
using TDM.Application.Doc.Manifests.DTOs;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.Manifests.Queries.GetManifests
{
    public class GetManifestsQueryHandler : IRequestHandler<GetManifestsQuery, PagedResult<ManifestListDto>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserTerminalRepository _userTerminalRepository;
        private readonly IManifestRepository _manifestRepository;
        private readonly IMapper _mapper;

        public GetManifestsQueryHandler(IMapper mapper,
            IManifestRepository manifestRepository,
            ICurrentUserService currentUserService,
            IUserTerminalRepository userTerminalRepository)
        {
            _manifestRepository = manifestRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _userTerminalRepository = userTerminalRepository;
        }

        public async Task<PagedResult<ManifestListDto>> Handle(
        GetManifestsQuery request,
        CancellationToken cancellationToken)
        {
            var userTerminal = await _userTerminalRepository.GetByNationalId(_currentUserService.NationalId!);
            if (userTerminal == null)
                throw new Exception("User is not connect to any terminal.");

            var manifests = await _manifestRepository.GetPagedManifests(request.PageNumber, request.PageSize, userTerminal.Terminal.Code);

            return manifests;
        }
    }
}

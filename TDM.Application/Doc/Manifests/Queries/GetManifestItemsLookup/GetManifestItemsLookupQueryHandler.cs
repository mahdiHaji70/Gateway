using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;

namespace TDM.Application.Doc.Manifests.Queries.GetManifestItemsLookup
{
    public class GetManifestItemsLookupQueryHandler : MediatR.IRequestHandler<GetManifestItemsLookupQuery, List<TDM.Application.Doc.Manifests.DTOs.ManifestItemLookupDto>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserTerminalRepository _userTerminalRepository;
        private readonly IManifestRepository _manifestRepository;

        public GetManifestItemsLookupQueryHandler(
            ICurrentUserService currentUserService,
            IUserTerminalRepository userTerminalRepository,
            IManifestRepository manifestRepository)
        {
            _currentUserService = currentUserService;
            _userTerminalRepository = userTerminalRepository;
            _manifestRepository = manifestRepository;
        }

        public async Task<List<TDM.Application.Doc.Manifests.DTOs.ManifestItemLookupDto>> Handle(
            GetManifestItemsLookupQuery request,
            CancellationToken cancellationToken)
        {
            var userTerminal = await _userTerminalRepository.GetByNationalId(_currentUserService.NationalId!);

            if (userTerminal == null)
                throw new Exception("User is not connect to any terminal.");

            return await _manifestRepository.GetManifestItemsLookup(userTerminal.Terminal.Code, cancellationToken);
        }
    }
}

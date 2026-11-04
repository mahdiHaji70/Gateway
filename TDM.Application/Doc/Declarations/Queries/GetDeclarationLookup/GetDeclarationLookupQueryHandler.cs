using AutoMapper;
using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Application.Doc.Declarations.DTOs;

namespace TDM.Application.Doc.Declarations.Queries.GetDeclarationLookup
{
    public class GetDeclarationLookupQueryHandler : IRequestHandler<GetDeclarationLookupQuery, PagedResult<DeclarationLookupDto>>
    {
        private readonly IDeclarationRepository _declarationRepository;
        private readonly IMapper _mapper;

        public GetDeclarationLookupQueryHandler(IDeclarationRepository declarationRepository, IMapper mapper)
        {
            _declarationRepository = declarationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DeclarationLookupDto>> Handle(
            GetDeclarationLookupQuery request,
            CancellationToken cancellationToken)
        {
            var declarations = await _declarationRepository.GetLookupAsync(
                request.Search,
                request.PageNumber,
                request.PageSize);

            return _mapper.Map<PagedResult<DeclarationLookupDto>>(declarations);
        }
    }
}

using AutoMapper;
using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Application.Doc.DeclarationItems.DTOs;

namespace TDM.Application.Doc.DeclarationItems.Queries.GetDeclarationItemLookup
{
    public class GetDeclarationItemLookupQueryHandler
        : IRequestHandler<GetDeclarationItemLookupQuery, PagedResult<DeclarationItemLookupDto>>
    {
        private readonly IDeclarationItemRepository _declarationItemRepository;
        private readonly IMapper _mapper;

        public GetDeclarationItemLookupQueryHandler(IDeclarationItemRepository declarationItemRepository, IMapper mapper)
        {
            _declarationItemRepository = declarationItemRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DeclarationItemLookupDto>> Handle(
            GetDeclarationItemLookupQuery request,
            CancellationToken cancellationToken)
        {
            var declarationItems = await _declarationItemRepository.GetLookupAsync(
                request.Search, request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<DeclarationItemLookupDto>>(declarationItems);
        }
    }
}

using AutoMapper;
using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Application.Doc.DeclarationItems.DTOs;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.DeclarationItems.Queries.GetDeclarationItems
{
    public class GetDeclarationItemsQueryHandler : IRequestHandler<GetDeclarationItemsQuery, PagedResult<DeclarationItemDto>>
    {
        private readonly IDeclarationItemRepository _declarationItemRepository;
        private readonly IMapper _mapper;

        public GetDeclarationItemsQueryHandler(IMapper mapper,
            IDeclarationItemRepository declarationItemRepository)
        {
            _declarationItemRepository = declarationItemRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DeclarationItemDto>> Handle(
        GetDeclarationItemsQuery request,
        CancellationToken cancellationToken)
        {
            var declarationItems = await _declarationItemRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<DeclarationItemDto>>(declarationItems);
        }
    }
}

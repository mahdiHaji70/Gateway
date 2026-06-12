using AutoMapper;
using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Application.Doc.DeclarationItems.DTOs;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.DeclarationItems.Queries.GetDeclarationItemsByDeclarationId
{
    public class GetDeclarationsByDeclarationIdQueryHandler : IRequestHandler<GetDeclarationsByDeclarationIdQuery, IEnumerable<DeclarationItemDto>>
    {
        private readonly IDeclarationItemRepository _declarationItemRepository;
        private readonly IMapper _mapper;

        public GetDeclarationsByDeclarationIdQueryHandler(IMapper mapper,
            IDeclarationItemRepository declarationItemRepository)
        {
            _declarationItemRepository = declarationItemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DeclarationItemDto>> Handle(
        GetDeclarationsByDeclarationIdQuery request,
        CancellationToken cancellationToken)
        {
            var declarationItems = await _declarationItemRepository.GetByDeclarationId(request.Id);

            return _mapper.Map<IEnumerable<DeclarationItemDto>>(declarationItems);
        }
    }
}

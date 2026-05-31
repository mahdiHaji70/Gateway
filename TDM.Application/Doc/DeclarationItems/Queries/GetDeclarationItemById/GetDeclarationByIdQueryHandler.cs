using AutoMapper;
using MediatR;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.DeclarationItems.DTOs;


namespace TDM.Application.BasicInformation.DeclarationItems.Queries.GetDeclarationItemById
{
    public class GetDeclarationItemByIdQueryHandler : IRequestHandler<GetDeclarationItemByIdQuery, DeclarationItemDto>
    {
        private readonly IDeclarationItemRepository _declarationItemRepository;
        private readonly IMapper _mapper;

        public GetDeclarationItemByIdQueryHandler(IMapper mapper,
            IDeclarationItemRepository declarationItemRepository)
        {
            _declarationItemRepository = declarationItemRepository;
            _mapper = mapper;
        }

        public async Task<DeclarationItemDto> Handle(GetDeclarationItemByIdQuery request, CancellationToken cancellationToken)
        {
            var declarationItem = await _declarationItemRepository.GetAsync(request.Id);

            if (declarationItem == null)
                throw new NotFoundException("DeclarationItem");

            return _mapper.Map<DeclarationItemDto>(declarationItem);

        }
    }
}

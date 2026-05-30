using AutoMapper;
using MediatR;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.Declarations.DTOs;


namespace TDM.Application.BasicInformation.Declarations.Queries.GetDeclarationById
{
    public class GetDeclarationByIdQueryHandler : IRequestHandler<GetDeclarationByIdQuery, DeclarationDto>
    {
        private readonly IDeclarationRepository _declarationRepository;
        private readonly IMapper _mapper;

        public GetDeclarationByIdQueryHandler(IMapper mapper,
            IDeclarationRepository declarationRepository)
        {
            _declarationRepository = declarationRepository;
            _mapper = mapper;
        }

        public async Task<DeclarationDto> Handle(GetDeclarationByIdQuery request, CancellationToken cancellationToken)
        {
            var declaration = await _declarationRepository.GetAsync(request.Id);

            if (declaration == null)
                throw new NotFoundException("Declaration");

            return _mapper.Map<DeclarationDto>(declaration);

        }
    }
}

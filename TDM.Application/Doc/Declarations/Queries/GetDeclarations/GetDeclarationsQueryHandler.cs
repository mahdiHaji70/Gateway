using AutoMapper;
using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Application.Doc.Declarations.DTOs;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.Declarations.Queries.GetDeclarations
{
    public class GetDeclarationsQueryHandler : IRequestHandler<GetDeclarationsQuery, PagedResult<DeclarationDto>>
    {
        private readonly IDeclarationRepository _declarationRepository;
        private readonly IMapper _mapper;

        public GetDeclarationsQueryHandler(IMapper mapper,
            IDeclarationRepository declarationRepository)
        {
            _declarationRepository = declarationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DeclarationDto>> Handle(
        GetDeclarationsQuery request,
        CancellationToken cancellationToken)
        {
            var declarations = await _declarationRepository.GetPagedDeclarationsAsync(
                request.PageNumber,
                request.PageSize,
                request.Search,
                request.TrafficId,
                request.ConsigneeId,
                request.ConsigneeRepId,
                request.DateFrom,
                request.DateTo);

            return _mapper.Map<PagedResult<DeclarationDto>>(declarations);
        }
    }
}

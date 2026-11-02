using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.OperationTypes.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.OperationTypes.Queries.GetOperationTypeLookup
{
    public class GetOperationTypeLookupQueryHandler : IRequestHandler<GetOperationTypeLookupQuery, PagedResult<OperationTypeDto>>
    {
        private readonly IOperationTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetOperationTypeLookupQueryHandler(IOperationTypeRepository repository, IMapper mapper)
        { _repository = repository; _mapper = mapper; }

        public async Task<PagedResult<OperationTypeDto>> Handle(GetOperationTypeLookupQuery request, CancellationToken cancellationToken)
            => _mapper.Map<PagedResult<OperationTypeDto>>(await _repository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search));
    }
}

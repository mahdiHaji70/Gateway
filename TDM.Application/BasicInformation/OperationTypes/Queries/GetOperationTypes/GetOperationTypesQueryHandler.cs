using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.OperationTypes.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.OperationTypes.Queries.GetOperationTypes
{
    public class GetOperationTypesQueryHandler : IRequestHandler<GetOperationTypesQuery, PagedResult<OperationTypeDto>>
    {
        private readonly IOperationTypeRepository _operationtypeRepository;
        private readonly IMapper _mapper;

        public GetOperationTypesQueryHandler(IMapper mapper,
            IOperationTypeRepository operationtypeRepository)
        {
            _operationtypeRepository = operationtypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<OperationTypeDto>> Handle(
        GetOperationTypesQuery request,
        CancellationToken cancellationToken)
        {
            var operationtypes = await _operationtypeRepository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search);

            return _mapper.Map<PagedResult<OperationTypeDto>>(operationtypes);
        }
    }
}

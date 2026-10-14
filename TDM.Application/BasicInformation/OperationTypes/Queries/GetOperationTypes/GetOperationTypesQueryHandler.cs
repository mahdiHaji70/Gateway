using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.OperationTypes.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.OperationTypes.Queries.GetOperationTypes
{
    public class GetOperationTypesQueryHandler : IRequestHandler<GetOperationTypesQuery, PagedResult<OperationTypeDto>>
    {
        private readonly IRepository<OperationType> _operationtypeRepository;
        private readonly IMapper _mapper;

        public GetOperationTypesQueryHandler(IMapper mapper,
            IRepository<OperationType> operationtypeRepository)
        {
            _operationtypeRepository = operationtypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<OperationTypeDto>> Handle(
        GetOperationTypesQuery request,
        CancellationToken cancellationToken)
        {
            var operationtypes = await _operationtypeRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<OperationTypeDto>>(operationtypes);
        }
    }
}

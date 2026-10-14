using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.OperationTypes.DTOs;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.OperationTypes.Queries.GetOperationTypeById
{
    public class GetOperationTypeByIdQueryHandler : IRequestHandler<GetOperationTypeByIdQuery, OperationTypeDto>
    {
        private readonly IRepository<OperationType> _operationtypeRepository;
        private readonly IMapper _mapper;

        public GetOperationTypeByIdQueryHandler(IMapper mapper,
            IRepository<OperationType> operationtypeRepository)
        {
            _operationtypeRepository = operationtypeRepository;
            _mapper = mapper;
        }

        public async Task<OperationTypeDto> Handle(GetOperationTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var operationtype = await _operationtypeRepository.GetAsync(request.Id);

            if (operationtype == null)
                throw new NotFoundException("OperationType");

            return _mapper.Map<OperationTypeDto>(operationtype);

        }
    }
}

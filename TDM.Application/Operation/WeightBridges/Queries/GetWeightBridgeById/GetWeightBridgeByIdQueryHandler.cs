using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Application.Operation.WeightBridges.DTOs;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.WeightBridges.Queries.GetWeightBridgeById
{
  
    public class GetWeightBridgeByIdQueryHandler : IRequestHandler<GetWeightBridgeByIdQuery, WeightBridgeDto>
    {
        private readonly IRepository<WeightBridge> _weightBridgeRepository;
        private readonly IMapper _mapper;

        public GetWeightBridgeByIdQueryHandler(IMapper mapper,
            IRepository<WeightBridge> weightBridgeRepository)
        {
            _weightBridgeRepository = weightBridgeRepository;
            _mapper = mapper;
        }

        public async Task<WeightBridgeDto> Handle(GetWeightBridgeByIdQuery request, CancellationToken cancellationToken)
        {
            var weightBridge = await _weightBridgeRepository.GetAsync(request.Id);

            if (weightBridge == null)
                throw new NotFoundException("WeightBridge");

            return _mapper.Map<WeightBridgeDto>(weightBridge);

        }

    }
}

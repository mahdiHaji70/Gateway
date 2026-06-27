using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Application.Operation.WeightBridges.DTOs;


namespace TDM.Application.Operation.WeightBridges.Queries.GetWeightBridges
{
    public class GetWeightBridgesQueryHandler : IRequestHandler<GetWeightBridgesQuery, PagedResult<WeightBridgeDto>>
    {
        private readonly IWeightBridgeRepository _weightBridgeRepository;
        private readonly IMapper _mapper;

        public GetWeightBridgesQueryHandler(IMapper mapper,
            IWeightBridgeRepository weightBridgeRepository)
        {
            _weightBridgeRepository = weightBridgeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<WeightBridgeDto>> Handle(
        GetWeightBridgesQuery request,
        CancellationToken cancellationToken)
        {
            var WeightBridges = await _weightBridgeRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<WeightBridgeDto>>(WeightBridges);
        }
    }
}

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Application.Operation.Gates.DTOs;

namespace TDM.Application.Operation.Gates.Queries.GetGates
{
    public class GetGatesQueryHandler : IRequestHandler<GetGatesQuery, PagedResult<GateDto>>
    {
        private readonly IGateRepository _gateRepository;
        private readonly IMapper _mapper;

        public GetGatesQueryHandler(IMapper mapper,
            IGateRepository gateRepository)
        {
            _gateRepository = gateRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GateDto>> Handle(
        GetGatesQuery request,
        CancellationToken cancellationToken)
        {
            var Gates = await _gateRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<GateDto>>(Gates);
        }
    }
}

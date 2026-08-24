using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Application.Operation.TerminalDischarges.DTOs;

namespace TDM.Application.Operation.TerminalDischarges.Queries.GetGetTerminalDischarges
{
   
    public class GetTerminalDischargesQueryHandler : IRequestHandler<GetTerminalDischargesQuery, PagedResult<TerminalDischargeDto>>
    {
        private readonly ITerminalDischargeRepository _terminalDischargeRepository;
        private readonly IMapper _mapper;

        public GetTerminalDischargesQueryHandler(IMapper mapper,
            ITerminalDischargeRepository terminalDischargeRepository)
        {
            _terminalDischargeRepository = terminalDischargeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TerminalDischargeDto>> Handle(
        GetTerminalDischargesQuery request,
        CancellationToken cancellationToken)
        {
            var terminalDischarges = await _terminalDischargeRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<TerminalDischargeDto>>(terminalDischarges);
        }
    }
}

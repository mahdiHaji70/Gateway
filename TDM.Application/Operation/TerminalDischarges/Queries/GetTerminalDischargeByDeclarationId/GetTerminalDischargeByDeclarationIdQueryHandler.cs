using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Application.Operation.TerminalDischarges.DTOs;
using TDM.Application.Operation.TerminalDischarges.Queries.GetGetTerminalDischarges;

namespace TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeByIpasDeclarationNo
{

    public class GetTerminalDischargeByDeclarationIdQueryHandler : IRequestHandler<GetTerminalDischargeByDeclarationIdQuery, PagedResult<TerminalDischargeDto>>
    {
        private readonly ITerminalDischargeRepository _terminalDischargeRepository;
        private readonly IMapper _mapper;

        public GetTerminalDischargeByDeclarationIdQueryHandler(IMapper mapper,
            ITerminalDischargeRepository terminalDischargeRepository)
        {
            _terminalDischargeRepository = terminalDischargeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TerminalDischargeDto>> Handle(
             GetTerminalDischargeByDeclarationIdQuery request,
             CancellationToken cancellationToken)
        {
            var TerminalDischarges = await _terminalDischargeRepository.GetTerminalDischargesByDeclarationIdPagedAsync(request.declarationId, request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<TerminalDischargeDto>>(TerminalDischarges);
        }
    }
}

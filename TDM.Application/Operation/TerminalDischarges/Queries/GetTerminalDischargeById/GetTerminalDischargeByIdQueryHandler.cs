using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Application.Operation.TerminalDischarges.DTOs;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeById
{
    public class GetTerminalDischargeByIdQueryHandler : IRequestHandler<GetTerminalDischargeByIdQuery, TerminalDischargeDto>
    {
        private readonly ITerminalDischargeRepository _terminalDischargeRepository;
        private readonly IMapper _mapper;

        public GetTerminalDischargeByIdQueryHandler(IMapper mapper,
            ITerminalDischargeRepository terminalDischargeRepository)
        {
            _terminalDischargeRepository = terminalDischargeRepository;
            _mapper = mapper;
        }

        public async Task<TerminalDischargeDto> Handle(GetTerminalDischargeByIdQuery request, CancellationToken cancellationToken)
        {
            var terminalDischarge = await _terminalDischargeRepository.GetAsync(request.Id);

            if (terminalDischarge == null)
                throw new NotFoundException("Terminal discharge");

            return _mapper.Map<TerminalDischargeDto>(terminalDischarge);

        }

    }
}

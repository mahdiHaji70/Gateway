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
        private readonly IRepository<TerminalDischarge> _TerminalDischargeRepository;
        private readonly IMapper _mapper;

        public GetTerminalDischargeByIdQueryHandler(IMapper mapper,
            IRepository<TerminalDischarge> TerminalDischargeRepository)
        {
            _TerminalDischargeRepository = TerminalDischargeRepository;
            _mapper = mapper;
        }

        public async Task<TerminalDischargeDto> Handle(GetTerminalDischargeByIdQuery request, CancellationToken cancellationToken)
        {
            var TerminalDischarge = await _TerminalDischargeRepository.GetAsync(request.Id);

            if (TerminalDischarge == null)
                throw new NotFoundException("terminaldischarge");

            return _mapper.Map<TerminalDischargeDto>(TerminalDischarge);

        }

    }
}

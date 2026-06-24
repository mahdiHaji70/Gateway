using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Application.Operation.TerminalDischarges.DTOs;
using TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeById;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeByDeclarationNo
{
   
    public class GetTerminalDischargeByDeclarationNoQueryHandler : IRequestHandler<GetTerminalDischargeByDeclarationNoQuery, PagedResult<TerminalDischargeDto>>
    {
        private readonly IRepository<TerminalDischarge> _terminalDischargeRepository;
        private readonly IMapper _mapper;

        public GetTerminalDischargeByDeclarationNoQueryHandler(IMapper mapper,
            IRepository<TerminalDischarge> TerminalDischargeRepository)
        {
            _terminalDischargeRepository = TerminalDischargeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TerminalDischargeDto>>
            Handle(GetTerminalDischargeByDeclarationNoQuery request, CancellationToken cancellationToken)
        {
            var TerminalDischarges = await _terminalDischargeRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<TerminalDischargeDto>>(TerminalDischarges);


            throw new NotImplementedException();
        }

    }
}

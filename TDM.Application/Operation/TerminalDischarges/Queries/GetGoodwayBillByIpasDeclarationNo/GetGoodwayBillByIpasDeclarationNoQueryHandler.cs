using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TDM.Application.BasicInformation.DeclarationItems.Commands.RequestIpasDeclarationItems;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Application.Operation.TerminalDischarges.DTOs;
using TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeById;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeByDeclarationNo
{

    public class GetGoodwayBillByIpasDeclarationNoQueryHandler : IRequestHandler<GetGoodwayBillByIpasDeclarationNoQuery, IEnumerable<IpasGoodwayBillsResponse>>
    {
        private readonly ITerminalDischargeRepository _terminalDischargeRepository;
        private readonly IMapper _mapper;
        private readonly IDeclarationRepository _declarationRepository;
        private readonly ITerminalDischargeExternalService _terminalDischargeExternalService;



        public GetGoodwayBillByIpasDeclarationNoQueryHandler(IMapper mapper,
           ITerminalDischargeRepository terminalDischargeRepository,
           IDeclarationRepository declarationRepository,
           ITerminalDischargeExternalService terminalDischargeExternalService)
        {
            _terminalDischargeRepository = terminalDischargeRepository;
            _mapper = mapper;
            _declarationRepository = declarationRepository;
            _terminalDischargeExternalService = terminalDischargeExternalService;
        }

        public async Task<IEnumerable<IpasGoodwayBillsResponse>>
            Handle(GetGoodwayBillByIpasDeclarationNoQuery request, CancellationToken cancellationToken)
        {
            var declaration = await _declarationRepository.GetByIpasDeclarationNoAsync(request.ipasDeclarationNo);
            if (declaration == null)
                throw new Exception("Declaration not found");

            var ipasGoodwayBills =
                await _terminalDischargeExternalService.GetIpasGoodwayBills(
                    new IpasGoodwayBillsRequest(declaration.TerminalCode, declaration.IpasDeclarationId.Value));

            var terminalDischarges = await _terminalDischargeRepository.GetByDeclarationIdAsync(declaration.Id);
           
            var filteredIpasGoodwiyBills = ipasGoodwayBills
                                           .Where(newRecord => !terminalDischarges.Any
                                           (existing =>
                                            existing.TerminalCode == newRecord.TerminalCode &&
                                            existing.WayBillId == newRecord.WaybillId
                                            ))
                                        .ToList();

            return _mapper.Map<IEnumerable<IpasGoodwayBillsResponse>>(filteredIpasGoodwiyBills);
        }

    }
}

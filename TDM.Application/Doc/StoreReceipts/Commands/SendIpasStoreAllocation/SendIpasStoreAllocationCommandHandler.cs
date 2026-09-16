using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;

namespace TDM.Application.Doc.StoreReceipts.Commands.SendIpasStoreAllocation
{
    public class SendIpasStoreAllocationCommandHandler : MediatR.IRequestHandler<SendIpasStoreAllocationCommand, SendIpasStoreAllocationResponse>
    {
        private readonly IStoreReceiptHeadRepository _repository;
        private readonly IStoreReceiptExternalService _externalService;
        private readonly ITerminalDischargeRepository _terminalDischargeRepository;
        public SendIpasStoreAllocationCommandHandler(
            IStoreReceiptHeadRepository repository,
            IStoreReceiptExternalService externalService,
            ITerminalDischargeRepository terminalDischargeRepository)
        {
            _repository = repository;
            _externalService = externalService;
            _terminalDischargeRepository = terminalDischargeRepository;
        }

        public async Task<SendIpasStoreAllocationResponse> Handle(SendIpasStoreAllocationCommand request, CancellationToken cancellationToken)
        {
            var receipt = await _repository.GetForAllocationAsync(request.StoreReceiptId)
                ?? throw new KeyNotFoundException("Store receipt was not found.");
            if (receipt.RequestId.HasValue)
            {
                var terminalDischarges = await _terminalDischargeRepository
                    .GetByIssueRequestIdAsync(receipt.RequestId.Value);

                var allocationByDischarges = SendIpasStoreAllocationRequestMapper.Map(
                    receipt,
                    terminalDischarges);

                return await _externalService.SendIpasStoreAllocation(
                    allocationByDischarges,
                    cancellationToken);
            }

            var allocation = SendIpasStoreAllocationRequestMapper.Map(receipt);
            return await _externalService.SendIpasStoreAllocation(allocation, cancellationToken);
        }
    }
}

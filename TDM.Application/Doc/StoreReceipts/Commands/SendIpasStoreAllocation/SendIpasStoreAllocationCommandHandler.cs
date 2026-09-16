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
        public SendIpasStoreAllocationCommandHandler(
            IStoreReceiptHeadRepository repository,
            IStoreReceiptExternalService externalService)
        {
            _repository = repository;
            _externalService = externalService;
        }

        public async Task<SendIpasStoreAllocationResponse> Handle(SendIpasStoreAllocationCommand request, CancellationToken cancellationToken)
        {
            var receipt = await _repository.GetForAllocationAsync(request.StoreReceiptId)
                ?? throw new KeyNotFoundException("Store receipt was not found.");
            var allocation = SendIpasStoreAllocationRequestMapper.Map(receipt);
            return await _externalService.SendIpasStoreAllocation(allocation, cancellationToken);
        }
    }
}

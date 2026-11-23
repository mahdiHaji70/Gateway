using MediatR;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Enums;

namespace TDM.Application.Doc.StoreReceipts.Commands.SendLandExitDeliveryToIpas
{
    public class SendLandExitDeliveryToIpasCommandHandler
        : IRequestHandler<SendLandExitDeliveryToIpasCommand, SendLandExitDeliveryToIpasResponse>
    {
        private readonly IStoreExitDocumentRepository _repository;
        private readonly IStoreReceiptExternalService _externalService;
        private readonly IUnitOfWork _unitOfWork;

        public SendLandExitDeliveryToIpasCommandHandler(
            IStoreExitDocumentRepository repository,
            IStoreReceiptExternalService externalService,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _externalService = externalService;
            _unitOfWork = unitOfWork;
        }

        public async Task<SendLandExitDeliveryToIpasResponse> Handle(
            SendLandExitDeliveryToIpasCommand request, CancellationToken cancellationToken)
        {
            var document = await _repository.GetForLandDeliveryAsync(request.StoreExitDocumentId, cancellationToken)
                ?? throw new NotFoundException("Store exit document");

            if (document.IpasDeliveryId.HasValue && document.IpasDeliveryId != Guid.Empty)
                throw new Exception("This store exit document has already been sent to IPAS.");

            if (!document.LoadingPermitId.HasValue || document.LoadingPermitId == Guid.Empty)
                throw new Exception("The exit document has no loading permit.");
            if (string.IsNullOrWhiteSpace(document.VehicleNumber) || document.IssueDate == default)
                throw new Exception("Exit document vehicle number and issue date are required.");

            var operations = document.StoreReceiptOperations.ToList();
            if (operations.Count == 0)
                throw new Exception("The exit document has no receipt operations.");
            if (operations.Select(x => new { x.StoreReceiptHeadId, x.StoreId }).Distinct().Count() != 1)
                throw new Exception("A delivery must belong to one store receipt and storage area.");

            var firstOperation = operations[0];
            var receipt = firstOperation.StoreReceiptHead;
            if (string.IsNullOrWhiteSpace(receipt.TerminalCode) || string.IsNullOrWhiteSpace(firstOperation.Store.Code))
                throw new Exception("Terminal and storage area codes are required.");
            if (receipt.CargoTypeId != CargoTypes.GeneralCargo && receipt.CargoTypeId != CargoTypes.Bulk && receipt.CargoTypeId != CargoTypes.Container)
                throw new Exception("Only general, bulk and container cargo are supported by this command.");
          

            var delivery = SendLandExitDeliveryToIpasRequestMapper.Map(document);
            var response = await _externalService.SendLandExitDeliveryToIpas(delivery, cancellationToken);
            if (response.IsSent)
            {
                document.IpasDeliveryId = response.IpasDeliveryId;
                document.IpasDeliverySerialNo = response.IpasDeliverySerialNo;
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return response;
        }
    }
}

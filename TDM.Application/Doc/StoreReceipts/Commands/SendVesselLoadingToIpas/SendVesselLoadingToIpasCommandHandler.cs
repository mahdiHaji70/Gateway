using MediatR;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Enums;

namespace TDM.Application.Doc.StoreReceipts.Commands.SendVesselLoadingToIpas
{
    public class SendVesselLoadingToIpasCommandHandler
        : IRequestHandler<SendVesselLoadingToIpasCommand, SendVesselLoadingToIpasResponse>
    {
        private readonly IStoreExitDocumentRepository _repository;
        private readonly IStoreReceiptExternalService _externalService;
        private readonly IUnitOfWork _unitOfWork;

        public SendVesselLoadingToIpasCommandHandler(IStoreExitDocumentRepository repository,
            IStoreReceiptExternalService externalService, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _externalService = externalService;
            _unitOfWork = unitOfWork;
        }

        public async Task<SendVesselLoadingToIpasResponse> Handle(
            SendVesselLoadingToIpasCommand request, CancellationToken cancellationToken)
        {
            var document = await _repository.GetForVesselLoadingAsync(request.StoreExitDocumentId, cancellationToken)
                ?? throw new NotFoundException("Store exit document");

            if (document.IpasVesselLoadingId.HasValue && document.IpasVesselLoadingId != Guid.Empty)
                throw new Exception("This store exit document's vessel loading has already been sent to IPAS.");

            if (!document.VoyageId.HasValue || document.Voyage == null
                || !document.Voyage.IpasVoyageId.HasValue || document.Voyage.IpasVoyageId == Guid.Empty)
                throw new Exception("A synchronized voyage must be assigned to the store exit document.");

            if (string.IsNullOrWhiteSpace(document.VehicleNumber) || document.IssueDate == default)
                throw new Exception("Exit document vehicle number and issue date are required.");

            var operations = document.StoreReceiptOperations.ToList();
            if (operations.Count == 0)
                throw new Exception("The exit document has no receipt operations.");
            if (operations.Select(x => x.StoreReceiptHeadId).Distinct().Count() != 1)
                throw new Exception("Vessel loading must belong to one store receipt.");
            var receipt = operations[0].StoreReceiptHead;
            if (!receipt.DeclarationId.HasValue || receipt.Declaration == null)
                throw new Exception("The store receipt must be linked to a declaration for vessel loading.");
            if (string.IsNullOrWhiteSpace(receipt.TerminalCode))
                throw new Exception("Terminal code is required.");
            if (receipt.CargoTypeId != CargoTypes.GeneralCargo && receipt.CargoTypeId != CargoTypes.Bulk
                && receipt.CargoTypeId != CargoTypes.Container)
                throw new Exception("Only general, bulk and container cargo are supported by this command.");

            foreach (var operation in operations)
            {
                if (receipt.CargoTypeId == CargoTypes.Container)
                {
                    var container = operation.StoreReceiptContainer;
                    if (!operation.StoreReceiptContainerId.HasValue || container?.Container == null
                        || string.IsNullOrWhiteSpace(container.Container.No))
                        throw new Exception("The exit operation must reference a container with a valid number.");
                    if (container.StoreReceiptHeadId != operation.StoreReceiptHeadId)
                        throw new Exception("The operation's container does not belong to its store receipt.");
                }
                else if (!operation.StoreReceiptGoodId.HasValue || operation.StoreReceiptGood == null
                    || operation.StoreReceiptGood.StoreReceiptHeadId != operation.StoreReceiptHeadId)
                    throw new Exception("The exit operation must reference a good belonging to its store receipt.");
            }

            var loading = SendVesselLoadingToIpasRequestMapper.Map(document);
            var response = await _externalService.SendVesselLoadingToIpas(loading, cancellationToken);
            if (response.IsSent)
            {
                document.IpasVesselLoadingId = response.IpasVesselLoadingId;
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
            return response;
        }
    }
}

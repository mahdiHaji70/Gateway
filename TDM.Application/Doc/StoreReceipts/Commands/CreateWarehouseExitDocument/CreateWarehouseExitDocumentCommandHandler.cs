using MediatR;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;
using TDM.Domain.Enums;

namespace TDM.Application.Doc.StoreReceipts.Commands.CreateWarehouseExitDocument
{
    public class CreateWarehouseExitDocumentCommandHandler
        : IRequestHandler<CreateWarehouseExitDocumentCommand, Guid>
    {
        private readonly IStoreReceiptOperationRepository _storeReceiptOperationRepository;
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IRepository<WarehouseExitDocument> _warehouseExitDocumentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateWarehouseExitDocumentCommandHandler(
            IStoreReceiptOperationRepository storeReceiptOperationRepository,
            IOperationTypeRepository operationTypeRepository,
            IServiceRepository serviceRepository,
            IRepository<WarehouseExitDocument> warehouseExitDocumentRepository,
            IUnitOfWork unitOfWork)
        {
            _storeReceiptOperationRepository = storeReceiptOperationRepository;
            _operationTypeRepository = operationTypeRepository;
            _serviceRepository = serviceRepository;
            _warehouseExitDocumentRepository = warehouseExitDocumentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
            CreateWarehouseExitDocumentCommand request,
            CancellationToken cancellationToken)
        {
            var parentDischarge = await _storeReceiptOperationRepository
                .GetEarliestDischargeOperationAsync(request.StoreReceiptId, cancellationToken);

            if (parentDischarge == null)
                throw new NotFoundException($"Discharge operation for store receipt '{request.StoreReceiptId}'");

            var operationTypeCode = OperationTypeCode.EFS.ToString();
            var operationType = (await _operationTypeRepository.GetByCodesAsync(
                new[] { operationTypeCode }, cancellationToken)).FirstOrDefault();
            if (operationType == null)
                throw new NotFoundException($"Operation type with code '{operationTypeCode}'");

            var serviceCode = ServiceCode.STRG.ToString();
            var service = (await _serviceRepository.GetByCodesAsync(
                new[] { serviceCode }, cancellationToken)).FirstOrDefault();
            if (service == null)
                throw new NotFoundException($"Service with code '{serviceCode}'");

            var warehouseExitDocument = new WarehouseExitDocument
            {
                Serial = Guid.NewGuid().ToString("N"),
                VehicleNumber = request.VehicleNumber.Trim(),
                IssueDate = request.Date,
                LoadingPermitId = request.LoadingPermitId
            };

            var operation = new StoreReceiptOperation(
                parentId: parentDischarge.Id,
                storeReceiptHeadId: request.StoreReceiptId,
                storeReceiptContainerId: parentDischarge.StoreReceiptContainerId,
                operationTypeId: operationType.Id,
                serviceId: service.Id,
                storeId: parentDischarge.StoreId,
                date: request.Date,
                packNb: request.PackNb,
                weight: request.Weight,
                volume: 0,
                isNonPalletized: false,
                isDamaged: false,
                isVoluminous: false,
                isDangerous: false,
                dangerousCode: string.Empty,
                classification: string.Empty,
                ignitionTemperature: 0,
                ignitionTemperatureUnit: string.Empty,
                unitWeight: 0);
            operation.AttachToWarehouseExitDocument(warehouseExitDocument);

            await _warehouseExitDocumentRepository.InsertAsync(warehouseExitDocument);
            await _storeReceiptOperationRepository.InsertAsync(operation);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return warehouseExitDocument.Id;
        }
    }
}

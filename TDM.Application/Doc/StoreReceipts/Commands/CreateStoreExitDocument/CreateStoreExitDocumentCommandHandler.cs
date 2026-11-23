using MediatR;
using System.Globalization;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;
using TDM.Domain.Enums;

namespace TDM.Application.Doc.StoreReceipts.Commands.CreateStoreExitDocument
{
    public class CreateStoreExitDocumentCommandHandler
        : IRequestHandler<CreateStoreExitDocumentCommand, Guid>
    {
        private readonly IStoreReceiptOperationRepository _storeReceiptOperationRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserTerminalRepository _userTerminalRepository;
        private readonly IDocumentSerialCounterRepository _serialCounterRepository;
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IRepository<StoreExitDocument> _storeExitDocumentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStoreExitDocumentCommandHandler(
            IStoreReceiptOperationRepository storeReceiptOperationRepository,
            ICurrentUserService currentUserService,
            IUserTerminalRepository userTerminalRepository,
            IDocumentSerialCounterRepository serialCounterRepository,
            IOperationTypeRepository operationTypeRepository,
            IServiceRepository serviceRepository,
            IRepository<StoreExitDocument> storeExitDocumentRepository,
            IUnitOfWork unitOfWork)
        {
            _storeReceiptOperationRepository = storeReceiptOperationRepository;
            _currentUserService = currentUserService;
            _userTerminalRepository = userTerminalRepository;
            _serialCounterRepository = serialCounterRepository;
            _operationTypeRepository = operationTypeRepository;
            _serviceRepository = serviceRepository;
            _storeExitDocumentRepository = storeExitDocumentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
            CreateStoreExitDocumentCommand request,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(_currentUserService.NationalId))
                throw new UnauthorizedAccessException("The authenticated user has no national ID.");

            var userTerminal = await _userTerminalRepository.GetByNationalId(_currentUserService.NationalId);
            if (userTerminal?.Terminal == null || string.IsNullOrWhiteSpace(userTerminal.Terminal.Code))
                throw new NotFoundException("Terminal assigned to current user");

            var authorizedTerminalCode = userTerminal.Terminal.Code.Trim();
            if (authorizedTerminalCode.Length != 3 || authorizedTerminalCode.Any(character => !char.IsDigit(character)))
                throw new InvalidOperationException("The current user's terminal code must contain exactly three digits.");

            var parentDischarge = await _storeReceiptOperationRepository
                .GetEarliestDischargeOperationAsync(
                    request.StoreReceiptId,
                    authorizedTerminalCode,
                    cancellationToken);

            if (parentDischarge == null)
                throw new NotFoundException($"Discharge operation for store receipt '{request.StoreReceiptId}'");

            var terminalCode = parentDischarge.StoreReceiptHead.TerminalCode.Trim();

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

            var jalaliYear = new PersianCalendar().GetYear(request.Date);
            const DocumentSerialType serialType = DocumentSerialType.StoreExit;
            var serialPrefix = DocumentSerialTypeCode.ToCode(serialType);

            var counter = await _serialCounterRepository.GetNextCounterAsync(
                serialType,
                terminalCode,
                jalaliYear,
                cancellationToken);
            var serial = $"{serialPrefix}{terminalCode}{jalaliYear:D4}{counter.ToString(CultureInfo.InvariantCulture)}";

            var storeExitDocument = new StoreExitDocument
            {
                Serial = serial,
                VehicleNumber = request.VehicleNumber.Trim(),
                IssueDate = request.Date,
                LoadingPermitId = request.LoadingPermitId,
                VoyageId = request.VoyageId
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
                unitWeight: 0,
                storeReceiptGoodId: parentDischarge.StoreReceiptGoodId);
            operation.AttachToStoreExitDocument(storeExitDocument);

            await _storeExitDocumentRepository.InsertAsync(storeExitDocument);
            await _storeReceiptOperationRepository.InsertAsync(operation);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return storeExitDocument.Id;
        }
    }
}

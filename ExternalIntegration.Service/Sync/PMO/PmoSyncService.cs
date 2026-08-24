using AutoMapper;
using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Client;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace ExternalIntegration.Service.Sync.PMO
{
    public class PmoSyncService : IPmoSyncService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPmoClient _client;
        private readonly IMapper _mapper;
        private readonly IGoodwayBillRepository _goodwayBillRepository;
        private readonly IDischargePermitRepository _dischargePermitRepository;
        private readonly IIssueRequestRepository _issueRequestRepository;
        private readonly IVoyageRepository _voyageRepository;
        private readonly IStoreReceiptRepository _storeReceiptRepository;
        private readonly IManifestRepository _manifestRepository;
        private readonly IManifestChangeRepository _manifestChangeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PmoSyncService(IHttpContextAccessor httpContextAccessor, IPmoClient client
            , IMapper mapper
            , IUnitOfWork unitOfWork
            , IGoodwayBillRepository goodwayBillRepository
            , IDischargePermitRepository dischargePermitRepository
            , IIssueRequestRepository issueRequestRepository
            , IVoyageRepository voyageRepository
            , IStoreReceiptRepository storeReceiptRepository
            , IManifestRepository manifestRepository
            , IManifestChangeRepository manifestChangeRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _client = client;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _goodwayBillRepository = goodwayBillRepository;
            _dischargePermitRepository = dischargePermitRepository;
            _issueRequestRepository = issueRequestRepository;
            _voyageRepository = voyageRepository;
            _storeReceiptRepository = storeReceiptRepository;
            _manifestRepository = manifestRepository;
            _manifestChangeRepository = manifestChangeRepository;
        }
        public async Task<Response<IEnumerable<GoodwayBillDto>>> GetGoodwayBill(DateRangeDto dto)
        {
            DateTime localFromDate = DateTime.Now;
            DateTime localToDate = DateTime.Now;
            if (dto.FromDate == null)
                localFromDate = await _goodwayBillRepository.GetLastDateAsync(dto.TerminalCode);
            if (dto.ToDate == null)
                localToDate = DateTime.Now.AddDays(1);

            var pmoDateDto = new PmoDateRangeDto(
                dto.TerminalCode,
                dto.FromDate ?? localFromDate,
                dto.ToDate ?? localToDate,
                dto.PortCode);

            var clientResult = await _client.GetGoodwayBill(pmoDateDto);

            var syncMappingDto = _mapper.Map<Response<IEnumerable<GoodwayBillDto>>>(clientResult);

            var newData = await _goodwayBillRepository.FilterUnpersistedAsync(
                entities: _mapper.Map<IEnumerable<GoodwayBill>>(syncMappingDto.Data),
                idSelector: t => t.Id,
                dbIdSelector: t => t.Id
            );

            await _goodwayBillRepository.InsertBulkAsync(newData);
            await _unitOfWork.SaveChangesAsync();

            return syncMappingDto;
        }

        public async Task<Response<CreateStorageAgreementResultDto>> CreateStorageAgreement(CreateStorageAgreementDto dto)
        {

            var syncMappingRequestDto = _mapper.Map<CreateStorageAgreementRequestDto>(dto);
            var clientResult = await _client.CreateStorageAgreement(syncMappingRequestDto);
            var syncMappingDto = _mapper.Map<Response<CreateStorageAgreementResultDto>>(clientResult);
            return syncMappingDto;
        }

        public async Task<Response<StorageAgreementResultDto>> GetStorageAgreement(GetStorageAgreementDto dto)
        {
            var clientResult = await _client.GetStorageAgreement(dto);
            var syncMappingDto = _mapper.Map<Response<StorageAgreementResultDto>>(clientResult);
            return syncMappingDto;
        }

        public async Task<Response<bool>> DeleteStorageAgreement(DeleteStorageAgreementDto dto)
        {
            var clientResult = await _client.DeleteStorageAgreement(dto);
            return clientResult;
        }
        public async Task<Response<IEnumerable<DischargePermitDto>>> GetDischargePermit(DateRangeDto dto)
        {
            DateTime localFromDate = DateTime.Now;
            DateTime localToDate = DateTime.Now;
            if (dto.FromDate == null)
                localFromDate = await _dischargePermitRepository.GetLastDateAsync(dto.TerminalCode);
            if (dto.ToDate == null)
                localToDate = DateTime.Now.AddDays(1);

            var pmoDateDto = new PmoDateRangeDto(
                dto.TerminalCode,
                dto.FromDate ?? localFromDate,
                dto.ToDate ?? localToDate,
                dto.PortCode);

            var clientResult = await _client.GetDischargePermit(pmoDateDto);

            var syncMappingDto = _mapper.Map<Response<IEnumerable<DischargePermitDto>>>(clientResult);

            var newData = await _dischargePermitRepository.FilterUnpersistedAsync(
                entities: _mapper.Map<IEnumerable<DischargePermit>>(syncMappingDto.Data),
                idSelector: t => t.Id,
                dbIdSelector: t => t.Id
            );

            await _dischargePermitRepository.InsertBulkAsync(newData);
            await _unitOfWork.SaveChangesAsync();

            return syncMappingDto;
        }
        public async Task<Response<Guid>> SubmitTruckTerminalDischarge(TruckTerminalDischargeDto dto)
        {
            var syncMappingRequestDto = _mapper.Map<TruckTerminalDischargeRequestDto>(dto);
            var clientResult = await _client.TruckTerminalDischarge(syncMappingRequestDto);
            var syncMappingDto = _mapper.Map<Response<Guid>>(clientResult);
            return syncMappingDto;
        }
        public async Task<Response<IEnumerable<IssueRequestDto>>> GetIssueRequest(DateRangeDto dto)
        {
            DateTime localFromDate = DateTime.Now;
            DateTime localToDate = DateTime.Now;
            if (dto.FromDate == null)
                localFromDate = await _issueRequestRepository.GetLastDateAsync(dto.TerminalCode);
            if (dto.ToDate == null)
                localToDate = DateTime.Now.AddDays(1);

            var pmoDateDto = new PmoDateRangeDto(
                dto.TerminalCode,
                dto.FromDate ?? localFromDate,
                dto.ToDate ?? localToDate,
                dto.PortCode);

            var clientResult = await _client.GetIssueRequest(pmoDateDto);

            var syncMappingDto = _mapper.Map<Response<IEnumerable<IssueRequestDto>>>(clientResult);

            var newData = await _issueRequestRepository.FilterUnpersistedAsync(
                entities: _mapper.Map<IEnumerable<IssueRequest>>(syncMappingDto.Data),
                idSelector: t => t.Id,
                dbIdSelector: t => t.Id
            );

            await _issueRequestRepository.InsertBulkAsync(newData);
            await _unitOfWork.SaveChangesAsync();

            return syncMappingDto;
        }

        public async Task<Response<IEnumerable<VoyageDto>>> GetVoyages([FromBody] DateRangeWithPagingDto dto)
        {
            DateTime localFromDate = DateTime.Now;
            DateTime localToDate = DateTime.Now;
            if (dto.FromDate == null)
                localFromDate = await _voyageRepository.GetLastDateAsync();
            if (dto.ToDate == null)
                localToDate = DateTime.Now.AddDays(1);

            var pmoDateDto = new PmoDateRangeWithPagingDto(
                dto.TerminalCode,
                dto.FromDate ?? localFromDate,
                dto.ToDate ?? localToDate,
                dto.PortCode,
                dto.PageIndex,
                dto.PageSize);

            var clientResult = await _client.GetVoyages(pmoDateDto);

            var syncMappingDto = _mapper.Map<Response<IEnumerable<VoyageDto>>>(clientResult.Data.Items);

            var newData = await _voyageRepository.FilterUnpersistedAsync(
                entities: _mapper.Map<IEnumerable<Voyage>>(clientResult.Data.Items),
                idSelector: t => t.Id,
                dbIdSelector: t => t.Id
            );

            await _voyageRepository.InsertBulkAsync(newData);
            await _unitOfWork.SaveChangesAsync();

            return syncMappingDto;
        }

        public async Task<Response<VoyageDto>> GetVoyageByNoticeNo(VoyageByNoticeNoDto dto)
        {

            var syncMappingRequestDto = _mapper.Map<VoyageByNoticeNoRequestDto>(dto);
            var clientResult = await _client.GetVoyageByNoticeNo(syncMappingRequestDto);
            var syncMappingDto = _mapper.Map<Response<VoyageDto>>(clientResult);

            var newData = await _voyageRepository.FilterUnpersistedAsync(
                entities: _mapper.Map<IEnumerable<Voyage>>(syncMappingDto.Data),
                idSelector: t => t.Id,
                dbIdSelector: t => t.Id
            );

            await _voyageRepository.InsertBulkAsync(newData);
            await _unitOfWork.SaveChangesAsync();

            return syncMappingDto;
        }

        public async Task<Response<string>> IssueRequestConfirmation(IssueRequestConfirmationDto dto)
        {
            var syncMappingRequestDto = _mapper.Map<IssueRequestConfirmationRequestDto>(dto);
            var clientResult = await _client.IssueRequestConfirmation(syncMappingRequestDto);
            if (clientResult.Status != ResponseStatuses.Error)
                _issueRequestRepository.UpdateIssueRequestApprovalAsync(dto.RequestId, dto.IsApproved);

            var syncMappingDto = _mapper.Map<Response<string>>(clientResult);
            return syncMappingDto;
        }

        public async Task<Response<IEnumerable<StoreReceiptDto>>> GetStoreReceipts(DateRangeWithPagingDto dto)
        {
            DateTime localFromDate = DateTime.Now;
            DateTime localToDate = DateTime.Now;
            if (dto.FromDate == null)
                localFromDate = await _storeReceiptRepository.GetLastDateAsync(dto.TerminalCode);
            if (dto.ToDate == null)
                localToDate = DateTime.Now.AddDays(1);

            var pmoDateDto = new PmoDateRangeWithPagingDto(
                dto.TerminalCode,
                dto.FromDate ?? localFromDate,
                dto.ToDate ?? localToDate,
                dto.PortCode,
                dto.PageIndex,
                dto.PageSize);

            var clientResult = await _client.GetStoreReceipts(pmoDateDto);
            var syncMappingDto = _mapper.Map<Response<IEnumerable<StoreReceiptDto>>>(clientResult);

            var newData = await _storeReceiptRepository.FilterUnpersistedAsync(
                entities: _mapper.Map<IEnumerable<StoreReceipt>>(syncMappingDto.Data),
                idSelector: t => t.Id,
                dbIdSelector: t => t.Id
            );

            await _storeReceiptRepository.InsertBulkAsync(newData);
            await _unitOfWork.SaveChangesAsync();

            return syncMappingDto;
        }

        public async Task<Response<bool>> SendStoreReceiptAllocation(SendStoreReceiptAllocationDto dto)
        {
            var syncMappingRequestDto = _mapper.Map<SendStoreReceiptAllocationRequestDto>(dto);
            var clientResult = await _client.SendStoreReceiptAllocation(syncMappingRequestDto);
            return clientResult;
        }

        public async Task<Response<IEnumerable<ManifestDto>>> GetManifests(DateRangeWithPagingDto dto)
        {
            DateTime localFromDate = DateTime.Now;
            DateTime localToDate = DateTime.Now;
            if (dto.FromDate == null)
                localFromDate = await _manifestRepository.GetLastDateAsync(dto.TerminalCode);
            if (dto.ToDate == null)
                localToDate = DateTime.Now.AddDays(1);

            var pmoDateDto = new PmoDateRangeWithPagingDto(
                dto.TerminalCode,
                dto.FromDate ?? localFromDate,
                dto.ToDate ?? localToDate,
                dto.PortCode,
                dto.PageIndex,
                dto.PageSize);

            var clientResult = await _client.GetManifests(pmoDateDto);
            var syncMappingDto = _mapper.Map<Response<IEnumerable<ManifestDto>>>(clientResult);

            var newData = await _manifestRepository.FilterUnpersistedAsync(
                entities: _mapper.Map<IEnumerable<Manifest>>(syncMappingDto.Data),
                idSelector: t => t.Id,
                dbIdSelector: t => t.Id
            );

            await _manifestRepository.InsertBulkAsync(newData);
            await _unitOfWork.SaveChangesAsync();

            return syncMappingDto;
        }

        public async Task<Response<IEnumerable<ManifestChangeDto>>> GetManifestChanges(DateRangeWithPagingDto dto)
        {
            DateTime localFromDate = DateTime.Now;
            DateTime localToDate = DateTime.Now;
            if (dto.FromDate == null)
                localFromDate = await _manifestChangeRepository.GetLastDateAsync(dto.TerminalCode);
            if (dto.ToDate == null)
                localToDate = DateTime.Now.AddDays(1);

            var pmoDateDto = new PmoDateRangeWithPagingDto(
                dto.TerminalCode,
                dto.FromDate ?? localFromDate,
                dto.ToDate ?? localToDate,
                dto.PortCode,
                dto.PageIndex,
                dto.PageSize);

            var clientResult = await _client.GetManifestChanges(pmoDateDto);
            var syncMappingDto = _mapper.Map<Response<IEnumerable<ManifestChangeDto>>>(clientResult);

            var newData = await _manifestChangeRepository.FilterUnpersistedAsync(
                entities: _mapper.Map<IEnumerable<ManifestChange>>(syncMappingDto.Data),
                idSelector: t => t.Id,
                dbIdSelector: t => t.Id
            );

            await _manifestChangeRepository.InsertBulkAsync(newData);
            await _unitOfWork.SaveChangesAsync();

            return syncMappingDto;
        }

        public async Task<Response<ManifestDto>> GetManifestById(Guid id, string terminalCode)
        {
            var clientResult = await _client.GetManifestById(id, terminalCode);
            var syncMappingDto = _mapper.Map<Response<ManifestDto>>(clientResult);

            var manifest = await _manifestRepository.GetAsync(id);
            if(manifest == null)
                return Response<ManifestDto>.Error($"Manifest with ID '{id}' was not found.");

            _manifestRepository.Delete(manifest);
            await _manifestRepository.InsertAsync(manifest);
            await _unitOfWork.SaveChangesAsync();

            return syncMappingDto;
        }

        public async Task<Response<Guid>> SendVesselDischarge(VesselDischargeDto dto)
        {
            var syncMappingRequestDto = _mapper.Map<VesselDischargeRequestDto>(dto);
            var clientResult = await _client.SendVesselDischarge(syncMappingRequestDto);
            var syncMappingDto = _mapper.Map<Response<Guid>>(clientResult);
            return syncMappingDto;
        }
    }
}

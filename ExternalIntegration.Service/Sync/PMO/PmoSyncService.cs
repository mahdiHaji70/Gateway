using AutoMapper;
using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Client;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests;
using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Sync.PMO
{
    public class PmoSyncService : IPmoSyncService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPmoClient _client;
        private readonly IMapper _mapper;
        private readonly IRepository<GoodwayBill> _goodwayBillRepository;
        private readonly IRepository<DischargePermit> _dischargePermitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PmoSyncService(IHttpContextAccessor httpContextAccessor, IPmoClient client
            ,IMapper mapper
            ,IUnitOfWork unitOfWork
            ,IRepository<GoodwayBill> goodwayBillRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _client = client;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _goodwayBillRepository = goodwayBillRepository;
        }
        public async Task<Response<IEnumerable<GoodwayBillDto>>> GetGoodwayBill(DateRangeDto dto)
        {
          
            var clientResult = await _client.GetGoodwayBill(dto);

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

        public  async   Task<Response<CreateStorageAgreementResultDto>> CreateStorageAgreement(CreateStorageAgreementDto dto)
        {

            var syncMappingRequestDto = _mapper.Map<CreateStorageAgreementRequestDto>(dto);
            var clientResult =await _client.CreateStorageAgreement(syncMappingRequestDto);
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

            var clientResult = await _client.GetDischargePermit(dto);

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

    }
}

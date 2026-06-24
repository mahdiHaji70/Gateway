using AutoMapper;
using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Sync.TDM
{
    public class TDMSyncService : ITDMSyncService
    {
        private readonly IMapper _mapper;
        private readonly IGoodwayBillRepository _goodwayBillRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TDMSyncService(IMapper mapper, IUnitOfWork unitOfWork
           , IGoodwayBillRepository goodwayBillRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _goodwayBillRepository = goodwayBillRepository;
        }
        public async Task<Response<IEnumerable<GoodwayBillDto>>> GetGoodwayBillByStorageAgreementId(Guid storageAgreementId)
        {
            var goodwayBills = await _goodwayBillRepository.GetByStorageAgreementIdAsync(storageAgreementId);
            var syncMappingDto = _mapper.Map<Response<IEnumerable<GoodwayBillDto>>>(goodwayBills);
            return syncMappingDto;

        }
    }
}

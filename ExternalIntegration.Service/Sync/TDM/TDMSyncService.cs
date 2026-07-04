using AutoMapper;
using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<Response<IEnumerable<GoodwayBillDto>>> GetGoodwayBillByStorageAgreementId(Guid storageAgreementId, string terminalCode)
        {
            var goodwayBills = await _goodwayBillRepository.GetByStorageAgreementIdAsync( storageAgreementId,  terminalCode);
            var syncMappingDto2 = _mapper.Map<List<GoodwayBillDto>>(goodwayBills);

            var syncMappingDto = _mapper.Map<Response<IEnumerable<GoodwayBillDto>>>(goodwayBills);
            return syncMappingDto;

        }
    }
}

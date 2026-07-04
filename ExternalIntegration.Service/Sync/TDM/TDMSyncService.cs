using AutoMapper;
using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            if (goodwayBills == null)
                return Response<IEnumerable<GoodwayBillDto>>.Error("Not Found");
            return Response<IEnumerable<GoodwayBillDto>>.Success(_mapper.Map<IEnumerable<GoodwayBillDto>>(goodwayBills));
        }
    }
}

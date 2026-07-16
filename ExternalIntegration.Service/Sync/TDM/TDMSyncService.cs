using AutoMapper;
using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExternalIntegration.Service.Sync.TDM
{
    public class TDMSyncService : ITDMSyncService
    {
        private readonly IMapper _mapper;
        private readonly IGoodwayBillRepository _goodwayBillRepository;
        private readonly IIssueRequestRepository _IssueRequestRepository;
        private readonly IStoreReceiptRepository _storeReceiptRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TDMSyncService(IMapper mapper, IUnitOfWork unitOfWork
           , IGoodwayBillRepository goodwayBillRepository
           , IIssueRequestRepository issueRequestRepository
           , IStoreReceiptRepository storerReceiptRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _goodwayBillRepository = goodwayBillRepository;
            _IssueRequestRepository = issueRequestRepository;
            _storeReceiptRepository= storerReceiptRepository;
        }
        public async Task<Response<IEnumerable<GoodwayBillDto>>> GetGoodwayBillByStorageAgreementId(Guid storageAgreementId, string terminalCode)
        {
            var goodwayBills = await _goodwayBillRepository.GetByStorageAgreementIdAsync( storageAgreementId,  terminalCode);

            if (goodwayBills == null)
                return Response<IEnumerable<GoodwayBillDto>>.Error("Not Found");
            return Response<IEnumerable<GoodwayBillDto>>.Success(_mapper.Map<IEnumerable<GoodwayBillDto>>(goodwayBills));
        }
        public async Task<Response<IEnumerable<IssueRequestDto>>> GetIssueRequest(string storageAgreementNo)
        {
            var result = await _IssueRequestRepository.GetByStorageAgreementNoAsync(storageAgreementNo);

            if (result == null)
                return Response<IEnumerable<IssueRequestDto>>.Error("Not Found");

            return Response<IEnumerable<IssueRequestDto>>.Success(_mapper.Map<IEnumerable<IssueRequestDto>>(result));
        }
     
       public async Task<Response<IEnumerable<StoreReceiptDto>>> GetStoreReceiptByStorageAgreementNo(string storageAgreementNo)
        {
            var result = await _storeReceiptRepository.GetByStorageAgreementNoAsync(storageAgreementNo);

            if (result == null)
                return Response<IEnumerable<StoreReceiptDto>>.Error("Not Found");

            return Response<IEnumerable<StoreReceiptDto>>.Success(_mapper.Map<IEnumerable<StoreReceiptDto>>(result));

        }
        public async Task<Response<StoreReceiptDto>> GetStoreReceiptByNo(string no)
        {
            var result = await _storeReceiptRepository.GetByNoAsync(no);

            if (result == null)
                return Response<StoreReceiptDto>.Error("Not Found");

            return Response<StoreReceiptDto>.Success(_mapper.Map<StoreReceiptDto>(result));

        }
    }
}

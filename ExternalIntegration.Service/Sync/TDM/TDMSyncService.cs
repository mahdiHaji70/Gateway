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
        private readonly IDischargePermitRepository _dischargePermitRepository;
        private readonly IGoodwayBillRepository _goodwayBillRepository;
        private readonly IIssueRequestRepository _issueRequestRepository;
        private readonly IVoyageRepository _voyageRepository;
        private readonly IStoreReceiptRepository _storeReceiptRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TDMSyncService(IMapper mapper, IUnitOfWork unitOfWork,
            IDischargePermitRepository dischargePermitRepository
           , IGoodwayBillRepository goodwayBillRepository
           , IIssueRequestRepository issueRequestRepository,
            IVoyageRepository voyageRepository
           , IStoreReceiptRepository storerReceiptRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _dischargePermitRepository = dischargePermitRepository;
            _goodwayBillRepository = goodwayBillRepository;
            _issueRequestRepository = issueRequestRepository;
            _voyageRepository = voyageRepository;
            _storeReceiptRepository = storerReceiptRepository;
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
            var result = await _issueRequestRepository.GetByStorageAgreementNoAsync(storageAgreementNo);

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

        public async Task<Response<DateTime>> GetDischargePermitsLastDate(string terminalCode)
        {
            var lastDate = await _dischargePermitRepository.GetLastDateAsync(terminalCode);
            if (lastDate.Equals(DateTime.MinValue))
                return Response<DateTime>.Error("No data found");
            return Response<DateTime>.Success(lastDate);
        }

        public async Task<Response<DateTime>> GetGoodwayBillsLastDate(string terminalCode)
        {
            var lastDate = await _goodwayBillRepository.GetLastDateAsync(terminalCode);
            if (lastDate.Equals(DateTime.MinValue))
                return Response<DateTime>.Error("No data found");
            return Response<DateTime>.Success(lastDate);
        }

        public async Task<Response<DateTime>> GetIssueRequestsLastDate(string terminalCode)
        {
            var lastDate = await _issueRequestRepository.GetLastDateAsync(terminalCode);
            if (lastDate.Equals(DateTime.MinValue))
                return Response<DateTime>.Error("No data found");
            return Response<DateTime>.Success(lastDate);
        }

        public async Task<Response<DateTime>> GetVoyagesLastDate()
        {
            var lastDate = await _voyageRepository.GetLastDateAsync();
            if (lastDate.Equals(DateTime.MinValue))
                return Response<DateTime>.Error("No data found");
            return Response<DateTime>.Success(lastDate);
        }

        public async Task<Response<DateTime>> GetStoreReceiptsLastDate(string terminalCode)
        {
            var lastDate = await _storeReceiptRepository.GetLastDateAsync(terminalCode);
            if (lastDate.Equals(DateTime.MinValue))
                return Response<DateTime>.Error("No data found");
            return Response<DateTime>.Success(lastDate);
        }
    }
}

using AutoMapper;
using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Application.DTOs;
using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Sync.DTOs;

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
        private readonly IManifestRepository _manifestRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TDMSyncService(IMapper mapper, IUnitOfWork unitOfWork,
            IDischargePermitRepository dischargePermitRepository
           , IGoodwayBillRepository goodwayBillRepository
           , IIssueRequestRepository issueRequestRepository,
            IVoyageRepository voyageRepository
           , IStoreReceiptRepository storerReceiptRepository
            , IManifestRepository manifestRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _dischargePermitRepository = dischargePermitRepository;
            _goodwayBillRepository = goodwayBillRepository;
            _issueRequestRepository = issueRequestRepository;
            _voyageRepository = voyageRepository;
            _storeReceiptRepository = storerReceiptRepository;
            _manifestRepository = manifestRepository;
        }
        public async Task<Response<IEnumerable<GoodwayBillDto>>> GetGoodwayBillByStorageAgreementId(Guid storageAgreementId, string terminalCode)
        {
            var goodwayBills = await _goodwayBillRepository.GetByStorageAgreementIdAsync(storageAgreementId, terminalCode);

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

        public async Task<Response<IEnumerable<ManifestNoticeToApproveDto>>> GetManifestsNoticeNoToApprove(string terminalCode)
        {
            var manifestsToApprove = await _manifestRepository.GetManifestsNoticeNoToApprove(terminalCode);
            if (manifestsToApprove == null && manifestsToApprove!.Count() == 0)
                return Response<IEnumerable<ManifestNoticeToApproveDto>>.Error("No data found");

            return Response<IEnumerable<ManifestNoticeToApproveDto>>.Success(manifestsToApprove);
        }

        public async Task<Response<ManifestDto>> GetManifestById(Guid id)
        {
            var manifest = await _manifestRepository.GetManifestById(id);
            if(manifest == null)
                return Response<ManifestDto>.Error($"Manifest with ID '{id}' was not found.");

            return Response<ManifestDto>.Success(_mapper.Map<ManifestDto>(manifest));

        }

        public async Task<Response<bool>> ApproveManifestAsync(Guid id)
        {
            var result = await _manifestRepository.ApproveManifestAsync(id);
            if(!result)
                return Response<bool>.Error("Manifest not found");

            await _unitOfWork.SaveChangesAsync();

            return Response<bool>.Success(result);          
        }
    }
}

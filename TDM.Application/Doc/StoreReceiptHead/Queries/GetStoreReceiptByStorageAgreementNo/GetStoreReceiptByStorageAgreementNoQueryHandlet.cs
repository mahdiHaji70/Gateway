using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.IssueRequestStoreReceipt.Queries.GetIssueRequestByStorageAgreementNo;

namespace TDM.Application.Doc.StoreReceipt.Queries.GetStoreReceiptByStorageAgreementNo
{
   
    public class GetStoreReceiptByStorageAgreementNoQueryHandlet : IRequestHandler<GetStoreReceiptByStorageAgreementNoQuery, IEnumerable<IpasStoreReceiptResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IDeclarationRepository _declarationRepository;
        private readonly IStoreReceiptExternalService _storeReceiptExternalService;

        public GetStoreReceiptByStorageAgreementNoQueryHandlet(IMapper mapper,
           IDeclarationRepository declarationRepository,
           IStoreReceiptExternalService storeReceiptExternalService)
        {
            _mapper = mapper;
            _declarationRepository = declarationRepository;
            _storeReceiptExternalService = storeReceiptExternalService;
        }

        public async Task<IEnumerable<IpasStoreReceiptResponse>>
            Handle(GetStoreReceiptByStorageAgreementNoQuery request, CancellationToken cancellationToken)
        {
            var declaration = await _declarationRepository.GetByIpasDeclarationNoAsync(request.ipasDeclarationNo);
            if (declaration == null)
                throw new Exception("Declaration not found");

            var ipasStoreReceipts =
                await _storeReceiptExternalService.GetStoreReceipts(request.ipasDeclarationNo);

            return _mapper.Map<IEnumerable<IpasStoreReceiptResponse>>(ipasStoreReceipts);
        }

    }
}

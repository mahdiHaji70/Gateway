using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeByDeclarationNo;

namespace TDM.Application.Doc.IssueRequestStoreReceipt.Queries.GetIssueRequestByStorageAgreementNo
{

    public class GetIssueRequestByStorageAgreementNoHandler : IRequestHandler<GetIssueRequestByStorageAgreementNoQuery, IEnumerable<IpasIssueRequestStoreReceiptResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IDeclarationRepository _declarationRepository;
        private readonly IIssueRequestStoreReceiptExternalService _issueRequestExternalService;

        public GetIssueRequestByStorageAgreementNoHandler(IMapper mapper,
           IDeclarationRepository declarationRepository,
           IIssueRequestStoreReceiptExternalService issueRequestExternalService)
        {
            _mapper = mapper;
            _declarationRepository = declarationRepository;
            _issueRequestExternalService = issueRequestExternalService;
        }

        public async Task<IEnumerable<IpasIssueRequestStoreReceiptResponse>>
            Handle(GetIssueRequestByStorageAgreementNoQuery request, CancellationToken cancellationToken)
        {
            var declaration = await _declarationRepository.GetByIpasDeclarationNoAsync(request.ipasDeclarationNo);
            if (declaration == null)
                throw new Exception("Declaration not found");

            var ipasIssueRequests =
                await _issueRequestExternalService.GetIssueReceiptStoreReceipts(request.ipasDeclarationNo); 
       
            return _mapper.Map<IEnumerable<IpasIssueRequestStoreReceiptResponse>>(ipasIssueRequests);
        }

    }
}

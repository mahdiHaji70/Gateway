using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.IssueRequestStoreReceipt.Commands.IssueRequestConfirmation
{

    public class IssueRequestConfirmationCommandHandler : IRequestHandler<IssueRequestConfirmationCommand, string>
    {
        private readonly IIssueRequestStoreReceiptExternalService _issueRequestExternalService;

        public IssueRequestConfirmationCommandHandler(IIssueRequestStoreReceiptExternalService issueRequestExternalService)
        {
            _issueRequestExternalService = issueRequestExternalService;
        }

        public async Task<string> Handle(IssueRequestConfirmationCommand request, CancellationToken cancellationToken)
        {
            var result =
                await _issueRequestExternalService.IssueRequestConfirmation(new IssueRequestConfirmationRequest
                {
                    RequestId = request.RequestId,
                    TerminalCode = request.TerminalCode,
                    Description = request.Description,
                    IsApproved = request.IsApproved
                });

            return result;
        }
    }
}

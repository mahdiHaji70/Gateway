using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

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
            if (await _issueRequestExternalService.IsIssueRequestApproved(request.RequestId, cancellationToken))
                throw new ValidationException(new[]
                {
                    new ValidationFailure(nameof(request.RequestId),
                        "This request has already been approved and submitted. It cannot be submitted again.")
                });

            var result =
                await _issueRequestExternalService.IssueRequestConfirmation(new IssueRequestConfirmationRequest
                {
                    RequestId = request.RequestId,
                    TerminalCode = request.TerminalCode,
                    Description = request.Description,
                    IsApproved = request.IsApproved
                }, cancellationToken);

            return result;
        }
    }
}

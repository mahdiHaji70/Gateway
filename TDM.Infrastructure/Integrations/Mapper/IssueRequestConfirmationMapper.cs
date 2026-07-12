using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.IssueRequestStoreReceipt.Commands.IssueRequestConfirmation;
using TDM.Application.Doc.IssueRequestStoreReceipt.Queries.GetIssueRequestByStorageAgreementNo;
using TDM.Infrastructure.Integrations.Requests;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public class IssueRequestConfirmationMapper
    {
        public static IssueRequestConfirmationDto Map(IssueRequestConfirmationRequest dto)
        {
            return new IssueRequestConfirmationDto
            {
              RequestId = dto.RequestId,
              IsApproved = dto.IsApproved,
              Description = dto.Description,
              TerminalCode = dto.TerminalCode,
            };

        }
    }
}

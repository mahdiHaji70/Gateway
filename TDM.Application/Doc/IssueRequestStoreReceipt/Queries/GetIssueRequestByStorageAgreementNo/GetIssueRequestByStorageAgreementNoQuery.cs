using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeByDeclarationNo;

namespace TDM.Application.Doc.IssueRequestStoreReceipt.Queries.GetIssueRequestByStorageAgreementNo
{
    public record GetIssueRequestByStorageAgreementNoQuery(string ipasDeclarationNo) : IRequest<IEnumerable<IpasIssueRequestStoreReceiptResponse>>;

}

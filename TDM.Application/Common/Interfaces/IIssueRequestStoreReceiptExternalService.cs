using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.IssueRequestStoreReceipt.Queries.GetIssueRequestByStorageAgreementNo;

namespace TDM.Application.Common.Interfaces
{
    public interface IIssueRequestStoreReceiptExternalService
    {
       Task<List<IpasIssueRequestStoreReceiptResponse>> GetIssueReceiptStoreReceipts(string ipasDeclarationNo, CancellationToken cancellationToken = default);
    }
}

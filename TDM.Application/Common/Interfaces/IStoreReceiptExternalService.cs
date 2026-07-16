using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.StoreReceipt.Queries.GetStoreReceiptByStorageAgreementNo;


namespace TDM.Application.Common.Interfaces
{
    public interface IStoreReceiptExternalService
    {
       Task<List<IpasStoreReceiptResponse>> GetStoreReceipts(string ipasDeclarationNo, CancellationToken cancellationToken = default);
        }
}

using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.StoreReceipts.DTOs;
using TDM.Application.Doc.StoreReceipts.Queries.GetStoreReceiptByStorageAgreementNo;


namespace TDM.Application.Common.Interfaces
{
    public interface IStoreReceiptExternalService
    {
       Task<List<StoreReceiptHeadDto>> GetStoreReceipts(string ipasDeclarationNo, CancellationToken cancellationToken = default);
        }
}

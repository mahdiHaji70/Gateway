using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.StoreReceipts.DTOs;

namespace TDM.Application.Doc.StoreReceipts.Queries.GetStoreReceiptByStorageAgreementNo
{
    public record GetStoreReceiptByStorageAgreementNoQuery(string ipasDeclarationNo) : IRequest<IEnumerable<StoreReceiptHeadDto>>;

}

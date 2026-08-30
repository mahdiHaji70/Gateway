using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.StoreReceipts.Queries.GetStoreReceiptByStorageAgreementNo
{
    public record GetStoreReceiptByStorageAgreementNoQuery(string ipasDeclarationNo) : IRequest<IEnumerable<IpasStoreReceiptResponse>>;

}

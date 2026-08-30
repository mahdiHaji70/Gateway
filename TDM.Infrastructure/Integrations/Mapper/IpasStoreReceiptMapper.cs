using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.IssueRequestStoreReceipt.Queries.GetIssueRequestByStorageAgreementNo;
using TDM.Application.Doc.StoreReceipts.Queries.GetStoreReceiptByStorageAgreementNo;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public class IpasStoreReceiptMapper
    {
        public static IpasStoreReceiptResponse Map(IpasStoreReceiptResponseDto dto)
        {
            return new IpasStoreReceiptResponse
            {
                No = dto.No              

            };

        }
        public static List<IpasStoreReceiptResponse> Map(List<IpasStoreReceiptResponseDto> dto)
        {
            return dto.Select(Map).ToList();
        }


    }
}

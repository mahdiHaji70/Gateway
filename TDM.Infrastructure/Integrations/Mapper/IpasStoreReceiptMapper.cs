using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.IssueRequestStoreReceipt.Queries.GetIssueRequestByStorageAgreementNo;
using TDM.Application.Doc.StoreReceipts.DTOs;
using TDM.Application.Doc.StoreReceipts.Queries.GetStoreReceiptByStorageAgreementNo;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public class StoreReceiptMapper
    {
        public static StoreReceiptHeadDto Map(IpasStoreReceiptResponseDto dto)
        {
            return new StoreReceiptHeadDto
            {
               // No = dto.No              

            };

        }
        public static List<StoreReceiptHeadDto> Map(List<IpasStoreReceiptResponseDto> dto)
        {
            return dto.Select(Map).ToList();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.DeclarationItems.Commands.RequestIpasDeclarationItems;
using TDM.Application.Doc.Declarations.Commands.RequestIpasDeclarationId;
using TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge;
using TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeByDeclarationNo;
using TDM.Infrastructure.Integrations.Requests;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public class IpasGoodwayBillMapper
    {
        public static IpasGoodwayBillsResponse Map(GoodwayBillsResponseDto goodwayBillsResponseDto)
        {
            return new IpasGoodwayBillsResponse
            {
                IpasDeclarationNo = goodwayBillsResponseDto.StorageAgreementNo,
                TerminalCode = goodwayBillsResponseDto.TerminalCode,
                WaybillId = new Guid(goodwayBillsResponseDto.Id),
                WaybillNo = goodwayBillsResponseDto.BlNo,
                VehicleNumber = goodwayBillsResponseDto.VehiclePlateNo ?? goodwayBillsResponseDto.WagonNo,
                PackageName = GetPackageName(goodwayBillsResponseDto),
                HSCode = GetHSCode(goodwayBillsResponseDto),
                CommodityName = GetCommodityName(goodwayBillsResponseDto),
                ContainerNo = GetContainerNo(goodwayBillsResponseDto),
                PackNB = GetPackNB(goodwayBillsResponseDto),
                Weight = GetWeight(goodwayBillsResponseDto),
            };

        }

        private static decimal GetWeight(GoodwayBillsResponseDto goodwayBillsResponseDto)
        {
            if (goodwayBillsResponseDto.CargoList?.Any() == true)
                return (decimal)goodwayBillsResponseDto.CargoList.First().GrossWeight;

            if (goodwayBillsResponseDto.BulkList?.Any() == true)
                return (decimal)goodwayBillsResponseDto.BulkList.First().Weight;

            return 0;
        }

        private static long GetPackNB(GoodwayBillsResponseDto goodwayBillsResponseDto)
        {
            return (long)(goodwayBillsResponseDto.CargoList?.FirstOrDefault()?.PackageQuantity ?? 0);
        }

        private static string GetPackageName(GoodwayBillsResponseDto goodwayBillsResponseDto)
        {
            return goodwayBillsResponseDto.CargoList?.FirstOrDefault()?.PackageType ?? string.Empty;
        }

        private static string GetHSCode(GoodwayBillsResponseDto goodwayBillsResponseDto)
        {
            if (goodwayBillsResponseDto.CargoList?.Any() == true)
                return goodwayBillsResponseDto.CargoList.First().HSCode;

            if (goodwayBillsResponseDto.BulkList?.Any() == true)
                return goodwayBillsResponseDto.BulkList.First().HsCode;

            return string.Empty;
        }

        private static string GetContainerNo(GoodwayBillsResponseDto goodwayBillsResponseDto)
        {

            return goodwayBillsResponseDto.ContainerList?.FirstOrDefault()?.ContainerNo ?? string.Empty;
        }

        private static string GetCommodityName(GoodwayBillsResponseDto goodwayBillsResponseDto)
        {
            if (goodwayBillsResponseDto.CargoList?.Any() == true)
                return goodwayBillsResponseDto.CargoList.First().Description;

            if (goodwayBillsResponseDto.BulkList?.Any() == true)
                return goodwayBillsResponseDto.BulkList.First().Description;

            return goodwayBillsResponseDto.ContainerList?.FirstOrDefault()?.ContainerNo ?? string.Empty;
        }
        public static List<IpasGoodwayBillsResponse> Map(List<GoodwayBillsResponseDto> goodwayBillsResponseDto)
       {
            return goodwayBillsResponseDto.Select(Map).ToList();
        }

    }
}

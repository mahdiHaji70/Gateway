using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.IssueRequestStoreReceipt.Queries.GetIssueRequestByStorageAgreementNo;
using TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeByDeclarationNo;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public class IpasIssueRequestMapper
    {
        public static IpasIssueRequestStoreReceiptResponse Map(IssueRequestResponseDto dto)
        {
            return new IpasIssueRequestStoreReceiptResponse
            {
                Id = dto.Id,
                RequestId = dto.RequestId,
                Port = dto.Port,
                PortCode = dto.PortCode,
                Terminal = dto.Terminal,
                TerminalCode = dto.TerminalCode,
                Date = dto.Date,
                Remark = dto.Remark,
                State = dto.State,
                OwnerName = dto.Owner.Name,
                OwnerNationalID = dto.Owner.NationalID,
                OwnerRepName = dto.OwnerRep.Name,
                OwnerRepNationalID = dto.OwnerRep.NationalID,
                RequestRemark = dto.RequestRemark,
                TaskRegisterDate = dto.TaskRegisterDate,
                HsCode = GetHSCode(dto),
                Description = GetCommodityName(dto),
                Weight = GetWeight(dto),
                Volume = GetVolume(dto),
                ContainerNo = GetContainerNo(dto),
                StorageAgreementNo = dto.StorageAgreementNo,
                BrandName = GetBrandName(dto),
                PackageTypeCode = GetPackageCode(dto),
                PackageType = GetPackageName(dto),
                PackageQuantity = GetPackNB(dto)

            };

        }

        private static string GetPackageCode(IssueRequestResponseDto dto)
        {
            return dto.GeneralCargoList?.FirstOrDefault()?.PackageTypeCode ?? string.Empty;
        }

        private static decimal GetWeight(IssueRequestResponseDto dto)
        {
            if (dto.GeneralCargoList?.Any() == true)
                return (decimal)dto.GeneralCargoList.Sum(x => x.GrossWeight);

            if (dto.BulkList?.Any() == true)
                return (decimal)dto.BulkList.Sum(x => x.Weight);

            return 0;
        }

        private static long GetPackNB(IssueRequestResponseDto dto)
        {
            return (long)(dto.GeneralCargoList?
                        .Where(x => x.PackageQuantity.HasValue)
                        .Sum(x => x.PackageQuantity!.Value) ?? 0);
        }
        private static decimal GetVolume(IssueRequestResponseDto dto)
        {
            var generalVolume = dto.GeneralCargoList?
         .Where(x => x.Width.HasValue && x.Height.HasValue && x.Length.HasValue)
         .Sum(x => (decimal)(x.Width!.Value * x.Height!.Value * x.Length!.Value)) ?? 0m;

            var bulkVolume = dto.BulkList?
                .Where(x => x.Volume.HasValue)
                .Sum(x => x.Volume!.Value) ?? 0m;

            return generalVolume + bulkVolume;
        }

        private static string GetBrandName(IssueRequestResponseDto dto)
        {
            return dto.GeneralCargoList?.FirstOrDefault()?.BrandName ?? string.Empty;
        }
        private static string GetPackageName(IssueRequestResponseDto dto)
        {
            return dto.GeneralCargoList?.FirstOrDefault()?.PackageType ?? string.Empty;
        }

        private static string GetHSCode(IssueRequestResponseDto dto)
        {
            if (dto.GeneralCargoList?.Any() == true)
                return dto.GeneralCargoList.First().HsCode;

            if (dto.BulkList?.Any() == true)
                return dto.BulkList.First().HsCode;

            return string.Empty;
        }

        private static string GetContainerNo(IssueRequestResponseDto dto)
        {

            return dto.ContainerList?.FirstOrDefault()?.ContainerNo ?? string.Empty;
        }

        private static string GetCommodityName(IssueRequestResponseDto dto)
        {
            if (dto.GeneralCargoList?.Any() == true)
                return dto.GeneralCargoList.First().Description;

            if (dto.BulkList?.Any() == true)
                return dto.BulkList.First().Description;

            return dto.ContainerList?.FirstOrDefault()?.ContainerNo ?? string.Empty;
        }
        public static List<IpasIssueRequestStoreReceiptResponse> Map(List<IssueRequestResponseDto> dto)
        {
            return dto.Select(Map).ToList();
        }

    }
}

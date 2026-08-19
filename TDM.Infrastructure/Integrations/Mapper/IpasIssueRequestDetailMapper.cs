using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.IssueRequestStoreReceipt.Queries.GetIssueRequestByStorageAgreementNo;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public class IpasIssueRequestDetailMapper
    {
        public static List<IpasIssueRequestStoreReceiptResponse> Map(
            IssueRequestResponseDto dto)
        {
            var result = new List<IpasIssueRequestStoreReceiptResponse>();

            if (dto.GeneralCargoList?.Any() == true)
            {
                foreach (var item in dto.GeneralCargoList)
                {
                    result.Add(MapGeneralCargo(dto, item));
                }
            }
            if (dto.BulkList?.Any() == true)
            {
                foreach (var item in dto.BulkList)
                {
                    result.Add(MapBulk(dto, item));
                }
            }

            if (dto.ContainerList?.Any() == true)
            {
                foreach (var item in dto.ContainerList)
                {
                    result.Add(MapContainer(dto, item));
                }
            }

            return result;
        }

        public static List<IpasIssueRequestStoreReceiptResponse> Map(
            List<IssueRequestResponseDto> dto)
        {
            return dto
                .SelectMany(Map)
                .ToList();
        }

        private static IpasIssueRequestStoreReceiptResponse CreateBase(
            IssueRequestResponseDto dto)
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

                OwnerName = dto.Owner?.Name,
                OwnerNationalID = dto.Owner?.NationalID,

                OwnerRepName = dto.OwnerRep?.Name,
                OwnerRepNationalID = dto.OwnerRep?.NationalID,

                RequestRemark = dto.RequestRemark,
                TaskRegisterDate = dto.TaskRegisterDate,
                StorageAgreementNo = dto.StorageAgreementNo
            };
        }

        private static IpasIssueRequestStoreReceiptResponse MapGeneralCargo(
            IssueRequestResponseDto dto,
            IssueRequestGeneralCargoResponseDto item)
        {
            var result = CreateBase(dto);

            result.HsCode = item.HsCode;
            result.Description = item.Description;

            result.Weight = (decimal)item.GrossWeight;

            result.Volume =
                item.Width.HasValue &&
                item.Height.HasValue &&
                item.Length.HasValue
                    ? (decimal)(
                        item.Width.Value *
                        item.Height.Value *
                        item.Length.Value)
                    : 0;

            result.ContainerNo = string.Empty;

            result.BrandName = item.BrandName;
            result.PackageTypeCode = item.PackageTypeCode;
            result.PackageType = item.PackageType;

            result.PackageQuantity = item.PackageQuantity.HasValue
                ? (long)item.PackageQuantity.Value
                : 0;

            return result;
        }

        private static IpasIssueRequestStoreReceiptResponse MapBulk(
            IssueRequestResponseDto dto,
            IssueRequestBulkResponseDto item)
        {
            var result = CreateBase(dto);

            result.HsCode = item.HsCode;
            result.Description = item.Description;

            result.Weight = (decimal)item.Weight;
            result.Volume = item.Volume;

            result.ContainerNo = string.Empty;

            result.BrandName = string.Empty;
            result.PackageTypeCode = string.Empty;
            result.PackageType = string.Empty;
            result.PackageQuantity = 0;

            return result;
        }

        private static IpasIssueRequestStoreReceiptResponse MapContainer(
            IssueRequestResponseDto dto,
            IssueRequestContainerResponseDto item)
        {
            var result = CreateBase(dto);

            result.HsCode = string.Empty;
            result.Description = string.Empty;

            result.Weight = 0;
            result.Volume = 0;

            result.ContainerNo = item.ContainerNo;

            result.BrandName = string.Empty;
            result.PackageTypeCode = string.Empty;
            result.PackageType = string.Empty;
            result.PackageQuantity = 0;

            return result;
        }
    }
}

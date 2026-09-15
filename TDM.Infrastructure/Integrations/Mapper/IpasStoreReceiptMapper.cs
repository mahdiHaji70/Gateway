using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.IssueRequestStoreReceipt.Queries.GetIssueRequestByStorageAgreementNo;
using TDM.Application.Doc.StoreReceipts.DTOs;
using TDM.Application.Doc.StoreReceipts.Queries.GetStoreReceiptByStorageAgreementNo;
using TDM.Domain.Enums;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public class StoreReceiptMapper
    {
        public static StoreReceiptHeadDto Map(IpasStoreReceiptResponseDto dto)
        {
            if (dto == null)
                return null;

            return new StoreReceiptHeadDto
            {
                IpasStoreReceiptId = dto.Id,
                TerminalCode = dto.terminalCode,
                IPASStoreReceiptNo = dto.No,
                IssueDate = dto.Date,
                ConsigneeId = dto.OwnerPartyId ?? Guid.Empty,
                ConsigneeName = dto.OwnerName,
                ConsigneeNationalId = dto.OwnerIdNumber,
                ConsigneeRepId = dto.OwnerRepPartyId ?? Guid.Empty,
                ConsigneeRepName = dto.OwnerRepName,
                ConsigneeRepNationalId = dto.OwnerRepIdNumber,
                CargoTypeId = GetCargoTypeId(dto),
                CargoTypeName = GetCargoTypeName(dto),
                FirstDischargeDate = dto.FirstDischargeDate,
                CreatorId = dto.CreatorId,
                CreatorName = dto.Creator,
                TrafficCode = dto.customsProcedureCode,
                TrafficName = dto.CustomsProcedure,
                StoreReceiptStateCode = dto.State,
                StoreReceiptStateName = dto.StateName,
                RequestId = dto.RequestId,
                BillOfLadingId = GetBillOfLadingId(dto),
                StoreReceiptGoods = MapGoods(dto),
                StoreReceiptContainers = MapContainers(dto)
            };

        }

        private static List<StoreReceiptGoodDto> MapGoods(IpasStoreReceiptResponseDto dto)
        {
            return dto.GeneralCargoList?.Select(cargo => new StoreReceiptGoodDto
            {
                HsCode = cargo.HsCode,
                PackageTypeCode = cargo.PackageTypeCode,
                CommodityName = cargo.Description,
                PackageName = cargo.PackageType,
                BrandName = cargo.BrandName,
                NoBrandName = cargo.NoBrandName ?? false,
                PackNB = cargo.PackageQuantity ?? 0,
                GrossWeight = cargo.GrossWeight,
                NetWeight = cargo.NetWeight,
                Volume = (cargo.Width ?? 0) * (cargo.Height ?? 0) * (cargo.Length ?? 0),
                Remark = cargo.Remark,
                IsHeavy = cargo.IsHeavy ?? false,
                IsNonPalletized = cargo.IsNonPalletized,
                IsDamaged = cargo.IsDamaged,
                IsVoluminous = cargo.IsVoluminous,
                IsDangerous = cargo.IsDangerous ?? false,
                DangerousNotNoticed = cargo.DangerousNotNoticed ?? false,
                DangerousCode = cargo.DangerousSpecification?.DangerousCode,
                Classification = cargo.DangerousSpecification?.Classification,
                IgnitionTemperature = cargo.DangerousSpecification?.IgnitionTemperature ?? 0,
                IgnitionTemperatureUnit = cargo.DangerousSpecification?.IgnitionTemperatureUnit
            }).Concat(
                dto.BulkList?.Select(bulk => new StoreReceiptGoodDto
                {
                    HsCode = bulk.HsCode,
                    CommodityName = bulk.Description,
                    PackNB = 0,
                    GrossWeight = bulk.Weight,
                    NetWeight = bulk.Weight,
                    Volume = bulk.Volume ?? 0,
                    Remark = bulk.Remark,
                    IsDangerous = bulk.IsDangerous ?? false,
                    DangerousNotNoticed = bulk.DangerousNotNoticed ?? false,
                    DangerousCode = bulk.DangerousSpecification?.DangerousCode,
                    Classification = bulk.DangerousSpecification?.Classification,
                    IgnitionTemperature = bulk.DangerousSpecification?.IgnitionTemperature ?? 0,
                    IgnitionTemperatureUnit = bulk.DangerousSpecification?.IgnitionTemperatureUnit
                }) ?? Enumerable.Empty<StoreReceiptGoodDto>())
                .ToList() ?? new List<StoreReceiptGoodDto>();
        }

        private static List<StoreReceiptContainerDto> MapContainers(IpasStoreReceiptResponseDto dto)
        {
            return dto.ContainerList?.Select(container => new StoreReceiptContainerDto
            {
                ContainerNo = container.ContainerNo,
                SealNumber = container.SealNumber,
                Remark = container.Remark,
                DangerousCode = container.DangerousSpecification?.DangerousCode,
                Classification = container.DangerousSpecification?.Classification,
                IgnitionTemperature = container.DangerousSpecification?.IgnitionTemperature ?? 0,
                IgnitionTemperatureUnit = container.DangerousSpecification?.IgnitionTemperatureUnit,
                StoreReceiptContainerGoods = container.Goods?.Select(good => new StoreReceiptContainerGoodDto
                {
                    HsCode = good.HSCode,
                    PackageTypeCode = good.PackageTypeCode,
                    CommodityName = good.Description,
                    PackageName = good.PackageTypeCode,
                    PackNB = good.PackageQuantity,
                    GrossWeight = good.Weight,
                    NetWeight = good.Weight
                }).ToList() ?? new List<StoreReceiptContainerGoodDto>()
            }).ToList() ?? new List<StoreReceiptContainerDto>();
        }

        private static Guid GetCargoTypeId(IpasStoreReceiptResponseDto dto)
        {
            if (dto.ContainerList?.Any() == true)
                return CargoTypes.Container;

            if (dto.BulkList?.Any() == true)
                return CargoTypes.Bulk;

            if (dto.GeneralCargoList?.Any() == true)
                return CargoTypes.GeneralCargo;

            return Guid.Empty;
        }

        private static string GetCargoTypeName(IpasStoreReceiptResponseDto dto)
        {
            if (dto.ContainerList?.Any() == true)
                return "Container";

            if (dto.BulkList?.Any() == true)
                return "Bulk";

            if (dto.GeneralCargoList?.Any() == true)
                return "GeneralCargo";

            return string.Empty;
        }

        private static Guid? GetBillOfLadingId(IpasStoreReceiptResponseDto dto)
        {
            return dto.GeneralCargoList?.FirstOrDefault(x => x.BillOfLadingId.HasValue)?.BillOfLadingId
                ?? dto.BulkList?.FirstOrDefault(x => x.BillOfLadingId.HasValue)?.BillOfLadingId
                ?? dto.ContainerList?.FirstOrDefault(x => x.billOfLadingId.HasValue)?.billOfLadingId;
        }
        public static List<StoreReceiptHeadDto> Map(List<IpasStoreReceiptResponseDto> dto)
        {
            return dto.Select(Map).ToList();
        }


    }
}

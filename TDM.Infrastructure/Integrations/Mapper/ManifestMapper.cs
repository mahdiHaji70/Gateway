using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.Manifests.DTOs;
using TDM.Domain.Enums;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public static class ManifestMapper
    {
        public static ManifestDto Map(ManifestResponseDto src)
        {
            if (src == null) return null;

            return new ManifestDto
            {
                SerialNo = src.SerialNo,
                ManifestRegistrationNumber = src.ManifestRegistrationNumber,
                VoyageNo = src.Voyage?.VoyageNo ?? string.Empty,
                NoticeNo = src.Voyage?.NoticeNo ?? string.Empty,
                ETA = src.Voyage?.ETA ?? default,
                ETD = src.Voyage?.ETD ?? default,
                ShipLine = src.Voyage?.ShippingLine ?? string.Empty,
                ShipAgent = src.Voyage?.ShippingAgent ?? string.Empty,
                ShipAgentNationalId = src.Voyage?.ShippingAgentCompanyIdNumber ?? string.Empty,
                VesselName = src.Voyage?.VesselData?.Name ?? string.Empty,
                Imo = src.Voyage?.VesselData?.Imo ?? string.Empty,
                TerminalCode = src.TerminalCodeDischarge,
                ManifestItems = src.Items?.Select(MapItem).ToList() ?? new List<ManifestItemDto>()
            };
        }

        private static ManifestItemDto MapItem(ManifestItemResponseDto src)
        {
            var itemDto = new ManifestItemDto
            {
                ManifestItemNo = src.No,
                ManifestNo = src.ManifestNo,
                Consignor = src.Consigor,
                ShipLine = src.ShippingLine,
                ManifestId = src.ManifestId,
                TrafficCode = src.CustomsProcedureCode,
                TrafficName = src.CustomsProcedure,
                ConsigneeName = src.Consignee,
                ConsigneeNationalId = src.ConsigneeIdNumber,
                ShipAgentName = src.ShippingAgent,
                ShipAgentNationalId = src.ShippingAgentIdNumber,
                IpasItemId = src.Id,
                ManifestGoods = new List<ManifestGoodDto>(),
                ManifestContainers = src.ContainersList?.Select(MapContainer).ToList() ?? new List<ManifestContainerDto>()
            };

            if (src.GeneralCargoList != null && src.GeneralCargoList.Count > 0)
            {
                itemDto.ManifestGoods.AddRange(src.GeneralCargoList.Select(g => new ManifestGoodDto
                {
                    PackNb = (long)g.PackageQuantity,
                    GrossWeight = g.GrossWeight,
                    NetWeight = g.NetWeight,
                    Volume = (g.ItemWidth ?? 0) * (g.ItemHeight ?? 0) * (g.ItemLength ?? 0),
                    BrandName = g.BrandName,
                    Description = g.Description,
                    HSCode = g.HSCode,
                    PackageCode = g.PackageTypeCode
                }));

                itemDto.CargoTypeId = CargoTypes.GeneralCargo;
            }

            if (src.BulkList != null && src.BulkList.Count > 0)
            {
                itemDto.ManifestGoods.AddRange(src.BulkList.Select(b => new ManifestGoodDto
                {
                    PackNb = 0,
                    GrossWeight = b.Weight,
                    NetWeight = b.Weight,
                    Volume = b.Volume ?? 0,
                    Description = b.Description,
                    HSCode = b.HSCode
                }));

                itemDto.CargoTypeId = CargoTypes.Bulk;
            }

            if(src.ContainersList != null && src.ContainersList.Count > 0)
            {
                itemDto.ManifestContainers.AddRange(src.ContainersList.Select(MapContainer));
                itemDto.CargoTypeId = CargoTypes.Container;
            }

            return itemDto;
        }

        private static ManifestContainerDto MapContainer(ManifestContainerResponseDto src)
        {
            return new ManifestContainerDto
            {
                ContainerNo = src.No,
                ContainerTypeAndSizeCode = src.TypeCode,
                BillOfLadingId = src.BillOfLadingId,
                SealNumber = src.SealNumber,
                DangerousCode = src.DangerousCode,
                Classification = src.DangerousClassification,
                IgnitionTemperature = src.IgnitionTemperature,
                IgnitionTemperatureUnit = src.IgnitionTemperatureUnit,
                ManifestContainerGoods = src.Goods?.Select(g => new ManifestContainerGoodDto
                {
                    PackNb = (long)g.PackageCount,
                    GrossWeight = g.GrossWeight,
                    NetWeight = g.NetWeight,
                    HSCode = g.HSCode,
                    CommodityName = g.GoodsDescription,
                    PackageCode = g.PackageTypeCode
                }).ToList() ?? new List<ManifestContainerGoodDto>()
            };
        }

    }

}
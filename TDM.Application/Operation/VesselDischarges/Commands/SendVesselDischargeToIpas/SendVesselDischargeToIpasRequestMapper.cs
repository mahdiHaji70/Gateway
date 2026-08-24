using System;
using System.Collections.Generic;
using System.Linq;
using TDM.Domain.Entities;
using TDM.Domain.Enums;

namespace TDM.Application.Operation.VesselDischarges.Commands.SendVesselDischargeToIpas
{
    public static class SendVesselDischargeToIpasRequestMapper
    {
        public static SendVesselDischargeToIpasRequest Map(VesselDischarge vesselDischarge)
        {
            ArgumentNullException.ThrowIfNull(vesselDischarge);

            var isContainer = vesselDischarge.ManifestItem?.CargoTypeId == CargoTypes.Container;

            var manifestGood = isContainer ? null : vesselDischarge.ManifestItem?.ManifestGoods?.FirstOrDefault();

            return new SendVesselDischargeToIpasRequest
            {
                Id = vesselDischarge.Id,
                TerminalCode = vesselDischarge.TerminalCode,
                ManifestNoticeNo = vesselDischarge.ManifestItem?.ManifestNo ?? string.Empty,
                DischargeDate = vesselDischarge.DischargeDate,
                IpasItemId = vesselDischarge.ManifestItem?.IpasItemId ?? Guid.Empty,
                CargoTypeId = vesselDischarge.ManifestItem?.CargoTypeId ?? Guid.Empty,
                PackNB = vesselDischarge.PackNB,
                Weight = vesselDischarge.Weight,
                Volume = vesselDischarge.Volume,
                UnitWeight = vesselDischarge.UnitWeight,

                HSCode = isContainer ? manifestGood?.Commodity?.HsCode! : string.Empty,
                CommodityName = isContainer ? manifestGood?.Commodity?.Name! : string.Empty,
                PackageCode = isContainer ? manifestGood?.Package?.Code! : string.Empty,

                ContainerNo = vesselDischarge.ManifestContainer?.Container?.No,
                ContainerTypeAndCode = vesselDischarge.ManifestContainer?.Container?.ContainerTypeAndSize?.TypeAndSizeCode,
                SealNumber = vesselDischarge.ManifestContainer?.SealNumber,

                IsNonPalletized = vesselDischarge.IsNonPalletized,
                IsDamaged = vesselDischarge.IsDamaged,
                IsVoluminous = vesselDischarge.IsVoluminous,
                IsDangerous = vesselDischarge.IsDangerous,
                DangerousCode = vesselDischarge.DangerousCode,
                Classification = vesselDischarge.Classification,
                IgnitionTemperature = vesselDischarge.IgnitionTemperature,
                IgnitionTemperatureUnit = vesselDischarge.IgnitionTemperatureUnit,

                IpasVesselDischargeId = vesselDischarge.IpasVesselDischargeId,
                IpasVesselDischargeReceivedAt = vesselDischarge.IpasVesselDischargeReceivedAt,
                IsSend = vesselDischarge.IpasVesselDischargeId.HasValue
            };
        }

        public static List<SendVesselDischargeToIpasRequest> Map(List<VesselDischarge> vesselDischarges)
        {
            return vesselDischarges.Select(Map).ToList();
        }
    }
}

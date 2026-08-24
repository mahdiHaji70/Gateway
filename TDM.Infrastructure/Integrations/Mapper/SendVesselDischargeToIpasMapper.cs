using System;
using System.Collections.Generic;
using System.Linq;
using TDM.Application.Operation.VesselDischarges.Commands.SendVesselDischargeToIpas;
using TDM.Domain.Enums;
using TDM.Infrastructure.Integrations.Requests;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public static class SendVesselDischargeToIpasMapper
    {
        public static SendVesselDischargeToIpasDto Map(SendVesselDischargeToIpasRequest sendVesselDischargeToIpasRequest)
        {
            return new SendVesselDischargeToIpasDto
            {
                Date = sendVesselDischargeToIpasRequest.DischargeDate,
                VoyageNoticeNo = sendVesselDischargeToIpasRequest.ManifestNoticeNo,
                TerminalCode = sendVesselDischargeToIpasRequest.TerminalCode,
                BillOfLadingId = sendVesselDischargeToIpasRequest.IpasItemId.ToString(),
                TallyMan = "TO DO",
                CarrierIdNumber = "TO DO",
                CarrierType = 1,
                CarrierEmptyWeight = 1000m,
                CarrierFullWeight = sendVesselDischargeToIpasRequest.Weight + 1000m,
                GateInDateTime = sendVesselDischargeToIpasRequest.DischargeDate,
                GateOutDateTime = sendVesselDischargeToIpasRequest.DischargeDate,
                IsFullyDischargedNoticed = false,
                Remark = "TO DO",

                GeneralCargoList = sendVesselDischargeToIpasRequest.CargoTypeId == CargoTypes.GeneralCargo
                    ? new List<SendGeneralCargoVesselDischargeToIpasDto> { MapToGeneralCargo(sendVesselDischargeToIpasRequest) }
                    : new List<SendGeneralCargoVesselDischargeToIpasDto>(),

                BulkList = sendVesselDischargeToIpasRequest.CargoTypeId == CargoTypes.Bulk
                    ? new List<SendBulkVesselDischargeToIpasDto> { MapToBulk(sendVesselDischargeToIpasRequest) }
                    : new List<SendBulkVesselDischargeToIpasDto>(),

                ContainerList = sendVesselDischargeToIpasRequest.CargoTypeId == CargoTypes.Container
                    ? new List<SendContainerVesselDischargeToIpasDto> { MapToContainer(sendVesselDischargeToIpasRequest) }
                    : new List<SendContainerVesselDischargeToIpasDto>()
            };
        }

        private static SendGeneralCargoVesselDischargeToIpasDto MapToGeneralCargo(SendVesselDischargeToIpasRequest request)
        {
            return new SendGeneralCargoVesselDischargeToIpasDto
            {
                HsCode = request.HSCode,
                Description = request.CommodityName,
                BrandName = "TO DO",
                PackageTypeCode = request.PackageCode,
                PackageType = request.PackageCode,
                PackageQuantity = request.PackNB,
                GrossWeight = request.Weight,
                NetWeight = request.Weight,
                IsNonPalletized = request.IsNonPalletized,
                IsDamaged = request.IsDamaged,
                Width = 1,
                Height = 1,
                Length = 1,
                IsVoluminous = request.IsVoluminous,
                IsHeavy = false,
                NoBrandName = true,
                Remark = "TO DO",
                IsDangerous = request.IsDangerous,
                DangerousNotNoticed = false,
                DangerousSpecification = new SendDangerousSpecificationVesselDischargeToIpasDto
                {
                    DangerousCode = request.DangerousCode,
                    Classification = request.Classification,
                    IgnitionTemperature = request.IgnitionTemperature ?? 0m,
                    IgnitionTemperatureUnit = request.IgnitionTemperatureUnit
                }
            };
        }

        private static SendBulkVesselDischargeToIpasDto MapToBulk(SendVesselDischargeToIpasRequest request)
        {
            return new SendBulkVesselDischargeToIpasDto
            {
                HsCode = request.HSCode,
                Description = request.CommodityName,
                Weight = (float)request.Weight,
                Volume = (float)request.Volume,
                IsDangerous = request.IsDangerous,
                DangerousNotNoticed = false,
                Remark = "TO DO",
                DangerousSpecification = new SendDangerousSpecificationVesselDischargeToIpasDto
                {
                    DangerousCode = request.DangerousCode,
                    Classification = request.Classification,
                    IgnitionTemperature = request.IgnitionTemperature ?? 0m,
                    IgnitionTemperatureUnit = request.IgnitionTemperatureUnit
                }
            };
        }

        private static SendContainerVesselDischargeToIpasDto MapToContainer(SendVesselDischargeToIpasRequest request)
        {
            return new SendContainerVesselDischargeToIpasDto
            {
                ContainerNo = request.ContainerNo ?? string.Empty,
                ContainerTypeAndSizeCode = request.ContainerTypeAndCode ?? string.Empty,
                SealNumber = request.SealNumber ?? string.Empty,
                Remark = "TO DO",
                IsDangerous = request.IsDangerous,
                DangerousNotNoticed = false,
                DangerousSpecification = new SendDangerousSpecificationVesselDischargeToIpasDto
                {
                    DangerousCode = request.DangerousCode,
                    Classification = request.Classification,
                    IgnitionTemperature = request.IgnitionTemperature ?? 0m,
                    IgnitionTemperatureUnit = request.IgnitionTemperatureUnit
                },
                //DischargeSpecification = new SendVesselDischargeSpecificationToIpasDto
                //{
                //    IsBundled = false,
                //    IsOG = false,
                //    IsUsedSpecialEquipment = false,
                //    SpecialEquipmentOwner = null,
                //    CraneNo = "TO DO",
                //    CraneDriver = "TO DO",
                //    TallyMan = "TO DO",
                //    HandlingTypeId = 1
                //}
            };
        }

        public static List<SendVesselDischargeToIpasDto> Map(List<SendVesselDischargeToIpasRequest> requests)
        {
            return requests.Select(Map).ToList();
        }
    }
}

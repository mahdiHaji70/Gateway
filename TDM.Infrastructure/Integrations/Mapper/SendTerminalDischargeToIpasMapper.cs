using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge;
using TDM.Domain.Entities;
using TDM.Infrastructure.Integrations.Requests;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public class SendTerminalDischargeToIpasMapper
    {
        public static SendTerminalDischargeToIpasDto Map(SendIpasTerminalDischargeRequest sendIpasTerminalDischargeRequest)
        {
            return new SendTerminalDischargeToIpasDto
            {
                TerminalDischargeId= sendIpasTerminalDischargeRequest.TerminalDischargeId,
                TerminalCode = sendIpasTerminalDischargeRequest.TerminalCode,
                AgreementNo = sendIpasTerminalDischargeRequest.IpasDeclarationNo,
                WaybillId = sendIpasTerminalDischargeRequest.WaybillId,
                WaybillNo = sendIpasTerminalDischargeRequest.WaybillNo,
                DischargeDate = sendIpasTerminalDischargeRequest.DischargeDate,
                TruckPlateNumber = sendIpasTerminalDischargeRequest.VehicleNumber,
                TruckEmptyWeight = 1000,
                TruckFullWeight = (float)(sendIpasTerminalDischargeRequest.Weight + 1000m),
                Tallyman = "To DO",
                GateInDateTime = sendIpasTerminalDischargeRequest.DischargeDate,
                GateOutDateTime = sendIpasTerminalDischargeRequest.DischargeDate,
                GeneralCargoList = sendIpasTerminalDischargeRequest.CargoTypeId == Domain.Enums.CargoTypes.GeneralCargo
            ? new List<SendGeneralCargoTerminalDischargeToIpasDto> { MapToGeneralCargo(sendIpasTerminalDischargeRequest) }
            : new List<SendGeneralCargoTerminalDischargeToIpasDto>(),

                BulkList = sendIpasTerminalDischargeRequest.CargoTypeId == Domain.Enums.CargoTypes.Bulk
            ? new List<SendBulkTerminalDischargeToIpasDto> { MapToBulk(sendIpasTerminalDischargeRequest) }
            : new List<SendBulkTerminalDischargeToIpasDto>(),

                ContainerList = sendIpasTerminalDischargeRequest.CargoTypeId == Domain.Enums.CargoTypes.Container
            ? new List<SendContainerTerminalDischargeToIpasDto> { MapToContainer(sendIpasTerminalDischargeRequest) }
            : new List<SendContainerTerminalDischargeToIpasDto>()
            };

        }
        private static SendGeneralCargoTerminalDischargeToIpasDto MapToGeneralCargo(SendIpasTerminalDischargeRequest sendIpasTerminalDischargeRequest)
        {
            return new SendGeneralCargoTerminalDischargeToIpasDto
            {
                HSCode = sendIpasTerminalDischargeRequest.HSCode,
                Description = sendIpasTerminalDischargeRequest.CommodityName,
                BrandName = "TO DO",
                PackageType= sendIpasTerminalDischargeRequest.PackageName,
                PackageTypeCode = sendIpasTerminalDischargeRequest.PackageCode,
                PackageQuantity = sendIpasTerminalDischargeRequest.PackNB,
                GrossWeight = (float)sendIpasTerminalDischargeRequest.Weight,
                NetWeight = (float)sendIpasTerminalDischargeRequest.Weight,
                IsDangerous = sendIpasTerminalDischargeRequest.IsDangerous,
                IsNonPalletized = sendIpasTerminalDischargeRequest.IsNonPalletized,
                IsDamaged = sendIpasTerminalDischargeRequest.IsDamaged,
                Width = 1,
                Height = 1,
                Length = 1,
                IsVoluminous = sendIpasTerminalDischargeRequest.IsVoluminous,
                DangerousSpecification = new SendDangerousSpecificationTerminalDischargeToIpasDto
                {
                    Classification = sendIpasTerminalDischargeRequest.Classification,
                    DangerousCode = sendIpasTerminalDischargeRequest.DangerousCode,
                    IgnitionTemperature = sendIpasTerminalDischargeRequest.IgnitionTemperature,
                    IgnitionTemperatureUnit = sendIpasTerminalDischargeRequest.IgnitionTemperatureUnit
                },
                Remark = "To DO"
            };
        }

        private static SendBulkTerminalDischargeToIpasDto MapToBulk(SendIpasTerminalDischargeRequest sendIpasTerminalDischargeRequest)
        {
            return new SendBulkTerminalDischargeToIpasDto
            {
                HSCode = sendIpasTerminalDischargeRequest.HSCode,
                Description = sendIpasTerminalDischargeRequest.CommodityName,
                Weight = (float)sendIpasTerminalDischargeRequest.Weight,
                Volume = (float)sendIpasTerminalDischargeRequest.Volume,
                IsDangerous = sendIpasTerminalDischargeRequest.IsDangerous,
                DangerousNotNoticed = false,
                DangerousSpecification = new SendDangerousSpecificationTerminalDischargeToIpasDto
                {
                    Classification = sendIpasTerminalDischargeRequest.Classification,
                    DangerousCode = sendIpasTerminalDischargeRequest.DangerousCode,
                    IgnitionTemperature = sendIpasTerminalDischargeRequest.IgnitionTemperature,
                    IgnitionTemperatureUnit = sendIpasTerminalDischargeRequest.IgnitionTemperatureUnit
                },
                Remark = "To DO"
            };
        }

        private static SendContainerTerminalDischargeToIpasDto MapToContainer(SendIpasTerminalDischargeRequest sendIpasTerminalDischargeRequest)
        {
            return new SendContainerTerminalDischargeToIpasDto
            {
                ContainerNo = sendIpasTerminalDischargeRequest.ContainerNo
            };
        }

        public static List<SendTerminalDischargeToIpasDto> Map(List<SendIpasTerminalDischargeRequest> sendIpasTerminalDischargeRequest)
        {
            return sendIpasTerminalDischargeRequest.Select(Map).ToList();
        }
    }
}

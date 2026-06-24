using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge;
using TDM.Domain.Entities;
using TDM.Infrastructure.Integrations.Requests;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public class SendIpasTerminalDischargeMapper
    {
        public static SendIpasTerminalDischarge Map(SendIpasTerminalDischargeRequest sendIpasTerminalDischargeRequest)
        {
            return new SendIpasTerminalDischarge
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
            ? new List<SendIpasTerminalDischargeGeneralCargo> { MapToGeneralCargo(sendIpasTerminalDischargeRequest) }
            : new List<SendIpasTerminalDischargeGeneralCargo>(),

                BulkList = sendIpasTerminalDischargeRequest.CargoTypeId == Domain.Enums.CargoTypes.Bulk
            ? new List<SendIpasTerminalDischargeBulk> { MapToBulk(sendIpasTerminalDischargeRequest) }
            : new List<SendIpasTerminalDischargeBulk>(),

                ContainerList = sendIpasTerminalDischargeRequest.CargoTypeId == Domain.Enums.CargoTypes.Container
            ? new List<SendIpasTerminalDischargeContainer> { MapToContainer(sendIpasTerminalDischargeRequest) }
            : new List<SendIpasTerminalDischargeContainer>()
            };

        }
        private static SendIpasTerminalDischargeGeneralCargo MapToGeneralCargo(SendIpasTerminalDischargeRequest sendIpasTerminalDischargeRequest)
        {
            return new SendIpasTerminalDischargeGeneralCargo
            {
                HSCode = sendIpasTerminalDischargeRequest.HSCode,
                Description = sendIpasTerminalDischargeRequest.CommodityName,
                BrandName = "TO DO",
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
                DangerousSpecification = new SendIpasTerminalDischargeDangerousSpecification
                {
                    Classification = sendIpasTerminalDischargeRequest.Classification,
                    DangerousCode = sendIpasTerminalDischargeRequest.DangerousCode,
                    IgnitionTemperature = sendIpasTerminalDischargeRequest.IgnitionTemperature,
                    IgnitionTemperatureUnit = sendIpasTerminalDischargeRequest.IgnitionTemperatureUnit
                },
                Remark = "To DO"
            };
        }

        private static SendIpasTerminalDischargeBulk MapToBulk(SendIpasTerminalDischargeRequest sendIpasTerminalDischargeRequest)
        {
            return new SendIpasTerminalDischargeBulk
            {
                HSCode = sendIpasTerminalDischargeRequest.HSCode,
                Description = sendIpasTerminalDischargeRequest.CommodityName,
                Weight = (float)sendIpasTerminalDischargeRequest.Weight,
                Volume = (float)sendIpasTerminalDischargeRequest.Volume,
                IsDangerous = sendIpasTerminalDischargeRequest.IsDangerous,
                DangerousNotNoticed = false,
                DangerousSpecification = new SendIpasTerminalDischargeDangerousSpecification
                {
                    Classification = sendIpasTerminalDischargeRequest.Classification,
                    DangerousCode = sendIpasTerminalDischargeRequest.DangerousCode,
                    IgnitionTemperature = sendIpasTerminalDischargeRequest.IgnitionTemperature,
                    IgnitionTemperatureUnit = sendIpasTerminalDischargeRequest.IgnitionTemperatureUnit
                },
                Remark = "To DO"
            };
        }

        private static SendIpasTerminalDischargeContainer MapToContainer(SendIpasTerminalDischargeRequest sendIpasTerminalDischargeRequest)
        {
            return new SendIpasTerminalDischargeContainer
            {
                ContainerNo = sendIpasTerminalDischargeRequest.ContainerNo
            };
        }

        public static List<SendIpasTerminalDischarge> Map(List<SendIpasTerminalDischargeRequest> sendIpasTerminalDischargeRequest)
        {
            return sendIpasTerminalDischargeRequest.Select(Map).ToList();
        }
    }
}

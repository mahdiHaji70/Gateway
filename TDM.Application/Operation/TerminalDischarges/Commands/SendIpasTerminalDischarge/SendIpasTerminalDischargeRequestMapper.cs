using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge
{
    public static class SendIpasTerminalDischargeRequestMapper
    {
        public static SendIpasTerminalDischargeRequest Map(TerminalDischarge terminalDischarge)
        {
            return new SendIpasTerminalDischargeRequest
            {
                TerminalCode = terminalDischarge.TerminalCode.ToString(),
                AgreementNo = terminalDischarge.DeclarationItem.Declaration.IpasDeclarationNo,
                WaybillId = terminalDischarge.WayBillId,
                WaybillNo = terminalDischarge.WayBillNo,
                DischargeDate = terminalDischarge.DischargeDate,
                TruckPlateNumber = terminalDischarge.VehicleNumber,
                TruckEmptyWeight = 1000,
                TruckFullWeight = (float)(terminalDischarge.Weight + 1000m),
                Tallyman = "To DO",
                GateInDateTime = terminalDischarge.DischargeDate,
                GateOutDateTime = terminalDischarge.DischargeDate,
                GeneralCargoList = terminalDischarge.CargoTypeId == Domain.Enums.CargoTypes.GeneralCargo
            ? new List<SendIpasTerminalDischargeGeneralCargoRequest> { MapToGeneralCargo(terminalDischarge) }
            : new List<SendIpasTerminalDischargeGeneralCargoRequest>(),

                BulkList = terminalDischarge.CargoTypeId == Domain.Enums.CargoTypes.Bulk
            ? new List<SendIpasTerminalDischargeBulkRequest> { MapToBulk(terminalDischarge) }
            : new List<SendIpasTerminalDischargeBulkRequest>(),

                ContainerList = terminalDischarge.CargoTypeId == Domain.Enums.CargoTypes.Container
            ? new List<SendIpasTerminalDischargeContainerRequest> { MapToContainer(terminalDischarge) }
            : new List<SendIpasTerminalDischargeContainerRequest>()
            };

        }
        private static SendIpasTerminalDischargeGeneralCargoRequest MapToGeneralCargo(TerminalDischarge terminalDischarge)
        {
            return new SendIpasTerminalDischargeGeneralCargoRequest
            {
                HSCode = terminalDischarge.DeclarationItem.Commodity.HsCode,
                Description = terminalDischarge.DeclarationItem.Commodity.Name,
                BrandName = "TO DO",
                PackageTypeCode = terminalDischarge.DeclarationItem.Package.Code,
                PackageQuantity = terminalDischarge.PackNB,
                GrossWeight = (float)terminalDischarge.Weight,
                NetWeight = (float)terminalDischarge.Weight,
                IsDangerous = terminalDischarge.IsDangerous,
                IsNonPalletized = terminalDischarge.IsNonPalletized,
                IsDamaged = terminalDischarge.IsDamaged,
                Width = 1,
                Height = 1,
                Length = 1,
                IsVoluminous = terminalDischarge.IsVoluminous,
                DangerousSpecification = new SendIpasTerminalDischargeDangerousSpecificationRequest
                {
                    Classification = terminalDischarge.Classification,
                    DangerousCode = terminalDischarge.DangerousCode,
                    IgnitionTemperature = terminalDischarge.IgnitionTemperature,
                    IgnitionTemperatureUnit = terminalDischarge.IgnitionTemperatureUnit
                },
                Remark = "To DO"
            };
        }

        private static SendIpasTerminalDischargeBulkRequest MapToBulk(TerminalDischarge terminalDischarge)
        {
            return new SendIpasTerminalDischargeBulkRequest
            {
                HSCode = terminalDischarge.DeclarationItem.Commodity.HsCode,
                Description = terminalDischarge.DeclarationItem.Commodity.Name,
                Weight = (float)terminalDischarge.Weight,
                Volume = (float)terminalDischarge.Volume,
                IsDangerous = terminalDischarge.IsDangerous,
                DangerousNotNoticed = false,
                DangerousSpecification = new SendIpasTerminalDischargeDangerousSpecificationRequest
                {
                    Classification = terminalDischarge.Classification,
                    DangerousCode = terminalDischarge.DangerousCode,
                    IgnitionTemperature = terminalDischarge.IgnitionTemperature,
                    IgnitionTemperatureUnit = terminalDischarge.IgnitionTemperatureUnit
                },
                Remark = "To DO"
            };
        }

        private static SendIpasTerminalDischargeContainerRequest MapToContainer(TerminalDischarge terminalDischarge)
        {
            return new SendIpasTerminalDischargeContainerRequest
            {
                ContainerNo = ""
            };
        }

    }

}

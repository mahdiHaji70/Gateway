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
                TerminalDischargeId=terminalDischarge.Id,
                TerminalCode = terminalDischarge.TerminalCode.ToString(),
                IpasDeclarationNo = terminalDischarge.DeclarationItem.Declaration.IpasDeclarationNo,
                WaybillId = terminalDischarge.WayBillId,
                WaybillNo = terminalDischarge.WayBillNo,
                DischargeDate = terminalDischarge.DischargeDate,
                VehicleNumber = terminalDischarge.VehicleNumber,
                HSCode = terminalDischarge.DeclarationItem.Commodity.HsCode,
                CommodityId = terminalDischarge.DeclarationItem.Commodity.Id,
                CommodityName = terminalDischarge.DeclarationItem.Commodity.Name,
                PackageCode = terminalDischarge.DeclarationItem.Package.Code,
                PackageId = terminalDischarge.DeclarationItem.Package.Id,
                PackageName = terminalDischarge.DeclarationItem.Package.Name,
                PackNB = terminalDischarge.PackNB,
                Weight = terminalDischarge.Weight,
                Volume = terminalDischarge.Volume,
                IsVoluminous= terminalDischarge.IsVoluminous,
                IsDangerous = terminalDischarge.IsDangerous,
                IsNonPalletized = terminalDischarge.IsNonPalletized,
                IsDamaged = terminalDischarge.IsDamaged,
                Classification = terminalDischarge.Classification,
                DangerousCode = terminalDischarge.DangerousCode,
                IgnitionTemperature = terminalDischarge.IgnitionTemperature,
                IgnitionTemperatureUnit = terminalDischarge.IgnitionTemperatureUnit
            };

        }
        public static List<SendIpasTerminalDischargeRequest> Map(List<TerminalDischarge> terminalDischarges)
        {
            return terminalDischarges.Select(Map).ToList();
        }


    }

}

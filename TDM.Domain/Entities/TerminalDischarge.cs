using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Linq;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class TerminalDischarge : BaseEntity
    {
        public string TerminalCode { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; } = null!;
        public Guid DeclarationItemId { get; set; }
        public DeclarationItem DeclarationItem { get; set; } = null!;
        public string WayBillNo { get; set; }
        public Guid WayBillId { get; set; }
        public DateTime DischargeDate { get; set; }
        public string VehicleNumber { get; set; }
        public long PackNB { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public bool IsNonPalletized { get; set; } = false;
        public bool IsDamaged { get; set; } = false;
        public bool IsVoluminous { get; set; } = false;
        public bool IsDangerous { get; set; } = false;
        public string DangerousCode { get; set; }
        public string Classification { get; set; }
        public decimal IgnitionTemperature { get; set; }
        public string IgnitionTemperatureUnit { get; set; }
        public Guid? IpasTerminalDischargeId { get; set; }
        public DateTime? IpasTerminalDischargeReceivedAt { get; set; }
        public Guid? IssueRequestId { get; set; }
        public decimal UnitWeight { get; set; } = 0;

        public TerminalDischarge()
        {
            
        }

        public TerminalDischarge(
     string terminalCode,
     Guid cargoTypeId,
     Guid storeId,
     Guid declarationItemId,
     string wayBillNo,
     Guid wayBillId,
     DateTime dischargeDate,
     string vehicleNumber,
     long packNB,
     decimal weight,
     decimal volume,
     bool isNonPalletized = false,
     bool isDamaged = false,
     bool isVoluminous = false,
     bool isDangerous = false,
     string dangerousCode = null,
     string classification = null,
     decimal ignitionTemperature = 0,
     string ignitionTemperatureUnit = null,
     Guid? issueRequestId = null,
     decimal unitWeight = 0)
     => SetProperty(terminalCode, storeId, declarationItemId, wayBillNo,
                    wayBillId, dischargeDate, vehicleNumber, packNB, weight, volume,
                    isNonPalletized, isDamaged, isVoluminous, isDangerous,
                    dangerousCode, classification, ignitionTemperature, ignitionTemperatureUnit, issueRequestId, unitWeight);

        public void Update(
            string terminalCode,
            Guid storeId,
            Guid declarationItemId,
            string wayBillNo,
            Guid wayBillId,
            DateTime dischargeDate,
            string vehicleNumber,
            long packNB,
            decimal weight,
            decimal volume,
            bool isNonPalletized = false,
            bool isDamaged = false,
            bool isVoluminous = false,
            bool isDangerous = false,
            string dangerousCode = null,
            string classification = null,
            decimal ignitionTemperature = 0,
            string ignitionTemperatureUnit = null,
            Guid? issueRequestId = null,
            decimal unitWeight = 0)
            => SetProperty(terminalCode, storeId, declarationItemId, wayBillNo,
                           wayBillId, dischargeDate, vehicleNumber, packNB, weight, volume,
                           isNonPalletized, isDamaged, isVoluminous, isDangerous,
                           dangerousCode, classification, ignitionTemperature, ignitionTemperatureUnit, issueRequestId, unitWeight);

        private void SetProperty(
            string terminalCode,
            Guid storeId,
            Guid declarationItemId,
            string wayBillNo,
            Guid wayBillId,
            DateTime dischargeDate,
            string vehicleNumber,
            long packNB,
            decimal weight,
            decimal volume,
            bool isNonPalletized,
            bool isDamaged,
            bool isVoluminous,
            bool isDangerous,
            string dangerousCode,
            string classification,
            decimal ignitionTemperature,
            string ignitionTemperatureUnit,
            Guid? issueRequestId,
            decimal unitWeight= 0)
        {
            Validate(terminalCode, storeId, declarationItemId,
                     wayBillNo, wayBillId, dischargeDate, vehicleNumber,
                     packNB, weight, volume, isDangerous, dangerousCode,
                     ignitionTemperature, ignitionTemperatureUnit);

            TerminalCode = terminalCode;
            StoreId = storeId;
            DeclarationItemId = declarationItemId;
            WayBillNo = wayBillNo;
            WayBillId = wayBillId;
            DischargeDate = dischargeDate;
            VehicleNumber = vehicleNumber;
            PackNB = packNB;
            Weight = weight;
            Volume = volume;
            IsNonPalletized = isNonPalletized;
            IsDamaged = isDamaged;
            IsVoluminous = isVoluminous;
            IsDangerous = isDangerous;
            DangerousCode = dangerousCode;
            Classification = classification;
            IgnitionTemperature = ignitionTemperature;
            IgnitionTemperatureUnit = ignitionTemperatureUnit;
            IssueRequestId = issueRequestId;
            UnitWeight = unitWeight;
        }

        public void SetIpasReceived(Guid ipasTerminalDischargeId, DateTime receivedAt)
        {
            if (ipasTerminalDischargeId == Guid.Empty)
                throw new DomainValidationException("IpasTerminalDischargeId is required.");

            if (receivedAt == default)
                throw new DomainValidationException("IpasTerminalDischargeReceivedAt is required.");

            IpasTerminalDischargeId = ipasTerminalDischargeId;
            IpasTerminalDischargeReceivedAt = receivedAt;
        }

        private void Validate(
            string terminalCode,
            Guid storeId,
            Guid declarationItemId,
            string wayBillNo,
            Guid wayBillId,
            DateTime dischargeDate,
            string vehicleNumber,
            long packNB,
            decimal weight,
            decimal volume,
            bool isDangerous,
            string dangerousCode,
            decimal ignitionTemperature,
            string ignitionTemperatureUnit)
        {
            if (string.IsNullOrWhiteSpace(terminalCode))
                throw new DomainValidationException("TerminalCode is required.");

            if (storeId == Guid.Empty)
                throw new DomainValidationException("StoreId is required.");

            if (declarationItemId == Guid.Empty)
                throw new DomainValidationException("DeclarationItemId is required.");

            if (wayBillId == Guid.Empty)
                throw new DomainValidationException("WayBillId is required.");


            if (string.IsNullOrWhiteSpace(wayBillNo))
                throw new DomainValidationException("WayBillNo is required.");

            if (string.IsNullOrWhiteSpace(vehicleNumber))
                throw new DomainValidationException("VehicleNumber is required.");


            if (dischargeDate == default)
                throw new DomainValidationException("DischargeDate is required.");

            if (dischargeDate > DateTime.UtcNow)
                throw new DomainValidationException("DischargeDate cannot be in the future.");


            if (packNB <= 0)
                throw new DomainValidationException("PackNB cannot be negative.");

            if (weight <= 0)
                throw new DomainValidationException("Weight must be greater than zero.");


            if (isDangerous)
            {
                if (string.IsNullOrWhiteSpace(dangerousCode))
                    throw new DomainValidationException("DangerousCode is required when cargo is dangerous.");

                if (ignitionTemperature <= 0)
                    throw new DomainValidationException("IgnitionTemperature must be greater than zero for dangerous cargo.");

                if (string.IsNullOrWhiteSpace(ignitionTemperatureUnit))
                    throw new DomainValidationException("IgnitionTemperatureUnit is required for dangerous cargo.");
            }
        }
    }
}

using System;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class VesselDischarge : BaseEntity
    {
        public string TerminalCode { get; private set; } = null!;

        public Guid StoreId { get; private set; }
        public Store Store { get; private set; } = null!;

        public Guid ManifestItemId { get; private set; }
        public ManifestItem ManifestItem { get; private set; } = null!;

        public Guid? ManifestContainerId { get; private set; }
        public ManifestContainer? ManifestContainer { get; private set; } = null!;

        public DateTime DischargeDate { get; private set; }
        public long PackNB { get; private set; }
        public decimal Weight { get; private set; }
        public decimal Volume { get; private set; }

        public bool IsNonPalletized { get; private set; }
        public bool IsDamaged { get; private set; }
        public bool IsVoluminous { get; private set; }
        public bool IsDangerous { get; private set; }

        public string? DangerousCode { get; private set; }
        public string? Classification { get; private set; }

        public decimal? IgnitionTemperature { get; private set; }
        public string? IgnitionTemperatureUnit { get; private set; }

        public Guid? IpasVesselDischargeId { get; private set; }
        public DateTime? IpasVesselDischargeReceivedAt { get; private set; }

        public decimal UnitWeight { get; private set; }

        public VesselDischarge()
        {
        }

        public VesselDischarge(
            string terminalCode,
            Guid storeId,
            Guid manifestItemId,
            Guid manifestContainerId,
            DateTime dischargeDate,
            long packNB,
            decimal weight,
            decimal volume,
            bool isNonPalletized = false,
            bool isDamaged = false,
            bool isVoluminous = false,
            bool isDangerous = false,
            string? dangerousCode = null,
            string? classification = null,
            decimal ignitionTemperature = 0,
            string? ignitionTemperatureUnit = null,
            Guid? ipasVesselDischargeId = null,
            DateTime? ipasVesselDischargeReceivedAt = null,
            decimal unitWeight = 0)
        {
            SetProperties(
                terminalCode,
                storeId,
                manifestItemId,
                manifestContainerId,
                dischargeDate,
                packNB,
                weight,
                volume,
                isNonPalletized,
                isDamaged,
                isVoluminous,
                isDangerous,
                dangerousCode,
                classification,
                ignitionTemperature,
                ignitionTemperatureUnit,
                ipasVesselDischargeId,
                ipasVesselDischargeReceivedAt,
                unitWeight);
        }

        public void Update(
            string terminalCode,
            Guid storeId,
            Guid manifestItemId,
            Guid manifestContainerId,
            DateTime dischargeDate,
            long packNB,
            decimal weight,
            decimal volume,
            bool isNonPalletized = false,
            bool isDamaged = false,
            bool isVoluminous = false,
            bool isDangerous = false,
            string? dangerousCode = null,
            string? classification = null,
            decimal ignitionTemperature = 0,
            string? ignitionTemperatureUnit = null,
            Guid? ipasVesselDischargeId = null,
            DateTime? ipasVesselDischargeReceivedAt = null,
            decimal unitWeight = 0)
        {
            SetProperties(
                terminalCode,
                storeId,
                manifestItemId,
                manifestContainerId,
                dischargeDate,
                packNB,
                weight,
                volume,
                isNonPalletized,
                isDamaged,
                isVoluminous,
                isDangerous,
                dangerousCode,
                classification,
                ignitionTemperature,
                ignitionTemperatureUnit,
                ipasVesselDischargeId,
                ipasVesselDischargeReceivedAt,
                unitWeight);
        }

        public void SetIpasReceived(Guid ipasVesselDischargeId, DateTime receivedAt)
        {
            if (ipasVesselDischargeId == Guid.Empty)
                throw new DomainValidationException("IpasVesselDischargeId is required.");

            if (receivedAt == default)
                throw new DomainValidationException("IpasVesselDischargeReceivedAt is required.");

            IpasVesselDischargeId = ipasVesselDischargeId;
            IpasVesselDischargeReceivedAt = receivedAt;
        }

        private void SetProperties(
            string terminalCode,
            Guid storeId,
            Guid manifestItemId,
            Guid manifestContainerId,
            DateTime dischargeDate,
            long packNB,
            decimal weight,
            decimal volume,
            bool isNonPalletized,
            bool isDamaged,
            bool isVoluminous,
            bool isDangerous,
            string? dangerousCode,
            string? classification,
            decimal ignitionTemperature,
            string? ignitionTemperatureUnit,
            Guid? ipasVesselDischargeId,
            DateTime? ipasVesselDischargeReceivedAt,
            decimal unitWeight)
        {
            Validate(
                terminalCode,
                storeId,
                manifestItemId,
                dischargeDate,
                packNB,
                weight,
                volume,
                isDangerous,
                dangerousCode,
                ignitionTemperature,
                ignitionTemperatureUnit,
                unitWeight);

            TerminalCode = terminalCode.Trim();
            StoreId = storeId;
            ManifestItemId = manifestItemId;
            ManifestContainerId = manifestContainerId;
            DischargeDate = dischargeDate;
            PackNB = packNB;
            Weight = weight;
            Volume = volume;

            IsNonPalletized = isNonPalletized;
            IsDamaged = isDamaged;
            IsVoluminous = isVoluminous;
            IsDangerous = isDangerous;

            DangerousCode = isDangerous ? dangerousCode?.Trim() : null;
            Classification = classification?.Trim();

            IgnitionTemperature = isDangerous ? ignitionTemperature : 0;
            IgnitionTemperatureUnit = isDangerous
                ? ignitionTemperatureUnit?.Trim()
                : null;

            IpasVesselDischargeId = ipasVesselDischargeId;
            IpasVesselDischargeReceivedAt = ipasVesselDischargeReceivedAt;
            UnitWeight = unitWeight;
        }

        private static void Validate(
            string terminalCode,
            Guid storeId,
            Guid manifestItemId,
            DateTime dischargeDate,
            long packNB,
            decimal weight,
            decimal volume,
            bool isDangerous,
            string? dangerousCode,
            decimal ignitionTemperature,
            string? ignitionTemperatureUnit,
            decimal unitWeight)
        {
            if (string.IsNullOrWhiteSpace(terminalCode))
                throw new DomainValidationException("TerminalCode is required.");

            if (storeId == Guid.Empty)
                throw new DomainValidationException("StoreId is required.");

            if (manifestItemId == Guid.Empty)
                throw new DomainValidationException("ManifestItemId is required.");
           
            if (dischargeDate == default)
                throw new DomainValidationException("DischargeDate is required.");

            if (dischargeDate > DateTime.UtcNow)
                throw new DomainValidationException("DischargeDate cannot be in the future.");

            if (packNB <= 0)
                throw new DomainValidationException("PackNB must be greater than zero.");

            if (weight <= 0)
                throw new DomainValidationException("Weight must be greater than zero.");

            if (volume < 0)
                throw new DomainValidationException("Volume cannot be negative.");

            if (unitWeight < 0)
                throw new DomainValidationException("UnitWeight cannot be negative.");

            if (isDangerous)
            {
                if (string.IsNullOrWhiteSpace(dangerousCode))
                    throw new DomainValidationException(
                        "DangerousCode is required when cargo is dangerous.");

                if (ignitionTemperature <= 0)
                    throw new DomainValidationException(
                        "IgnitionTemperature must be greater than zero for dangerous cargo.");

                if (string.IsNullOrWhiteSpace(ignitionTemperatureUnit))
                    throw new DomainValidationException(
                        "IgnitionTemperatureUnit is required for dangerous cargo.");
            }
        }
    }
}

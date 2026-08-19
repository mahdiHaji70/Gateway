using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class Manifest : BaseEntity
    {
        public string SerialNo { get; set; }
        public string ManifestRegistrationNumber { get; set; }
        public string VoyageNo { get; set; }
        public string NoticeNo { get; set; }
        public DateTime ETA { get; set; }
        public DateTime ETD { get; set; }
        public string ShipLine { get; set; }
        public string ShipAgent { get; set; }
        public string VesselName { get; set; }
        public string Imo { get; set; }
        public string TerminalCode { get; set; }

        public ICollection<ManifestItem> ManifestItems { get; private set; } = new List<ManifestItem>();

        public Manifest()
        {
            
        }
        public Manifest(
            string serialNo,
            string manifestRegistrationNumber,
            string voyageNo,
            string noticeNo,
            DateTime eta,
            DateTime etd,
            string shipLine,
            string shipAgent,
            string vesselName,
            string imo,
            string terminalCode)
        {
            SetProperty(
                serialNo,
                manifestRegistrationNumber,
                voyageNo,
                noticeNo,
                eta,
                etd,
                shipLine,
                shipAgent,
                vesselName,
                imo,
                terminalCode);
        }

        public void Update(
            string serialNo,
            string manifestRegistrationNumber,
            string voyageNo,
            string noticeNo,
            DateTime eta,
            DateTime etd,
            string shipLine,
            string shipAgent,
            string vesselName,
            string imo,
            string terminalCode)
        {
            SetProperty(
                serialNo,
                manifestRegistrationNumber,
                voyageNo,
                noticeNo,
                eta,
                etd,
                shipLine,
                shipAgent,
                vesselName,
                imo,
                terminalCode);
        }

        private void SetProperty(
            string serialNo,
            string manifestRegistrationNumber,
            string voyageNo,
            string noticeNo,
            DateTime eta,
            DateTime etd,
            string shipLine,
            string shipAgent,
            string vesselName,
            string imo,
            string terminalCode)
        {
            Validate(serialNo, manifestRegistrationNumber, voyageNo, noticeNo, eta, etd, terminalCode);

            SerialNo = serialNo;
            ManifestRegistrationNumber = manifestRegistrationNumber;
            VoyageNo = voyageNo;
            NoticeNo = noticeNo;
            ETA = eta;
            ETD = etd;
            ShipLine = shipLine;
            ShipAgent = shipAgent;
            VesselName = vesselName;
            Imo = imo;
            TerminalCode = terminalCode;
        }

        public void AddManifestItem(ManifestItem manifestItem) => ManifestItems.Add(manifestItem);

        private void Validate(
            string serialNo,
            string manifestRegistrationNumber,
            string voyageNo,
            string noticeNo,
            DateTime eta,
            DateTime etd,
            string terminalCode)
        {
            if (string.IsNullOrWhiteSpace(serialNo))
                throw new DomainValidationException("Serial number is required.");

            if (string.IsNullOrWhiteSpace(manifestRegistrationNumber))
                throw new DomainValidationException("Manifest registration number is required.");

            if (string.IsNullOrWhiteSpace(voyageNo))
                throw new DomainValidationException("Voyage number is required.");

            if (string.IsNullOrWhiteSpace(noticeNo))
                throw new DomainValidationException("Notice number is required.");

            if (eta == default)
                throw new DomainValidationException("ETA is required.");

            if (etd == default)
                throw new DomainValidationException("ETD is required.");

            if (etd < eta)
                throw new DomainValidationException("ETD cannot be earlier than ETA.");

            if (string.IsNullOrWhiteSpace(terminalCode))
                throw new DomainValidationException("Terminal code is required.");
        }
    }
}

using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class Voyage : BaseEntity
    {
        public string VoyageNo { get; private set; } = null!;
        public string NoticeNo { get; private set; } = null!;
        public DateTime ETA { get; private set; }
        public DateTime ETD { get; private set; }
        public string ShipLine { get; private set; } = null!;
        public string ShipAgent { get; private set; } = null!;
        public string VesselName { get; private set; } = null!;
        public string Imo { get; private set; } = null!;

        public Guid? IpasVoyageId { get; private set; }
        public DateTime? NoticeDate { get; private set; }

        private Voyage() { }

        public void SetIpasVoyage(Guid ipasVoyageId, DateTime noticeDate)
        {
            if (ipasVoyageId == Guid.Empty)
                throw new DomainValidationException("IPAS voyage ID is required.");
            if (noticeDate == default)
                throw new DomainValidationException("Notice date is required.");

            IpasVoyageId = ipasVoyageId;
            NoticeDate = noticeDate;
        }

        public Voyage(string voyageNo, string noticeNo, DateTime eta, DateTime etd,
            string shipLine, string shipAgent, string vesselName, string imo)
            => SetProperty(voyageNo, noticeNo, eta, etd, shipLine, shipAgent, vesselName, imo);

        public void Update(string voyageNo, string noticeNo, DateTime eta, DateTime etd,
            string shipLine, string shipAgent, string vesselName, string imo)
            => SetProperty(voyageNo, noticeNo, eta, etd, shipLine, shipAgent, vesselName, imo);

        private void SetProperty(string voyageNo, string noticeNo, DateTime eta, DateTime etd,
            string shipLine, string shipAgent, string vesselName, string imo)
        {
            Validate(voyageNo, noticeNo, eta, etd, shipLine, shipAgent, vesselName, imo);

            VoyageNo = voyageNo;
            NoticeNo = noticeNo;
            ETA = eta;
            ETD = etd;
            ShipLine = shipLine;
            ShipAgent = shipAgent;
            VesselName = vesselName;
            Imo = imo;
        }

        private void Validate(string voyageNo, string noticeNo, DateTime eta, DateTime etd,
            string shipLine, string shipAgent, string vesselName, string imo)
        {
            if (string.IsNullOrEmpty(voyageNo))
                throw new DomainValidationException("Voyage number is required.");
            if (string.IsNullOrEmpty(noticeNo))
                throw new DomainValidationException("Notice number is required.");
            if (eta == default)
                throw new DomainValidationException("ETA is required.");
            if (etd == default)
                throw new DomainValidationException("ETD is required.");
            if (string.IsNullOrEmpty(shipLine))
                throw new DomainValidationException("Ship line is required.");
            if (string.IsNullOrEmpty(shipAgent))
                throw new DomainValidationException("Ship agent is required.");
            if (string.IsNullOrEmpty(vesselName))
                throw new DomainValidationException("Vessel name is required.");
            if (string.IsNullOrEmpty(imo))
                throw new DomainValidationException("IMO is required.");
        }
    }
}

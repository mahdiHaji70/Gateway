
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class Declaration : BaseEntity
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string TerminalCode { get; set; }

        public Guid TrafficId { get; set; }
        public Traffic Traffic { get; set; }

        public Guid ConsigneeId { get; set; }
        public Company Consignee { get; set; }

        public Guid ConsigneeRepId { get; set; }
        public Company ConsigneeRep { get; set; }

        public Guid? IpasDeclarationId { get; private set; }
        public string? IpasDeclarationNo { get; private set; }
        public DateTime? IpasDeclarationReceivedAt { get; private set; }

        public ICollection<DeclarationItem> DeclarationItems { get; private set; } = new List<DeclarationItem>();


        public Declaration(
            string number,
            DateTime date,
            DateTime startDate,
            DateTime endDate,
            Guid consigneeId,
            Guid consigneeRepId,
            Guid trafficId,
            string description,
            string terminalCode)
        {
            Validate(number, date, startDate, endDate, consigneeId, consigneeRepId, trafficId, description, terminalCode);

            Number = number;
            Date = date;
            StartDate = startDate;
            EndDate = endDate;
            ConsigneeId = consigneeId;
            ConsigneeRepId = consigneeRepId;
            TrafficId = trafficId;
            Description = description;
            TerminalCode = terminalCode;
        }

        public void Update(
            string number,
            DateTime date,
            DateTime startDate,
            DateTime endDate,
            Guid consigneeId,
            Guid consigneeRepId,
            Guid trafficId,
            string description,
            string terminalCode)
        {
            Validate(number, date, startDate, endDate, consigneeId, consigneeRepId, trafficId, description, terminalCode);

            Number = number;
            Date = date;
            StartDate = startDate;
            EndDate = endDate;
            ConsigneeId = consigneeId;
            ConsigneeRepId = consigneeRepId;
            TrafficId = trafficId;
            Description = description;
            TerminalCode = terminalCode;
        }

        public void SetIpasDeclarationId(Guid ipasDeclarationId, string ipasDeclarationNo)
        {
            if (ipasDeclarationId == Guid.Empty)
                throw new DomainValidationException("Ipas Declaration Id id cannot be empty.");

            if (string.IsNullOrWhiteSpace(ipasDeclarationNo))
                throw new DomainValidationException("Ipas Declaration no cannot be empty.");

            if (!string.IsNullOrWhiteSpace(IpasDeclarationNo))
                throw new DomainValidationException("Ipas Declaration no has already been assigned.");

            IpasDeclarationId = ipasDeclarationId;
            IpasDeclarationNo = ipasDeclarationNo;
            IpasDeclarationReceivedAt = DateTime.Now;
        }

        private void Validate(string number, DateTime date, DateTime startDate, DateTime EndDate,
        Guid consigneeId, Guid consigneeRepId, Guid trafficId, string description, string terminalCode)
        {
            if (string.IsNullOrEmpty(number))
                throw new DomainValidationException("Number is required.");

            if (date.Equals(DateTime.MinValue))
                throw new DomainValidationException("Date invalid.");

            if (startDate.Equals(DateTime.MinValue))
                throw new DomainValidationException("Start date invalid.");

            if (EndDate.Equals(DateTime.MinValue))
                throw new DomainValidationException("End date invalid.");

            if (consigneeId == Guid.Empty)
                throw new DomainValidationException("Consignee Id is required.");

            if (consigneeRepId == Guid.Empty)
                throw new DomainValidationException("Consignee rep Id is required.");

            if (trafficId == Guid.Empty)
                throw new DomainValidationException("Traffic Id is required.");

            if (string.IsNullOrEmpty(terminalCode))
                throw new DomainValidationException("Terminal code is required.");
        }
    }
}

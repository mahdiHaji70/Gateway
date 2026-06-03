
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class Declaration : BaseEntity
    {
        public string Number { get; set; }
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

        public string? IpasDeclarationId { get; private set; }
        public DateTime? IpasDeclarationIdReceivedAt { get; private set; }

        public ICollection<DeclarationItem> DeclarationItems { get; private set; } = new List<DeclarationItem>();


        public Declaration(
            string number,
             DateTime startDate,
             DateTime endDate,
            Guid consigneeId,
            Guid consigneeRepId,
            Guid trafficId,
            string description,
            string terminalCode)
        {
            Validate(number, startDate, endDate, consigneeId, consigneeRepId, trafficId, description, terminalCode);

            Number = number;
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
             DateTime startDate,
             DateTime endDate,
            Guid consigneeId,
            Guid consigneeRepId,
            Guid trafficId,
            string description,
            string terminalCode)
        {
            Validate(number, startDate, endDate, consigneeId, consigneeRepId, trafficId, description, terminalCode);

            Number = number;
            StartDate = startDate;
            EndDate = endDate;
            ConsigneeId = consigneeId;
            ConsigneeRepId = consigneeRepId;
            TrafficId = trafficId;
            Description = description;  
            TerminalCode = terminalCode;
        }

        public void SetIpasDeclarationId(string ipasDeclarationId)
        {
            if (string.IsNullOrWhiteSpace(ipasDeclarationId))
                throw new DomainValidationException("Ipas Declaration Id id cannot be empty.");

            if (!string.IsNullOrWhiteSpace(IpasDeclarationId))
                throw new DomainValidationException("Ipas Declaration Id has already been assigned.");

            IpasDeclarationId = ipasDeclarationId;
            IpasDeclarationIdReceivedAt = DateTime.UtcNow;
        }

        private void Validate(string number, DateTime startDate, DateTime EndDate,
        Guid consigneeId, Guid consigneeRepId, Guid trafficId, string description, string terminalCode)
        {
            if (string.IsNullOrEmpty(number))
                throw new DomainValidationException("Number is required.");

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

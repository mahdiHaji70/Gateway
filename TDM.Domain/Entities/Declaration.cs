
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class Declaration : BaseEntity
    {
        public string Number { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid ConsigneeId { get; set; }
        public Company Consignee { get; set; }

        public Guid ConsigneeRepId { get; set; }
        public Company ConsigneeRep { get; set; }

        public Declaration(
            string number,
             DateTime startDate,
             DateTime endDate,
            Guid consigneeId,
            Guid consigneeRepId)
        {
            Validate(number, startDate, endDate, consigneeId, consigneeRepId);

            Number = number;
            StartDate = startDate;
            EndDate = endDate;
            ConsigneeId = consigneeId;
            ConsigneeRepId = consigneeRepId;
        }

        public void Update(
            string number,
             DateTime startDate,
             DateTime endDate,
            Guid consigneeId,
            Guid consigneeRepId)
        {
            Validate(number, startDate, endDate, consigneeId, consigneeRepId);

            Number = number;
            StartDate = startDate;
            EndDate = endDate;
            ConsigneeId = consigneeId;
            ConsigneeRepId = consigneeRepId;
        }

        private void Validate(string number, DateTime startDate, DateTime EndDate,
        Guid consigneeId, Guid consigneeRepId)
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
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class StoreReceiptHead : BaseEntity
    {
        public string TerminalCode { get; set; }
        public string IPASStoreReceiptNo { get; set; }
        public DateTime IssueDate { get; set; }
        public Guid ConsigneeId { get; set; }
        public Company Consignee { get; set; }
        public Guid ConsigneeRepId { get; set; }
        public Company ConsigneeRep { get; set; }
        public Guid CargoTypeId { get; set; }
        public CargoType CargoType { get; set; }
        public DateTime? FirstDischargeDate { get; set; }
        public Guid CreatorId { get; set; }
        public Company Creator { get; set; }
        public Guid TrafficId { get; set; }
        public Traffic Traffic { get; set; }
        public Guid StoreReceiptStateId { get; set; }
        public StoreReceiptState StoreReceiptState { get; set; }
        public Guid? RequestId { get; set; }
        public string VoyageNoticeNo { get; set; }
        public Guid ArrivalTypeId { get; set; }
        public ArrivalType ArrivalType { get; set; }
        public Guid? DeclarationId { get; set; }
        public Declaration? Declaration { get; set; } 
        public Guid? BillOfLadingId { get; set; }
        public ICollection<StoreReceiptGood> StoreReceiptGoods { get; private set; } = new List<StoreReceiptGood>();
        public ICollection<StoreReceiptContainer> StoreReceiptContainers { get; private set; } = new List<StoreReceiptContainer>();

        protected StoreReceiptHead()
        {
        }

        public StoreReceiptHead(
            string terminalCode,
            string ipasStoreReceiptNo,
            DateTime issueDate,
            Guid consigneeId,
            Guid consigneeRepId,
            Guid cargoTypeId,
            DateTime? firstDischargeDate,
            Guid creatorId,
            Guid trafficId,
            Guid storeReceiptStateId,
            Guid? requestId,
            string voyageNoticeNo,
            Guid arrivalTypeId,
            Guid? declarationId,
            Guid? billOfLadingId)
        {
            SetProperty(
                terminalCode,
                ipasStoreReceiptNo,
                issueDate,
                consigneeId,
                consigneeRepId,
                cargoTypeId,
                firstDischargeDate,
                creatorId,
                trafficId,
                storeReceiptStateId,
                requestId,
                voyageNoticeNo,
                arrivalTypeId,
                declarationId,
                billOfLadingId);
        }

        public void Update(
            string terminalCode,
            string ipasStoreReceiptNo,
            DateTime issueDate,
            Guid consigneeId,
            Guid consigneeRepId,
            Guid cargoTypeId,
            DateTime? firstDischargeDate,
            Guid creatorId,
            Guid trafficId,
            Guid storeReceiptStateId,
            Guid? requestId,
            string voyageNoticeNo,
            Guid arrivalTypeId,
            Guid? declarationId,
            Guid? billOfLadingId)
        {
            SetProperty(
                terminalCode,
                ipasStoreReceiptNo,
                issueDate,
                consigneeId,
                consigneeRepId,
                cargoTypeId,
                firstDischargeDate,
                creatorId,
                trafficId,
                storeReceiptStateId,
                requestId,
                voyageNoticeNo,
                arrivalTypeId,
                declarationId,
                billOfLadingId);
        }

        private void SetProperty(
            string terminalCode,
            string ipasStoreReceiptNo,
            DateTime issueDate,
            Guid consigneeId,
            Guid consigneeRepId,
            Guid cargoTypeId,
            DateTime? firstDischargeDate,
            Guid creatorId,
            Guid trafficId,
            Guid storeReceiptStateId,
            Guid? requestId,
            string voyageNoticeNo,
            Guid arrivalTypeId,
            Guid? declarationId,
            Guid? billOfLadingId)
        {
            Validate(
                terminalCode,
                ipasStoreReceiptNo,
                issueDate,
                consigneeId,
                consigneeRepId,
                cargoTypeId,
                creatorId,
                trafficId,
                storeReceiptStateId,
                voyageNoticeNo,
                arrivalTypeId,
                declarationId,
                billOfLadingId);

            TerminalCode = terminalCode;
            IPASStoreReceiptNo = ipasStoreReceiptNo;
            IssueDate = issueDate;
            ConsigneeId = consigneeId;
            ConsigneeRepId = consigneeRepId;
            CargoTypeId = cargoTypeId;
            FirstDischargeDate = firstDischargeDate;
            CreatorId = creatorId;
            TrafficId = trafficId;
            StoreReceiptStateId = storeReceiptStateId;
            RequestId = requestId;
            VoyageNoticeNo = voyageNoticeNo;
            ArrivalTypeId = arrivalTypeId;
            DeclarationId = declarationId;
            BillOfLadingId = billOfLadingId;
        }

        private void Validate(
            string terminalCode,
            string ipasStoreReceiptNo,
            DateTime issueDate,
            Guid consigneeId,
            Guid consigneeRepId,
            Guid cargoTypeId,
            Guid creatorId,
            Guid trafficId,
            Guid storeReceiptStateId,
            string voyageNoticeNo,
            Guid arrivalTypeId,
            Guid? declarationId,
            Guid? billOfLadingId)
        {
            if (string.IsNullOrWhiteSpace(terminalCode))
                throw new DomainValidationException("Terminal code is required.");

            if (string.IsNullOrWhiteSpace(ipasStoreReceiptNo))
                throw new DomainValidationException("IPAS Store Receipt No is required.");

            if (issueDate == default)
                throw new DomainValidationException("Issue date is required.");

            if (consigneeId == Guid.Empty)
                throw new DomainValidationException("Consignee is required.");

            if (consigneeRepId == Guid.Empty)
                throw new DomainValidationException("Consignee representative is required.");

            if (cargoTypeId == Guid.Empty)
                throw new DomainValidationException("Cargo type is required.");

            if (creatorId == Guid.Empty)
                throw new DomainValidationException("Creator is required.");

            if (trafficId == Guid.Empty)
                throw new DomainValidationException("Traffic is required.");

            if (storeReceiptStateId == Guid.Empty)
                throw new DomainValidationException("Store receipt state is required.");

            if (string.IsNullOrWhiteSpace(voyageNoticeNo))
                throw new DomainValidationException("Voyage notice number is required.");

            if (arrivalTypeId == Guid.Empty)
                throw new DomainValidationException("Arrival type is required.");

            if (!declarationId.HasValue && !billOfLadingId.HasValue)
                throw new DomainValidationException("Either DeclarationId or BillOfLadingId must be provided.");
        }
    

}
}

using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class StoreReceiptHead : BaseEntity
    {
        private readonly List<StoreReceiptGood> _storeReceiptGoods = [];
        private readonly List<StoreReceiptContainer> _storeReceiptContainers = [];

        public string TerminalCode { get; private set; }
        public string IPASStoreReceiptNo { get; private set; }
        public DateTime IssueDate { get; private set; }
        public Guid ConsigneeId { get; private set; }
        public Company Consignee { get; private set; }
        public Guid ConsigneeRepId { get; private set; }
        public Company ConsigneeRep { get; private set; }
        public Guid CargoTypeId { get; private set; }
        public CargoType CargoType { get; private set; }
        public DateTime? FirstDischargeDate { get; private set; }
        public Guid CreatorId { get; private set; }
        public Company Creator { get; private set; }
        public Guid TrafficId { get; private set; }
        public Traffic Traffic { get; private set; }
        public Guid StoreReceiptStateId { get; private set; }
        public StoreReceiptState StoreReceiptState { get; private set; }
        public Guid? RequestId { get; private set; }
        public string VoyageNoticeNo { get; private set; }
        public Guid ArrivalTypeId { get; private set; }
        public ArrivalType ArrivalType { get; private set; }
        public Guid? DeclarationId { get; private set; }
        public Declaration? Declaration { get; private set; }
        public Guid? BillOfLadingId { get; private  set; }
        public IReadOnlyCollection<StoreReceiptGood> StoreReceiptGoods
         => _storeReceiptGoods.AsReadOnly();

        public IReadOnlyCollection<StoreReceiptContainer> StoreReceiptContainers
            => _storeReceiptContainers.AsReadOnly();

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
        public StoreReceiptGood AddGood(
                    Guid commodityId,
                    Guid packageId,
                    string brandName,
                    bool noBrandName,
                    decimal packNB,
                    decimal grossWeight,
                    decimal netWeight,
                    decimal volume,
                    string remark,
                    bool isHeavy,
                    bool isNonPalletized,
                    bool isDamaged,
                    bool isVoluminous,
                    bool isDangerous,
                    bool dangerousNotNoticed,
                    string dangerousCode,
                    string classification,
                    decimal ignitionTemperature,
                    string ignitionTemperatureUnit)
        {
            var good = new StoreReceiptGood(
                Id,
                commodityId,
                packageId,
                brandName,
                noBrandName,
                packNB,
                grossWeight,
                netWeight,
                volume,
                remark,
                isHeavy,
                isNonPalletized,
                isDamaged,
                isVoluminous,
                isDangerous,
                dangerousNotNoticed,
                dangerousCode,
                classification,
                ignitionTemperature,
                ignitionTemperatureUnit);

            _storeReceiptGoods.Add(good);

            return good;
        }

        public StoreReceiptContainer AddContainer(
                                    Guid containerId,
                                    string sealNumber,
                                    string remark,
                                    string dangerousCode,
                                    string classification,
                                    decimal ignitionTemperature,
                                    string ignitionTemperatureUnit)
        {
            var container = new StoreReceiptContainer(
                Id,
                containerId,
                sealNumber,
                remark,
                dangerousCode,
                classification,
                ignitionTemperature,
                ignitionTemperatureUnit);

            _storeReceiptContainers.Add(container);

            return container;
        }


    }
}

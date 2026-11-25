using System;
using System.Collections.Generic;
using TDM.Domain.Common;

namespace TDM.Domain.Entities
{
    public class StoreExitDocument : BaseEntity
    {
        private readonly List<StoreReceiptOperation> _storeReceiptOperations = [];

        public string Serial { get; set; }
        public string VehicleNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public Guid? LoadingPermitId { get; set; }
        public Guid? VoyageId { get; set; }
        public Voyage? Voyage { get; set; }

        public Guid? IpasVesselLoadingId { get; set; }
        public Guid? IpasDeliveryId { get; set; }
        public int? IpasDeliverySerialNo { get; set; }

        public IReadOnlyCollection<StoreReceiptOperation> StoreReceiptOperations => _storeReceiptOperations.AsReadOnly();
    }
}

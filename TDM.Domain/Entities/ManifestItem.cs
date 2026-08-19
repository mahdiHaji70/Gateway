using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class ManifestItem : BaseEntity
    {
        public string ManifestItemNo { get; set; }
        public string ManifestNo { get; set; }
        public string Consignor { get; set; }
        public string ShipLine { get; set; }

        public Guid ManifestId { get; set; }
        public Manifest Manifest { get; set; }

        public Guid TrafficId { get; set; }
        public Traffic Traffic { get; set; }

        public Guid ConsigneeId { get; set; }
        public Company Consignee { get; set; }

        public Guid ShipAgentId { get; set; }
        public Company ShipAgent { get; set; }

        public ICollection<ManifestGood> ManifestGoods { get; private set; } = new List<ManifestGood>();
        public ICollection<ManifestContainer> ManifestContainers { get; private set; } = new List<ManifestContainer>();

        public ManifestItem()
        {
            
        }

        public ManifestItem(
            string manifestItemNo,
            string manifestNo,
            string consignor,
            string shipLine,
            Guid trafficId,
            Guid consigneeId,
            Guid shipAgentId)
        {
            SetProperty(
                manifestItemNo,
                manifestNo,
                consignor,
                shipLine,
                trafficId,
                consigneeId,
                shipAgentId);
        }

        public void Update(
            string manifestItemNo,
            string manifestNo,
            string consignor,
            string shipLine,
            Guid trafficId,
            Guid consigneeId,
            Guid shipAgentId)
        {
            SetProperty(
                manifestItemNo,
                manifestNo,
                consignor,
                shipLine,
                trafficId,
                consigneeId,
                shipAgentId);
        }

        private void SetProperty(
            string manifestItemNo,
            string manifestNo,
            string consignor,
            string shipLine,
            Guid trafficId,
            Guid consigneeId,
            Guid shipAgentId)
        {
            Validate(
                manifestItemNo,
                manifestNo,
                trafficId,
                consigneeId,
                shipAgentId);

            ManifestItemNo = manifestItemNo;
            ManifestNo = manifestNo;
            Consignor = consignor;
            ShipLine = shipLine;
            TrafficId = trafficId;
            ConsigneeId = consigneeId;
            ShipAgentId = shipAgentId;
        }

        public void AddManifestGood(ManifestGood manifestGood) => ManifestGoods.Add(manifestGood);

        public void AddManifestContainer(ManifestContainer manifestContainer) => ManifestContainers.Add(manifestContainer);

        private void Validate(
            string manifestItemNo,
            string manifestNo,
            Guid trafficId,
            Guid consigneeId,
            Guid shipAgentId)
        {            
            if (string.IsNullOrWhiteSpace(manifestItemNo))
                throw new DomainValidationException("Manifest item number is required.");

            if (string.IsNullOrWhiteSpace(manifestNo))
                throw new DomainValidationException("Manifest number is required.");

            if (trafficId == Guid.Empty)
                throw new DomainValidationException("Traffic is required.");

            if (consigneeId == Guid.Empty)
                throw new DomainValidationException("Consignee is required.");

            if (shipAgentId == Guid.Empty)
                throw new DomainValidationException("Ship agent is required.");
        }
    }
}

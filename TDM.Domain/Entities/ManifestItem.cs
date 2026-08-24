using System;
using System.Collections.Generic;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class ManifestItem : BaseEntity
    {
        public string ManifestItemNo { get; private set; } = null!;
        public string ManifestNo { get; private set; } = null!;
        public string? Consignor { get; private set; }
        public string? ShipLine { get; private set; }

        public Guid ManifestId { get; private set; }
        public Manifest Manifest { get; private set; } = null!;

        public Guid TrafficId { get; private set; }
        public Traffic Traffic { get; private set; } = null!;

        public Guid ConsigneeId { get; private set; }
        public Company Consignee { get; private set; } = null!;

        public Guid ShipAgentId { get; private set; }
        public Company ShipAgent { get; private set; } = null!;

        public Guid CargoTypeId { get; private set; }
        public CargoType CargoType { get; private set; } = null!;

        public Guid IpasItemId { get; private set; }

        public ICollection<ManifestGood> ManifestGoods { get; private set; }
            = new List<ManifestGood>();

        public ICollection<ManifestContainer> ManifestContainers { get; private set; }
            = new List<ManifestContainer>();

        public ICollection<VesselDischarge> ManifestItemVesselDischarges { get; private set; }
            = new List<VesselDischarge>();

        private ManifestItem()
        {
        }

        public ManifestItem(
            string manifestItemNo,
            string manifestNo,
            string? consignor,
            string? shipLine,
            Guid trafficId,
            Guid consigneeId,
            Guid shipAgentId,
            Guid cargoTypeId,
            Guid ipasItemId)
        {
            SetProperties(
                manifestItemNo,
                manifestNo,
                consignor,
                shipLine,
                trafficId,
                consigneeId,
                shipAgentId,
                cargoTypeId,
                ipasItemId);
        }

        public void Update(
            string manifestItemNo,
            string manifestNo,
            string? consignor,
            string? shipLine,
            Guid trafficId,
            Guid consigneeId,
            Guid shipAgentId,
            Guid cargoTypeId,
            Guid ipasItemId)
        {
            SetProperties(
                manifestItemNo,
                manifestNo,
                consignor,
                shipLine,
                trafficId,
                consigneeId,
                shipAgentId,
                cargoTypeId,
                ipasItemId);
        }

        private void SetProperties(
            string manifestItemNo,
            string manifestNo,
            string? consignor,
            string? shipLine,
            Guid trafficId,
            Guid consigneeId,
            Guid shipAgentId,
            Guid cargoTypeId,
            Guid ipasItemId)
        {
            Validate(
                manifestItemNo,
                manifestNo,
                trafficId,
                consigneeId,
                shipAgentId,
                cargoTypeId,
                ipasItemId);

            ManifestItemNo = manifestItemNo.Trim();
            ManifestNo = manifestNo.Trim();
            Consignor = consignor?.Trim();
            ShipLine = shipLine?.Trim();

            TrafficId = trafficId;
            ConsigneeId = consigneeId;
            ShipAgentId = shipAgentId;
            CargoTypeId = cargoTypeId;
            IpasItemId = ipasItemId;
        }

        public void AddManifestGood(ManifestGood manifestGood)
        {
            if (manifestGood is null)
                throw new DomainValidationException("Manifest good is required.");

            ManifestGoods.Add(manifestGood);
        }

        public void AddManifestContainer(ManifestContainer manifestContainer)
        {
            if (manifestContainer is null)
                throw new DomainValidationException("Manifest container is required.");

            ManifestContainers.Add(manifestContainer);
        }

        private static void Validate(
            string manifestItemNo,
            string manifestNo,
            Guid trafficId,
            Guid consigneeId,
            Guid shipAgentId,
            Guid cargoTypeId,
            Guid ipasItemId)
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

            if (cargoTypeId == Guid.Empty)
                throw new DomainValidationException("Cargo type is required.");

            if (ipasItemId == Guid.Empty)
                throw new DomainValidationException("IpasItemId is required.");
        }
    }
}

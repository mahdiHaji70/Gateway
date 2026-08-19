using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class ManifestContainer : BaseEntity
    {
        public Guid ContainerId { get; set; }
        public Container Container { get; set; }

        public Guid ManifestItemId { get; set; }
        public ManifestItem ManifestItem { get; set; }

        public Guid? BillOfLadingId { get; set; }
        public string SealNumber { get; set; }
        public string? DangerousCode { get; set; }
        public string? Classification { get; set; }
        public decimal? IgnitionTemperature { get; set; }
        public string? IgnitionTemperatureUnit { get; set; }

        public ICollection<ManifestContainerGood> ManifestContainerGoods { get; private set; } = new List<ManifestContainerGood>();

        public ManifestContainer()
        {
            
        }

        public ManifestContainer(
            Guid containerId,
            Guid? billOfLadingId,
            string sealNumber,
            string dangerousCode,
            string classification,
            decimal? ignitionTemperature,
            string ignitionTemperatureUnit)
        {
            SetProperty(
                containerId,
                billOfLadingId,
                sealNumber,
                dangerousCode,
                classification,
                ignitionTemperature,
                ignitionTemperatureUnit);
        }

        public void Update(
            Guid containerId,
            Guid? billOfLadingId,
            string sealNumber,
            string dangerousCode,
            string classification,
            decimal? ignitionTemperature,
            string ignitionTemperatureUnit)
        {
            SetProperty(
                containerId,
                billOfLadingId,
                sealNumber,
                dangerousCode,
                classification,
                ignitionTemperature,
                ignitionTemperatureUnit);
        }

        private void SetProperty(
            Guid containerId,
            Guid? billOfLadingId,
            string sealNumber,
            string dangerousCode,
            string classification,
            decimal? ignitionTemperature,
            string ignitionTemperatureUnit)
        {
            Validate(containerId);

            ContainerId = containerId;
            BillOfLadingId = billOfLadingId;
            SealNumber = sealNumber;
            DangerousCode = dangerousCode;
            Classification = classification;
            IgnitionTemperature = ignitionTemperature;
            IgnitionTemperatureUnit = ignitionTemperatureUnit;
        }

        public void AddManifestContainerGood(ManifestContainerGood manifestContainerGood) => ManifestContainerGoods.Add(manifestContainerGood);

        private void Validate(Guid containerId)
        {
            if (containerId == Guid.Empty)
                throw new DomainValidationException("Container is required.");
           
        }
    }
}

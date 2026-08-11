using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.Manifests.DTOs
{
    public class ManifestContainerDto
    {
        public Guid ContainerId { get; set; }
        public string ContainerNo { get; set; }
        public string ContainerTypeAndSizeCode { get; set; }

        public Guid ManifestItemId { get; set; }

        public Guid? BillOfLadingId { get; set; }
        public string SealNumber { get; set; }
        public string DangerousCode { get; set; }
        public string Classification { get; set; }
        public decimal IgnitionTemperature { get; set; }
        public string IgnitionTemperatureUnit { get; set; }

        public List<ManifestContainerGoodDto> ManifestContainerGoods { get; set; }
    }
}

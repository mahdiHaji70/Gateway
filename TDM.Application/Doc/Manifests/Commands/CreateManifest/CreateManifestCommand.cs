using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.Manifests.Commands.CreateManifest
{
    public class CreateManifestCommand : IRequest<Guid>
    {
        public string SerialNo { get; set; }
        public string ManifestRegistrationNumber { get; set; }
        public string VoyageNo { get; set; }
        public string NoticeNo { get; set; }
        public DateTime ETA { get; set; }
        public DateTime ETD { get; set; }
        public string ShipLine { get; set; }
        public string ShipAgent { get; set; }
        public string VesselName { get; set; }
        public string Imo { get; set; }
        public string TerminalCode { get; set; }

        public List<CreateManifestItemCommand> ManifestItems { get; set; }
    }

    public class CreateManifestItemCommand
    {
        public string ManifestItemNo { get; set; }
        public string ManifestNo { get; set; }
        public string? Consignor { get; set; }
        public string ShipLine { get; set; }
        public string TrafficCode { get; set; }
        public string ConsigneeNationalId { get; set; }
        public string ShipAgentNationalId { get; set; }

        public List<CreateManifestGoodCommand> ManifestGoods { get; set; }
        public List<CreateManifestContainerCommand> ManifestContainers { get; set; }

    }

    public class CreateManifestGoodCommand
    {
        public long PackNb { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public decimal Volume { get; set; }
        public string? BrandName { get; set; }
        public string Description { get; set; }
        public string HSCode { get; set; }
        public string? PackageCode { get; set; }
    }

    public class CreateManifestContainerCommand
    {
        public string ContainerNo { get; set; }
        public Guid? BillOfLadingId { get; set; }
        public string TypeCode { get; set; }
        public string SealNumber { get; set; }
        public string? DangerousCode { get; set; }
        public string? Classification { get; set; }
        public decimal? IgnitionTemperature { get; set; }
        public string? IgnitionTemperatureUnit { get; set; }

        public List<CreateManifestContainerGoodCommand> ManifestContainerGoods { get; set; }

    }

    public class CreateManifestContainerGoodCommand
    {
        public long PackNb { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public string HSCode { get; set; }
        public string PackageCode { get; set; }
    }
}

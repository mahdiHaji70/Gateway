using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Infrastructure.Integrations.Responses
{
    public class ManifestContainerResponseDto
    {
        public Guid Id { get; set; }
        public Guid BillOfLadingId { get; set; }
        public string No { get; set; }
        public decimal PackageCount { get; set; }
        public string Type { get; set; }
        public string TypeCode { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string SealNumber { get; set; }
        public string Sealer { get; set; }
        public string SealState { get; set; }
        public decimal PackageQuantity { get; set; }
        public string ContainerState { get; set; }
        public string MovementType { get; set; }
        public string DangerousCode { get; set; }
        public string DangerousClassification { get; set; }
        public string TemperatureType { get; set; }
        public decimal TemperatureValue { get; set; }
        public string TemperatureUnitOfMeasurement { get; set; }
        public decimal IgnitionTemperature { get; set; }
        public string IgnitionTemperatureUnit { get; set; }
        public string RepresentativeOfContainerOwner { get; set; }
        public string ContainerOwner { get; set; }
        public List<ManifestContainerGoodResponseDto> Goods { get; set; }
    }
}

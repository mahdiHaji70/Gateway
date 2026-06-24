using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Containers.DTOs;

namespace TDM.Infrastructure.Integrations.Responses
{
    public class GoodwayBillsResponseDto
    {
        public string Id { get; set; }
        public int SerialNo { get; set; }
        public Guid? StorageAgreementId { get; set; }
        public string? StorageAgreementNo { get; set; }
        public DateTime? StorageAgreementDate { get; set; }
        public Guid TerminalId { get; set; }
        public string? TerminalCode { get; set; }
        public string? Terminal { get; set; }
        public string? BlNo { get; set; }
        public DateTime Date { get; set; }
        public string? VehiclePlateNo { get; set; }
        public string? VehicleDriverName { get; set; }
        public string? VehicleDriverCardNo { get; set; }
        public string? VehicleDriverPhone { get; set; }
        public string? WagonNo { get; set; }
        public string? WagonOwner { get; set; }
        public List<BulkResponseDto>? BulkList { get; set; }
        public List<GeneralCargoResponseDto>? CargoList { get; set; }
        public List<ContainerResponseDto>? ContainerList { get; set; }
    }
}

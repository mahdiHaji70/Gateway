using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.BasicInformation.Containers.DTOs
{
    public class ContainerDto
    {
        public Guid Id { get; set; }
        public string? No { get; set; }

        public Guid ContainerTypeAndSizeId { get; set; }
        public string? ContainerTypeAndSize { get; set; }
        public string? ContainerTypeAndSizeCode { get; set; }
    }
}

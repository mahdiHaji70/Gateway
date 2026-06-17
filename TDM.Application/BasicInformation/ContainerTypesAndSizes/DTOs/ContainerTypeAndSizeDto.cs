using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.BasicInformation.ContainerTypesAndSizes.DTOs
{
    public class ContainerTypeAndSizeDto
    {
        public Guid Id { get; set; }
        public string? TypeAndSize { get; set; }
        public string? TypeAndSizeCode { get; set; }
    }
}

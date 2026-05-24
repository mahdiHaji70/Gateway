using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.BasicInformation.Packages.DTOs
{
    public class PackageDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? code { get; set; }
    }
}

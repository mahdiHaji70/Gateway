using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.DeclarationItems.DTOs
{
    public class DeclarationItemDto
    {
        public Guid Id { get; set; }
        public long Quantity { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }

        public Guid DeclarationId { get; set; }
        public string? IpasDeclarationNo { get; set; }

        public Guid CommodityId { get; set; }
        public string? CommodityName { get; set; }

        public Guid PackageId { get; set; }
        public string? PackageName { get; set; }

        public Guid CargoId { get; set; }
        public string? CargoTypeName { get; set; }
        public List<DeclarationContainerDto>? DeclarationContainers { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.Declarations.DTOs
{
    public class DeclarationDto
    {
        public Guid Id { get; set; }
        public string? Number { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid ConsigneeId{ get; set; }
        public string? ConsigneeName{ get; set; }

        public Guid ConsigneeRepId { get; set; }
        public string? ConsigneeRepName{ get;set; }
    }
}

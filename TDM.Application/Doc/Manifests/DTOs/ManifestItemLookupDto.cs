using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.Manifests.DTOs
{
    public class ManifestItemLookupDto
    {
        public Guid Id { get; set; }
        public Guid ManifestItemId { get; set; }
        public string VoyageNo { get; set; }
        public string ManifestNo { get; set; }
    }
}

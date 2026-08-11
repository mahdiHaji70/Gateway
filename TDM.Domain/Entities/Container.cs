using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class Container : BaseEntity
    {
        public string No { get; set; }

        public Guid ContainerTypeAndSizeId { get; set; }
        public ContainerTypeAndSize ContainerTypeAndSize { get; set; }

        public ICollection<Container> ContainerDeclarations { get; private set; } = new List<Container>();
        public ICollection<StoreReceiptContainer> ContainerStoreReceipts { get; private set; } = new List<StoreReceiptContainer>();
        public ICollection<ManifestContainer> ContainerManifests { get; private set; } = new List<ManifestContainer>();


        public Container(string no, Guid containerTypeAndSizeId)
        {
            Validate(no, containerTypeAndSizeId);

            No = no;
            ContainerTypeAndSizeId = containerTypeAndSizeId;
        }

        public void Update(string no, Guid containerTypeAndSizeId)
        {
            Validate(no, containerTypeAndSizeId);

            No = no;
            ContainerTypeAndSizeId = containerTypeAndSizeId;
        }

        private void Validate(string no, Guid containerTypeAndSizeId)
        {
            if (string.IsNullOrEmpty(no))
                throw new DomainValidationException("No is required.");

            if (containerTypeAndSizeId == Guid.Empty)
                throw new DomainValidationException("Container Type And Size Id is required.");
        }
    }
}

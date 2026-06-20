using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.BasicInformation.Stores.DTOs
{
    public class StoreDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid StoreTypeId { get; set; }
        public string StoreTypeName { get; set; }

    }
}

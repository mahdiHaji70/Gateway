using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Domain.Enums
{
    public static class CargoTypes
    {
      
        public static readonly Guid GeneralCargo =
            Guid.Parse("23cb57c1-c7ff-47dc-a74d-08decb64a457");

        public static readonly Guid Bulk =
            Guid.Parse("247ad1d0-085d-49a9-5455-08dee1c5f5d8");

        public static readonly Guid Container =
            Guid.Parse("509ac105-798a-483c-b3f5-2979889a375e");
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Domain.Enums
{
    public static class CargoTypes
    {
        public static readonly Guid LiquidBulk =
            Guid.Parse("00125244-cd02-4898-9e92-1a1da1027d78");

        public static readonly Guid GeneralCargo =
            Guid.Parse("fc2dd551-d356-407f-806d-1dc8ff48de6c");

        public static readonly Guid Bulk =
            Guid.Parse("9477fa31-b85e-4338-91b0-95a028c23e84");

        public static readonly Guid Container =
            Guid.Parse("509ac105-798a-483c-b3f5-2979889a375e");
    }
}

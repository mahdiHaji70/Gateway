using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.StoreReceiptContainerGoods.Commands.UpdateStoreReceiptContainerGood
{
    public class UpdateStoreReceiptContainerGoodCommand : IRequest<Guid>
    {
        public Guid  Id { get; set; }
        public Guid StoreReceiptContainerId { get; set; }
        public Guid CommodityId { get; set; }
        public Guid PackageId { get; set; }
        public string BrandName { get; set; }
        public bool NoBrandName { get; set; }
        public decimal PackNB { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public decimal Volume { get; set; }
        public bool IsHeavy { get; set; } = false;
        public bool IsNonPalletized { get; set; } = false;
        public bool IsDamaged { get; set; } = false;
        public bool IsVoluminous { get; set; } = false;
        public bool IsDangerous { get; set; } = false;
        public bool DangerousNotNoticed { get; set; } = false;

    }
}

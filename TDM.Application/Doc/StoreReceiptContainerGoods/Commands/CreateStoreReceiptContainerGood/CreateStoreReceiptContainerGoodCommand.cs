using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.StoreReceiptContainerGoods.Commands.CreateStoreReceiptContainerGood
{
    public class CreateStoreReceiptContainerGoodCommand:IRequest<Guid>
    {
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

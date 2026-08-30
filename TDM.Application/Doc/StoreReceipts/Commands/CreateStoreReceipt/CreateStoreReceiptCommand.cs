using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.StoreReceipts.Commands.CreateStoreReceipt
{
    public class CreateStoreReceiptCommand : IRequest<Guid>
    {
        public string TerminalCode { get; set; }
        public string IPASStoreReceiptNo { get; set; }
        public DateTime IssueDate { get; set; }
        public Guid ConsigneeId { get; set; }
        public Guid ConsigneeRepId { get; set; }
        public Guid CargoTypeId { get; set; }
        public DateTime? FirstDischargeDate { get; set; }
        public Guid CreatorId { get; set; }
        public Guid TrafficId { get; set; }
        public Guid StoreReceiptStateId { get; set; }
        public Guid? RequestId { get; set; }
        public string VoyageNoticeNo { get; set; }
        public Guid ArrivalTypeId { get; set; }
        public Guid? DeclarationId { get; set; }
        public Guid? BillOfLadingId { get; set; }
        public List<CreateStoreReceiptGoodCommand> StoreReceiptGoods { get;  set; } 
        public List<CreateStoreReceiptContainerCommand> StoreReceiptContainers { get;  set; } 

    }

    public class CreateStoreReceiptContainerCommand
    {
        public Guid StoreReceiptHeadId { get; set; }
        public Guid ContainerId { get; set; }
        public string SealNumber { get; set; }
        public string Remark { get; set; }
        public string DangerousCode { get; set; }
        public string Classification { get; set; }
        public decimal IgnitionTemperature { get; set; }
        public string IgnitionTemperatureUnit { get; set; }
        public List<CreateStoreReceiptContainerGoodCommand> StoreReceiptContainerGoods { get;  set; } 

    }

    public class CreateStoreReceiptContainerGoodCommand
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

    public class CreateStoreReceiptGoodCommand
    {
        public Guid StoreReceiptHeadId { get; set; }
        public Guid CommodityId { get; set; }
        public Guid PackageId { get; set; }
        public string BrandName { get; set; }
        public bool NoBrandName { get; set; }
        public decimal PackNB { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public decimal Volume { get; set; }
        public string Remark { get; set; }
        public bool IsHeavy { get; set; } = false;
        public bool IsNonPalletized { get; set; } = false;
        public bool IsDamaged { get; set; } = false;
        public bool IsVoluminous { get; set; } = false;
        public bool IsDangerous { get; set; } = false;
        public bool DangerousNotNoticed { get; set; } = false;
        public string DangerousCode { get; set; }
        public string Classification { get; set; }
        public decimal IgnitionTemperature { get; set; }
        public string IgnitionTemperatureUnit { get; set; }
    }
}

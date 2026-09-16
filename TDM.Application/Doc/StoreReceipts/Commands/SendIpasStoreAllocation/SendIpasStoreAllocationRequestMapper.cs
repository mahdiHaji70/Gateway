using TDM.Domain.Entities;
using TDM.Domain.Enums;
namespace TDM.Application.Doc.StoreReceipts.Commands.SendIpasStoreAllocation
{
    public static class SendIpasStoreAllocationRequestMapper
    {
        public static SendIpasStoreAllocationRequest Map(StoreReceiptHead receipt)
        {
            var request = new SendIpasStoreAllocationRequest
            {
                StoreReceiptId = receipt.Id,
                TerminalCode = receipt.TerminalCode
            };

            foreach (var good in receipt.StoreReceiptGoods)
            {
                request.Goods.Add(new SendIpasStoreAllocationGoodRequest
                {
                    CargoType = receipt.CargoTypeId == CargoTypes.Bulk
                        ? "Bulk"
                        : "GeneralCargo",
                    OperationDate = receipt.IssueDate,
                    StorageAreaCode = receipt.TerminalCode,
                    HsCode = good.Commodity.HsCode,
                    Description = good.Commodity.Name,
                    BrandName = good.BrandName,
                    PackageTypeCode = good.Package.Code,
                    PackageQuantity = good.PackNB,
                    GrossWeight = good.GrossWeight,
                    NetWeight = good.NetWeight,
                    Volume = good.Volume,
                    IsNonPalletized = good.IsNonPalletized,
                    IsDamaged = good.IsDamaged,
                    IsDangerous = good.IsDangerous,
                    IsVoluminous = good.IsVoluminous,
                    IsHeavy = good.IsHeavy
                });
            }

            foreach (var container in receipt.StoreReceiptContainers)
            {
                request.Containers.Add(new SendIpasStoreAllocationContainerRequest
                {
                    OperationDate = receipt.IssueDate,
                    StorageAreaCode = receipt.TerminalCode,
                    ContainerNo = container.Container.No,
                    Quantity = container.StoreReceiptContainerGoods.Count
                });
            }
            return request;
        }
    }
}

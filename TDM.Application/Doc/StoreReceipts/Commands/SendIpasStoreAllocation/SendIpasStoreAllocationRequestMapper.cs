using TDM.Domain.Entities;
using TDM.Domain.Enums;
using System.Collections.Generic;
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

        public static SendIpasStoreAllocationRequest Map(
            StoreReceiptHead receipt,
            IEnumerable<TerminalDischarge> terminalDischarges)
        {
            var request = new SendIpasStoreAllocationRequest
            {
                StoreReceiptId = receipt.Id,
                TerminalCode = receipt.TerminalCode
            };

            var groupedDischarges = terminalDischarges
                .GroupBy(x => x.Store.Code, StringComparer.OrdinalIgnoreCase);

            foreach (var storeGroup in groupedDischarges)
            {
                var firstDischarge = storeGroup.First();
                var commodity = firstDischarge.DeclarationItem.Commodity;

                request.Goods.Add(new SendIpasStoreAllocationGoodRequest
                {
                    CargoType = receipt.CargoTypeId == CargoTypes.Bulk
                        ? "Bulk"
                        : "GeneralCargo",
                    OperationDate = storeGroup.Max(x => x.DischargeDate),
                    StorageAreaCode = storeGroup.Key,
                    HsCode = commodity.HsCode,
                    Description = commodity.Name,
                    PackageTypeCode = firstDischarge.DeclarationItem.Package.Code,
                    PackageQuantity = storeGroup.Sum(x => x.PackNB),
                    GrossWeight = storeGroup.Sum(x => x.Weight),
                    NetWeight = storeGroup.Sum(x => x.Weight),
                    Volume = storeGroup.Sum(x => x.Volume),
                    IsNonPalletized = storeGroup.Any(x => x.IsNonPalletized),
                    IsDamaged = storeGroup.Any(x => x.IsDamaged),
                    IsDangerous = storeGroup.Any(x => x.IsDangerous),
                    IsVoluminous = storeGroup.Any(x => x.IsVoluminous),
                    IsHeavy = null
                });
            }

            return request;
        }
    }
}

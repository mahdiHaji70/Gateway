using TDM.Application.Doc.StoreReceipts.Commands.SendIpasStoreAllocation;
using TDM.Infrastructure.Integrations.Requests;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public class SendStoreAllocationToIpasMapper
    {
        public static SendStoreAllocationToIpasDto Map(SendIpasStoreAllocationRequest request)
        {
            return new SendStoreAllocationToIpasDto
            {
                WarehouseReceiptId = request.StoreReceiptId,
                TerminalCode = request.TerminalCode,
                GeneralCargoList = request.Goods
                    .Where(x => !string.Equals(x.CargoType, "Bulk", StringComparison.OrdinalIgnoreCase))
                    .Select(good => new StoreAllocationGeneralCargoDto
                    {
                        OperationDate = good.OperationDate,
                        StorageAreaCode = good.StorageAreaCode,
                        GeneralCargo = new StoreAllocationGeneralCargoGoodDto
                        {
                            HsCode = good.HsCode,
                            Description = good.Description,
                            BrandName = good.BrandName,
                            PackageTypeCode = good.PackageTypeCode,
                            PackageQuantity = good.PackageQuantity,
                            GrossWeight = good.GrossWeight,
                            NetWeight = good.NetWeight,
                            IsNonPalletized = good.IsNonPalletized,
                            IsDamaged = good.IsDamaged,
                            IsDangerous = good.IsDangerous,
                            Width = 0m,
                            Height = 0m,
                            Length = 0m,
                            IsVoluminous = good.IsVoluminous,
                            IsHeavy = good.IsHeavy
                        }
                    }).ToList(),
                BulkList = request.Goods
                    .Where(x => string.Equals(x.CargoType, "Bulk", StringComparison.OrdinalIgnoreCase))
                    .Select(good => new StoreAllocationBulkDto
                    {
                        OperationDate = good.OperationDate,
                        StorageAreaCode = good.StorageAreaCode,
                        Bulk = new StoreAllocationBulkGoodDto
                        {
                            HsCode = good.HsCode,
                            Description = good.Description,
                            Weight = good.NetWeight,
                            Volume = good.Volume,
                            IsDangerous = good.IsDangerous
                        }
                    }).ToList(),
                ContainerList = request.Containers.Select(x => new StoreAllocationContainerDto
                {
                    OperationDate = x.OperationDate,
                    StorageAreaCode = x.StorageAreaCode,
                    ContainerNo = x.ContainerNo,
                    Quantity = x.Quantity
                }).ToList()
            };
        }
    }
}

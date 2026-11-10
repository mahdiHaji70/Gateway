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
                        FirstPortDischargeDate = good.FirstDischargeDate,
                        FirstTerminalDischargeDate = good.FirstDischargeDate,
                        StorageAreaCode = good.StorageAreaCode,
                        GeneralCargo = new StoreAllocationGeneralCargoGoodDto
                        {
                            HsCode = good.HsCode,
                            Description = good.Description,
                            BrandName = good.BrandName,
                            NoBrandName = string.IsNullOrEmpty(good.BrandName) ? true : false,
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
                            IsHeavy = good.IsHeavy,
                            DangerousNotNoticed = false,
                            DangerousSpecification =
                            new StoreAllocationDangerousSpecificationDto
                            {
                                DangerousCode = good.DangerousCode,
                                Classification = good.Classification,
                                IgnitionTemperature = good.IgnitionTemperature,
                                IgnitionTemperatureUnit = good.IgnitionTemperatureUnit
                            },
                            Remark = string.Empty
                        }
                    }).ToList(),
                BulkList = request.Goods
                    .Where(x => string.Equals(x.CargoType, "Bulk", StringComparison.OrdinalIgnoreCase))
                    .Select(good => new StoreAllocationBulkDto
                    {
                        OperationDate = good.OperationDate,
                        FirstPortDischargeDate = good.FirstDischargeDate,
                        FirstTerminalDischargeDate = good.FirstDischargeDate,
                        StorageAreaCode = good.StorageAreaCode,
                        Bulk = new StoreAllocationBulkGoodDto
                        {
                            HsCode = good.HsCode,
                            Description = good.Description,
                            Weight = good.NetWeight,
                            Volume = good.Volume,
                            IsDangerous = good.IsDangerous,
                            DangerousNotNoticed = false,
                            DangerousSpecification =
                            new StoreAllocationDangerousSpecificationDto
                            {
                                DangerousCode = good.DangerousCode,
                                Classification = good.Classification,
                                IgnitionTemperature = good.IgnitionTemperature,
                                IgnitionTemperatureUnit = good.IgnitionTemperatureUnit
                            },
                            Remark = string.Empty
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

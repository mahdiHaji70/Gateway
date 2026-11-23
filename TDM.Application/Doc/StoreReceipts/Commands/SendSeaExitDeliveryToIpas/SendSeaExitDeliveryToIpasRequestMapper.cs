using TDM.Domain.Entities;
using TDM.Domain.Enums;

namespace TDM.Application.Doc.StoreReceipts.Commands.SendSeaExitDeliveryToIpas
{
    public static class SendSeaExitDeliveryToIpasRequestMapper
    {
        public static SendSeaExitDeliveryToIpasRequest Map(StoreExitDocument document)
        {
            var operations = document.StoreReceiptOperations.ToList();
            var firstOperation = operations[0];
            var receipt = firstOperation.StoreReceiptHead;

            var request = new SendSeaExitDeliveryToIpasRequest
            {
                StoreExitDocumentId = document.Id,
                LoadingPermitId = document.LoadingPermitId.Value,
                TerminalCode = receipt.TerminalCode,
                Date = document.IssueDate,
                VehicleTypeId = (int)VehicleTypeCode.Truck,
                VehicleNo = document.VehicleNumber,
                LoadingStart = document.IssueDate,
                LoadingFinish = document.IssueDate,
            };

            foreach (var operation in operations)
            {
                if (receipt.CargoTypeId == CargoTypes.Container)
                {
                    var container = operation.StoreReceiptContainer!;

                    if (!request.ContainerList.Contains(container.Container.No, StringComparer.OrdinalIgnoreCase))
                        request.ContainerList.Add(container.Container.No);
                    continue;
                }


                var good = operation.StoreReceiptGood!;

                var dangerousSpecification = new SeaExitDeliveryDangerousSpecification
                {
                    DangerousCode = good.DangerousCode,
                    Classification = good.Classification,
                    IgnitionTemperature = good.IsDangerous ? good.IgnitionTemperature : null,
                    IgnitionTemperatureUnit = good.IgnitionTemperatureUnit
                };

                if (receipt.CargoTypeId == CargoTypes.Bulk)
                {
                    request.BulkList.Add(new SeaExitDeliveryBulk
                    {
                        HsCode = good.Commodity.HsCode,
                        Description = good.Commodity.Name,
                        Weight = operation.Weight,
                        Volume = operation.Volume,
                        IsDangerous = good.IsDangerous,
                        DangerousNotNoticed = good.DangerousNotNoticed,
                        Remark = good.Remark,
                        DangerousSpecification = dangerousSpecification
                    });
                }
                else
                {

                    request.GeneralCargoList.Add(new SeaExitDeliveryGeneralCargo
                    {
                        HsCode = good.Commodity.HsCode,
                        Description = good.Commodity.Name,
                        BrandName = good.BrandName,
                        PackageTypeCode = good.Package.Code,
                        PackageType = good.Package.Name,
                        PackageQuantity = operation.PackNb,
                        GrossWeight = operation.UnitWeight,
                        NetWeight = operation.UnitWeight,
                        IsNonPalletized = good.IsNonPalletized,
                        IsDamaged = good.IsDamaged,
                        IsDangerous = good.IsDangerous,
                        IsVoluminous = good.IsVoluminous,
                        IsHeavy = good.IsHeavy,
                        NoBrandName = good.NoBrandName,
                        DangerousNotNoticed = good.DangerousNotNoticed,
                        Remark = good.Remark,
                        DangerousSpecification = dangerousSpecification
                    });
                }
            }

            return request;
        }
    }
}

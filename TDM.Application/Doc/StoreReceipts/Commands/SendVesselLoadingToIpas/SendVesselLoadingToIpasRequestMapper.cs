using TDM.Domain.Entities;
using TDM.Domain.Enums;

namespace TDM.Application.Doc.StoreReceipts.Commands.SendVesselLoadingToIpas
{
    public static class SendVesselLoadingToIpasRequestMapper
    {
        public static SendVesselLoadingToIpasRequest Map(StoreExitDocument document)
        {
            var operations = document.StoreReceiptOperations.ToList();
            var receipt = operations[0].StoreReceiptHead;
            var request = new SendVesselLoadingToIpasRequest
            {
                StoreExitDocumentId = document.Id,
                TerminalCode = receipt.TerminalCode,
                Date = document.IssueDate,
                VoyageId = document.Voyage!.IpasVoyageId!.Value,
                StartTime = document.IssueDate,
                FinishTime = document.IssueDate,
                CarrierIdNumber = document.VehicleNumber,
                CarrierType = (int)VehicleTypeCode.Truck,
                TallyMan = string.Empty
            };

            foreach (var operation in operations)
            {
                if (receipt.CargoTypeId == CargoTypes.Container)
                {
                    var container = operation.StoreReceiptContainer!;
                    if (!request.ContainerList.Any(x => string.Equals(x.ContainerNo, container.Container.No, StringComparison.OrdinalIgnoreCase)))
                        request.ContainerList.Add(new VesselLoadingContainer
                        {
                            ContainerNo = container.Container.No,
                            Remark = container.Remark,
                            DischargeSpecification = new VesselLoadingDischargeSpecification()
                        });
                    continue;
                }

                var good = operation.StoreReceiptGood!;
                if (receipt.CargoTypeId == CargoTypes.Bulk)
                    request.BulkList.Add(new VesselLoadingBulk
                    {
                        HsCode = good.Commodity.HsCode,
                        Description = good.Commodity.Name,
                        Weight = operation.Weight,
                        Volume = operation.Volume,
                        IsDangerous = good.IsDangerous,
                        Remark = good.Remark
                    });
                else
                    request.GeneralCargoList.Add(new VesselLoadingGeneralCargo
                    {
                        HsCode = good.Commodity.HsCode,
                        Description = good.Commodity.Name,
                        BrandName = good.BrandName,
                        PackageTypeCode = good.Package.Code,
                        PackageQuantity = operation.PackNb,
                        GrossWeight = operation.UnitWeight,
                        NetWeight = operation.UnitWeight,
                        IsNonPalletized = good.IsNonPalletized,
                        IsDamaged = good.IsDamaged,
                        IsDangerous = good.IsDangerous,
                        IsVoluminous = good.IsVoluminous,
                        Remark = good.Remark
                    });
            }
            return request;
        }
    }
}

using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.StoreReceipts.DTOs;
using TDM.Application.Doc.StoreReceipts.Queries.GetStoreReceiptByStorageAgreementNo;
using TDM.Infrastructure.Integrations.Helpers;
using TDM.Infrastructure.Integrations.Mapper;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Client
{
    public class StoreReceiptExternalService : IStoreReceiptExternalService
    {
        private readonly IRequestExecutor _requestExecutor;
        public StoreReceiptExternalService(IRequestExecutor requestExecutor)
        {
            _requestExecutor = requestExecutor;
        }
        public async Task<List<StoreReceiptHeadDto>> GetStoreReceipts(string ipasDeclarationNo, CancellationToken cancellationToken)
        {
            var response = await _requestExecutor.GetAsync<List<IpasStoreReceiptResponseDto>>("TDM", "GetStoreReceiptByStorageAgreementNo",
            new
            {
                storageAgreementNo = ipasDeclarationNo
            });

            ExternalResponseHelper.EnsureSuccess(response, "GetStoreReceiptByStorageAgreementNo");
            var IpasStoreReceipts = StoreReceiptMapper.Map(response.Data!);
            return IpasStoreReceipts;
        }

        public async Task<TDM.Application.Doc.StoreReceipts.Commands.SendIpasStoreAllocation.SendIpasStoreAllocationResponse> SendIpasStoreAllocation(
            TDM.Application.Doc.StoreReceipts.Commands.SendIpasStoreAllocation.SendIpasStoreAllocationRequest request,
            CancellationToken cancellationToken = default)
        {
            var dto = new
            {
                WarehouseReceiptId = request.StoreReceiptId,
                TerminalCode = request.TerminalCode,
                GeneralCargoList = request.Goods
                    .Where(x => !string.Equals(x.CargoType, "Bulk", StringComparison.OrdinalIgnoreCase))
                    .Select(good => new
                    {
                        good.OperationDate,
                        good.StorageAreaCode,
                        GeneralCargo = new
                        {
                            good.HsCode,
                            Description = good.Description,
                            good.BrandName,
                            good.PackageTypeCode,
                            PackageQuantity = good.PackageQuantity,
                            good.GrossWeight,
                            good.NetWeight,
                            good.IsNonPalletized,
                            good.IsDamaged,
                            good.IsDangerous,
                            Width = 0m,
                            Height = 0m,
                            Length = 0m,
                            good.IsVoluminous,
                            good.IsHeavy
                        }
                    }).ToList(),
                BulkList = request.Goods
                    .Where(x => string.Equals(x.CargoType, "Bulk", StringComparison.OrdinalIgnoreCase))
                    .Select(good => new
                    {
                        good.OperationDate,
                        good.StorageAreaCode,
                        Bulk = new
                        {
                            good.HsCode,
                            Description = good.Description,
                            Weight = good.NetWeight,
                            good.Volume,
                            good.IsDangerous
                        }
                    }).ToList(),
                ContainerList = request.Containers.Select(x => new
                {
                    x.OperationDate,
                    x.StorageAreaCode,
                    x.ContainerNo,
                    x.Quantity
                }).ToList()
            };

            var response = await _requestExecutor.PostAsync<bool>("PMO", "SendWarehouseReceiptAllocation", dto, cancellationToken);
            if (!ExternalResponseHelper.TryEnsureSuccess(response, "Send IPAS Store Allocation", out var errorMessage))
                return new()
                {
                    StoreReceiptId = request.StoreReceiptId,
                    ErrorMessage = errorMessage,
                    IsSent = false
                };

            return new()
            {
                StoreReceiptId = request.StoreReceiptId,
                IsSent = response.Data
            };
        }

       
    }
}

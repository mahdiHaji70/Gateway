using MediatR;
using TDM.Application.Common.Interfaces;

namespace TDM.Application.Doc.StoreReceipts.Queries.GetStoreReceiptWarehouses
{
    public class GetStoreReceiptWarehousesQueryHandler
        : IRequestHandler<GetStoreReceiptWarehousesQuery, IReadOnlyList<StoreReceiptWarehouseDto>>
    {
        private readonly IStoreReceiptHeadRepository _storeReceiptRepository;
        private readonly ITerminalDischargeRepository _terminalDischargeRepository;

        public GetStoreReceiptWarehousesQueryHandler(
            IStoreReceiptHeadRepository storeReceiptRepository,
            ITerminalDischargeRepository terminalDischargeRepository)
        {
            _storeReceiptRepository = storeReceiptRepository;
            _terminalDischargeRepository = terminalDischargeRepository;
        }

        public async Task<IReadOnlyList<StoreReceiptWarehouseDto>> Handle(
            GetStoreReceiptWarehousesQuery request,
            CancellationToken cancellationToken)
        {
            var receipt = await _storeReceiptRepository.GetAsync(request.StoreReceiptId)
                ?? throw new KeyNotFoundException("Store receipt was not found.");

            if (!receipt.RequestId.HasValue)
            {
                return new List<StoreReceiptWarehouseDto>
                {
                    new()
                    {
                        StorageAreaCode = receipt.TerminalCode,
                        OperationDate = receipt.IssueDate
                    }
                };
            }

            var discharges = await _terminalDischargeRepository
                .GetByIssueRequestIdAsync(receipt.RequestId.Value);

            return discharges
                .GroupBy(x => new
                {
                    StorageAreaCode = x.Store.Code,
                    StorageAreaName = x.Store.Name,
                    CommodityId = x.DeclarationItem.CommodityId,
                    PackageId = x.DeclarationItem.PackageId
                })
                .Select(group => new StoreReceiptWarehouseDto
                {
                    StorageAreaCode = group.Key.StorageAreaCode,
                    StorageAreaName = group.Key.StorageAreaName,
                    CommodityName = group.First().DeclarationItem.Commodity.Name,
                    HsCode = group.First().DeclarationItem.Commodity.HsCode,
                    PackageName = group.First().DeclarationItem.Package.Name,
                    PackageTypeCode = group.First().DeclarationItem.Package.Code,
                    OperationDate = group.Max(x => x.DischargeDate),
                    Quantity = group.Sum(x => x.PackNB),
                    Weight = group.Sum(x => x.Weight),
                    Volume = group.Sum(x => x.Volume)
                })
                .ToList();
        }
    }
}

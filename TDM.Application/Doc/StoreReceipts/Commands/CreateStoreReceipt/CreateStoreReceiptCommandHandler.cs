using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.StoreReceipt.Command.CreateStoreReceipt;
using TDM.Domain.Entities;
using System.Linq;

namespace TDM.Application.Doc.StoreReceipts.Commands.CreateStoreReceipt
{

    public class CreateStoreReceiptCommandHandler : IRequestHandler<CreateStoreReceiptCommand, Guid>
    {
        private readonly IRepository<StoreReceiptHead> _storeReceiptHeadRepository;
        private readonly IRepository<StoreReceiptGood> _storeReceiptGoodRepository;
        private readonly IRepository<StoreReceiptContainer> _storeReceiptContainerRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ITrafficRepository _trafficRepository;
        private readonly ICommodityRepository _commodityRepository;
        private readonly IPackageRepository _packageRepository;
        private readonly IContainerRepository _containerRepository;
        private readonly IRepository<StoreReceiptState> _storeReceiptStateRepository;
        private readonly IRepository<ArrivalType> _arrivalTypeRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CreateStoreReceiptCommandHandler(IUnitOfWork unitOfWork
            , IRepository<StoreReceiptHead> storeReceiptHeadRepository
            , IRepository<StoreReceiptGood> storeReceiptGoodRepository
            , IRepository<StoreReceiptContainer> storeReceiptContainerRepository
            , ICompanyRepository companyRepository
            , ITrafficRepository trafficRepository
            , ICommodityRepository commodityRepository
            , IPackageRepository packageRepository
            , IContainerRepository containerRepository
            , IRepository<StoreReceiptState> storeReceiptStateRepository
            , IRepository<ArrivalType> arrivalTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _storeReceiptHeadRepository = storeReceiptHeadRepository;
            _storeReceiptGoodRepository = storeReceiptGoodRepository;
            _storeReceiptContainerRepository = storeReceiptContainerRepository;
            _companyRepository = companyRepository;
            _trafficRepository = trafficRepository;
            _commodityRepository = commodityRepository;
            _packageRepository = packageRepository;
            _containerRepository = containerRepository;
            _storeReceiptStateRepository = storeReceiptStateRepository;
            _arrivalTypeRepository = arrivalTypeRepository;
        }

        public async Task<Guid> Handle(CreateStoreReceiptCommand request, CancellationToken cancellationToken)
        {
            var consigneeId = await ResolveCompanyIdAsync(request.ConsigneeId, request.ConsigneeNationalId, "consignee", cancellationToken);
            var consigneeRepId = await ResolveCompanyIdAsync(request.ConsigneeRepId, request.ConsigneeRepNationalId, "consignee representative", cancellationToken);
            var trafficId = await ResolveTrafficIdAsync(request.TrafficId, request.TrafficCode, cancellationToken);
            var stateId = await ResolveStateIdAsync(request.StoreReceiptStateId, request.StoreReceiptStateName, cancellationToken);
            var arrivalTypeId = await ResolveArrivalTypeIdAsync(request.ArrivalTypeId, request.ArrivalTypeName, cancellationToken);

            var goods = request.StoreReceiptGoods ?? new List<CreateStoreReceiptGoodCommand>();
            var containers = request.StoreReceiptContainers ?? new List<CreateStoreReceiptContainerCommand>();
            var containerGoods = containers.SelectMany(x => x.StoreReceiptContainerGoods ?? new List<CreateStoreReceiptContainerGoodCommand>()).ToList();

            var commodityCodes = goods.Where(x => x.CommodityId == Guid.Empty && !string.IsNullOrWhiteSpace(x.HsCode)).Select(x => x.HsCode)
                .Concat(containerGoods.Where(x => x.CommodityId == Guid.Empty && !string.IsNullOrWhiteSpace(x.HsCode)).Select(x => x.HsCode))
                .Distinct(StringComparer.OrdinalIgnoreCase).ToList();
            var commodities = await _commodityRepository.GetByHsCodesAsync(commodityCodes, cancellationToken);
            var commodityByCode = commodities.GroupBy(x => x.HsCode, StringComparer.OrdinalIgnoreCase)
                .ToDictionary(x => x.Key, x => x.First(), StringComparer.OrdinalIgnoreCase);

            var packageCodes = goods.Where(x => x.PackageId == Guid.Empty && !string.IsNullOrWhiteSpace(x.PackageTypeCode)).Select(x => x.PackageTypeCode)
                .Concat(containerGoods.Where(x => x.PackageId == Guid.Empty && !string.IsNullOrWhiteSpace(x.PackageTypeCode)).Select(x => x.PackageTypeCode))
                .Distinct(StringComparer.OrdinalIgnoreCase).ToList();
            var packages = await _packageRepository.GetByCodesAsync(packageCodes, cancellationToken);
            var packageByCode = packages.GroupBy(x => x.Code, StringComparer.OrdinalIgnoreCase)
                .ToDictionary(x => x.Key, x => x.First(), StringComparer.OrdinalIgnoreCase);

            var containerKeys = containers.Where(x => x.ContainerId == Guid.Empty)
                .Select(x => (x.ContainerNo, x.ContainerTypeAndSizeCode)).ToList();
            var foundContainers = await _containerRepository.GetByNoAndCodesAsync(containerKeys, cancellationToken);
            var containerByKey = foundContainers.ToDictionary(x => $"{x.No}|{x.ContainerTypeAndSize.TypeAndSizeCode}", StringComparer.OrdinalIgnoreCase);

            var receipt = new StoreReceiptHead(
                request.TerminalCode,
                request.IPASStoreReceiptNo,
                request.IssueDate,
                consigneeId,
                consigneeRepId,
                request.CargoTypeId,
                request.FirstDischargeDate,
                request.CreatorId,
                trafficId,
                stateId,
                request.RequestId,
                request.VoyageNoticeNo,
                arrivalTypeId,
                request.DeclarationId,
                request.BillOfLadingId);

            foreach (var goodRequest in goods)
            {
                var commodityId = ResolveCommodityId(goodRequest.CommodityId, goodRequest.HsCode, commodityByCode);
                var packageId = ResolvePackageId(goodRequest.PackageId, goodRequest.PackageTypeCode, packageByCode);
                receipt.AddGood(
                    commodityId,
                    packageId,
                    goodRequest.BrandName,
                    goodRequest.NoBrandName,
                    goodRequest.PackNB,
                    goodRequest.GrossWeight,
                    goodRequest.NetWeight,
                    goodRequest.Volume,
                    goodRequest.Remark,
                    goodRequest.IsHeavy,
                    goodRequest.IsNonPalletized,
                    goodRequest.IsDamaged,
                    goodRequest.IsVoluminous,
                    goodRequest.IsDangerous,
                    goodRequest.DangerousNotNoticed,
                    goodRequest.DangerousCode,
                    goodRequest.Classification,
                    goodRequest.IgnitionTemperature,
                    goodRequest.IgnitionTemperatureUnit);
            }

            foreach (var containerRequest in containers)
            {
                var containerId = ResolveContainerId(containerRequest, containerByKey);
                var container = receipt.AddContainer(
                    containerId,
                    containerRequest.SealNumber,
                    containerRequest.Remark,
                    containerRequest.DangerousCode,
                    containerRequest.Classification,
                    containerRequest.IgnitionTemperature,
                    containerRequest.IgnitionTemperatureUnit);

                foreach (var goodRequest in containerRequest.StoreReceiptContainerGoods ?? new List<CreateStoreReceiptContainerGoodCommand>())
                {
                    var commodityId = ResolveCommodityId(goodRequest.CommodityId, goodRequest.HsCode, commodityByCode);
                    var packageId = ResolvePackageId(goodRequest.PackageId, goodRequest.PackageTypeCode, packageByCode);
                    container.AddGood(
                        commodityId,
                        packageId,
                        goodRequest.BrandName,
                        goodRequest.NoBrandName,
                        goodRequest.PackNB,
                        goodRequest.GrossWeight,
                        goodRequest.NetWeight,
                        goodRequest.Volume,
                        goodRequest.IsHeavy,
                        goodRequest.IsNonPalletized,
                        goodRequest.IsDamaged,
                        goodRequest.IsVoluminous,
                        goodRequest.IsDangerous,
                        goodRequest.DangerousNotNoticed);
                }
            }

            await _storeReceiptHeadRepository.InsertAsync(receipt);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return receipt.Id;
        }

        private async Task<Guid> ResolveCompanyIdAsync(Guid id, string nationalId, string field, CancellationToken cancellationToken)
        {
            if (id != Guid.Empty)
                return id;
            if (string.IsNullOrWhiteSpace(nationalId))
                throw new InvalidOperationException($"{field} id or national id is required.");

            var companies = await _companyRepository.GetByNationalIdsAsync(new[] { nationalId }, cancellationToken);
            return companies.FirstOrDefault()?.Id ?? throw new InvalidOperationException($"{field} was not found for national id '{nationalId}'.");
        }

        private async Task<Guid> ResolveTrafficIdAsync(Guid id, string code, CancellationToken cancellationToken)
        {
            if (id != Guid.Empty)
                return id;
            if (string.IsNullOrWhiteSpace(code))
                throw new InvalidOperationException("Traffic id or traffic code is required.");

            var traffic = (await _trafficRepository.GetByCodesAsync(new[] { code }, cancellationToken)).FirstOrDefault();
            return traffic?.Id ?? throw new InvalidOperationException($"Traffic was not found for code '{code}'.");
        }

        private async Task<Guid> ResolveStateIdAsync(Guid id, string name, CancellationToken cancellationToken)
        {
            if (id != Guid.Empty)
                return id;
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("Store receipt state id or state name is required.");

            var states = await _storeReceiptStateRepository.GetAllAsync();
            var state = states?.FirstOrDefault(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));
            return state?.Id ?? throw new InvalidOperationException($"Store receipt state was not found for name '{name}'.");
        }

        private async Task<Guid> ResolveArrivalTypeIdAsync(Guid id, string name, CancellationToken cancellationToken)
        {
            if (id != Guid.Empty)
                return id;
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("Arrival type id or arrival type name is required.");

            var arrivalTypes = await _arrivalTypeRepository.GetAllAsync();
            var arrivalType = arrivalTypes?.FirstOrDefault(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));
            return arrivalType?.Id ?? throw new InvalidOperationException($"Arrival type was not found for name '{name}'.");
        }

        private static Guid ResolveCommodityId(Guid id, string hsCode, IReadOnlyDictionary<string, Commodity> commodities)
        {
            if (id != Guid.Empty)
                return id;
            if (!string.IsNullOrWhiteSpace(hsCode) && commodities.TryGetValue(hsCode, out var commodity))
                return commodity.Id;
            throw new InvalidOperationException($"Commodity was not found for HS code '{hsCode}'.");
        }

        private static Guid ResolvePackageId(Guid id, string code, IReadOnlyDictionary<string, Package> packages)
        {
            if (id != Guid.Empty)
                return id;
            if (!string.IsNullOrWhiteSpace(code) && packages.TryGetValue(code, out var package))
                return package.Id;
            throw new InvalidOperationException($"Package was not found for code '{code}'.");
        }

        private static Guid ResolveContainerId(CreateStoreReceiptContainerCommand request, IReadOnlyDictionary<string, Container> containers)
        {
            if (request.ContainerId != Guid.Empty)
                return request.ContainerId;
            var key = $"{request.ContainerNo}|{request.ContainerTypeAndSizeCode}";
            if (containers.TryGetValue(key, out var container))
                return container.Id;
            throw new InvalidOperationException($"Container was not found for no '{request.ContainerNo}' and type code '{request.ContainerTypeAndSizeCode}'.");
        }
    }

}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;
using TDM.Domain.Exceptions; // Assuming your custom exception namespace

namespace TDM.Application.Doc.Manifests.Commands.CreateManifest
{
    public class CreateManifestCommandHandler
        : IRequestHandler<CreateManifestCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IManifestRepository _manifestRepository;
        private readonly ICommodityRepository _commodityRepository;
        private readonly IPackageRepository _packageRepository;
        private readonly IContainerRepository _containerRepository;
        private readonly ITrafficRepository _trafficRepository;
        private readonly ICompanyRepository _companyRepository;

        public CreateManifestCommandHandler(
            IUnitOfWork unitOfWork,
            IManifestRepository manifestRepository,
            ICommodityRepository commodityRepository,
            IPackageRepository packageRepository,
            IContainerRepository containerRepository,
            ITrafficRepository trafficRepository,
            ICompanyRepository companyRepository)
        {
            _unitOfWork = unitOfWork;
            _manifestRepository = manifestRepository;
            _commodityRepository = commodityRepository;
            _packageRepository = packageRepository;
            _containerRepository = containerRepository;
            _trafficRepository = trafficRepository;
            _companyRepository = companyRepository;
        }

        public async Task<Guid> Handle(
            CreateManifestCommand request,
            CancellationToken cancellationToken)
        {
            if (await _manifestRepository.ExistsByNoticeNo(request.NoticeNo))
                throw new Exception($"Notice no '{request.NoticeNo}' already exists.");

            var manifestItems = request.ManifestItems ?? new List<CreateManifestItemCommand>();

            var hsCodes = manifestItems
                .SelectMany(x => x.ManifestGoods ?? Enumerable.Empty<CreateManifestGoodCommand>())
                .Select(x => x.HSCode)
                .Concat(manifestItems
                    .SelectMany(x => x.ManifestContainers ?? Enumerable.Empty<CreateManifestContainerCommand>())
                    .SelectMany(x => x.ManifestContainerGoods ?? Enumerable.Empty<CreateManifestContainerGoodCommand>())
                    .Select(x => x.HSCode))
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            var packageCodes = manifestItems
                .SelectMany(x => x.ManifestGoods ?? Enumerable.Empty<CreateManifestGoodCommand>())
                .Select(x => x.PackageCode)
                .Concat(manifestItems
                    .SelectMany(x => x.ManifestContainers ?? Enumerable.Empty<CreateManifestContainerCommand>())
                    .SelectMany(x => x.ManifestContainerGoods ?? Enumerable.Empty<CreateManifestContainerGoodCommand>())
                    .Select(x => x.PackageCode))
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Append("VL")
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            var containerKeys = manifestItems
                .SelectMany(x => x.ManifestContainers ?? Enumerable.Empty<CreateManifestContainerCommand>())
                .Where(x => !string.IsNullOrWhiteSpace(x.ContainerNo) && !string.IsNullOrWhiteSpace(x.TypeCode))
                .Select(x => (x.ContainerNo, x.TypeCode))
                .Distinct()
                .ToList();

            var trafficCodes = manifestItems
                .Select(x => x.TrafficCode)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            var nationalIds = manifestItems
                .Select(x => x.ConsigneeNationalId)
                .Concat(manifestItems.Select(x => x.ShipAgentNationalId))
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            var commodities = await _commodityRepository.GetByHsCodesAsync(hsCodes, cancellationToken);
            var packages = await _packageRepository.GetByCodesAsync(packageCodes, cancellationToken);
            var containers = await _containerRepository.GetByNoAndCodesAsync(containerKeys, cancellationToken);
            var traffics = await _trafficRepository.GetByCodesAsync(trafficCodes, cancellationToken);
            var companies = await _companyRepository.GetByNationalIdsAsync(nationalIds, cancellationToken);

            var commodityDict = commodities.ToDictionary(x => x.HsCode, x => x.Id, StringComparer.OrdinalIgnoreCase);
            var packageDict = packages.ToDictionary(x => x.Code, x => x.Id, StringComparer.OrdinalIgnoreCase);
            var trafficDict = traffics.ToDictionary(x => x.Code, x => x.Id, StringComparer.OrdinalIgnoreCase);
            var companyDict = companies.ToDictionary(x => x.NationalId, x => x.Id, StringComparer.OrdinalIgnoreCase);

            var containerDict = containers.ToDictionary(
                x => (x.No, x.ContainerTypeAndSize.TypeAndSizeCode),
                x => x.Id);

            var manifest = new Manifest(
                request.SerialNo,
                request.ManifestRegistrationNumber,
                request.VoyageNo,
                request.NoticeNo,
                request.ETA,
                request.ETD,
                request.ShipLine,
                request.ShipAgent,
                request.VesselName,
                request.Imo,
                request.TerminalCode);

            foreach (var itemCommand in manifestItems)
            {
                if (!trafficDict.TryGetValue(itemCommand.TrafficCode ?? "", out var trafficId))
                    throw new NotFoundException($"Traffic code '{itemCommand.TrafficCode}' not found.");

                if (!companyDict.TryGetValue(itemCommand.ConsigneeNationalId ?? "", out var consigneeId))
                    throw new NotFoundException($"Consignee ID '{itemCommand.ConsigneeNationalId}' not found.");

                if (!companyDict.TryGetValue(itemCommand.ShipAgentNationalId ?? "", out var shipAgentId))
                    throw new NotFoundException($"Ship Agent ID '{itemCommand.ShipAgentNationalId}' not found.");

                var menifestItem = new ManifestItem(
                    itemCommand.ManifestItemNo,
                    itemCommand.ManifestNo,
                    itemCommand.Consignor,
                    itemCommand.ShipLine,
                    trafficId,
                    consigneeId,
                    shipAgentId);

                foreach (var goodCommand in itemCommand.ManifestGoods ?? Enumerable.Empty<CreateManifestGoodCommand>())
                {
                    if (!commodityDict.TryGetValue(goodCommand.HSCode ?? "", out var commodityId))
                        throw new NotFoundException($"HS Code '{goodCommand.HSCode}' not found.");

                    string pkgCode = string.IsNullOrWhiteSpace(goodCommand.PackageCode) ? "VL" : goodCommand.PackageCode;
                    if (!packageDict.TryGetValue(pkgCode, out var packageId))
                        throw new NotFoundException($"Package code '{pkgCode}' not found.");

                    menifestItem.AddManifestGood(new ManifestGood(
                        goodCommand.PackNb,
                        goodCommand.GrossWeight,
                        goodCommand.NetWeight,
                        goodCommand.Volume,
                        goodCommand.BrandName,
                        goodCommand.Description,
                        commodityId,
                        packageId));
                }

                foreach (var containerCommand in itemCommand.ManifestContainers ?? Enumerable.Empty<CreateManifestContainerCommand>())
                {
                    var containerKey = (containerCommand.ContainerNo, containerCommand.TypeCode);
                    if (!containerDict.TryGetValue(containerKey, out var containerId))
                        throw new NotFoundException($"Container '{containerCommand.ContainerNo}' with type '{containerCommand.TypeCode}' not found.");

                    var manifestContainer = new ManifestContainer(
                        containerId,
                        containerCommand.BillOfLadingId,
                        containerCommand.SealNumber,
                        containerCommand.DangerousCode,
                        containerCommand.Classification,
                        containerCommand.IgnitionTemperature,
                        containerCommand.IgnitionTemperatureUnit);

                    foreach (var cgCommand in containerCommand.ManifestContainerGoods ?? Enumerable.Empty<CreateManifestContainerGoodCommand>())
                    {
                        if (!commodityDict.TryGetValue(cgCommand.HSCode ?? "", out var commodityId))
                            throw new NotFoundException($"HS Code '{cgCommand.HSCode}' not found.");

                        string pkgCode = string.IsNullOrWhiteSpace(cgCommand.PackageCode) ? "VL" : cgCommand.PackageCode;
                        if (!packageDict.TryGetValue(pkgCode, out var packageId))
                            throw new NotFoundException($"Package code '{pkgCode}' not found.");

                        manifestContainer.AddManifestContainerGood(new ManifestContainerGood(
                            cgCommand.PackNb,
                            cgCommand.GrossWeight,
                            cgCommand.NetWeight,
                            packageId,
                            commodityId));
                    }

                    menifestItem.AddManifestContainer(manifestContainer);
                }

                manifest.AddManifestItem(menifestItem);
            }

            await _manifestRepository.InsertAsync(manifest);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return manifest.Id;
        }
    }
}

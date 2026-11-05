using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Packages.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Packages.Queries.GetPackages
{
    public class GetPackagesQueryHandler : IRequestHandler<GetPackagesQuery, PagedResult<PackageDto>>
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IMapper _mapper;

        public GetPackagesQueryHandler(IMapper mapper,
            IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<PackageDto>> Handle(
        GetPackagesQuery request,
        CancellationToken cancellationToken)
        {
            var packages = await _packageRepository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search);

            return _mapper.Map<PagedResult<PackageDto>>(packages);
        }
    }
}

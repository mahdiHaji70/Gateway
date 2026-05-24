using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Packages.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Packages.Queries.GetPackages
{
    public class GetPackagesQueryHandler : IRequestHandler<GetPackagesQuery, PagedResult<PackageDto>>
    {
        private readonly IRepository<Package> _packageRepository;
        private readonly IMapper _mapper;

        public GetPackagesQueryHandler(IMapper mapper,
            IRepository<Package> packageRepository)
        {
            _packageRepository = packageRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<PackageDto>> Handle(
        GetPackagesQuery request,
        CancellationToken cancellationToken)
        {
            var packages = await _packageRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<PackageDto>>(packages);
        }
    }
}

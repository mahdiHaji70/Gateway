using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Packages.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Packages.Queries.GetPackageLookup
{
    public class GetPackageLookupQueryHandler : IRequestHandler<GetPackageLookupQuery, PagedResult<PackageDto>>
    {
        private readonly IPackageRepository _repository;
        private readonly IMapper _mapper;

        public GetPackageLookupQueryHandler(IPackageRepository repository, IMapper mapper)
        { _repository = repository; _mapper = mapper; }

        public async Task<PagedResult<PackageDto>> Handle(GetPackageLookupQuery request, CancellationToken cancellationToken)
            => _mapper.Map<PagedResult<PackageDto>>(await _repository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search));
    }
}

using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Packages.DTOs;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Packages.Queries.GetPackageById
{
    public class GetPackageByIdQueryHandler : IRequestHandler<GetPackageByIdQuery, PackageDto>
    {
        private readonly IRepository<Package> _packageRepository;
        private readonly IMapper _mapper;

        public GetPackageByIdQueryHandler(IMapper mapper,
            IRepository<Package> packageRepository)
        {
            _packageRepository = packageRepository;
            _mapper = mapper;
        }

        public async Task<PackageDto> Handle(GetPackageByIdQuery request, CancellationToken cancellationToken)
        {
            var package = await _packageRepository.GetAsync(request.Id);

            if (package == null)
                throw new NotFoundException("Package");

            return _mapper.Map<PackageDto>(package);

        }
    }
}

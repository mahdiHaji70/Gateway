using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.CargoTypes.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.CargoTypes.Queries.GetCargoTypeLookup
{
    public class GetCargoTypeLookupQueryHandler : IRequestHandler<GetCargoTypeLookupQuery, PagedResult<CargoTypeDto>>
    {
        private readonly ICargoTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetCargoTypeLookupQueryHandler(ICargoTypeRepository repository, IMapper mapper)
        { _repository = repository; _mapper = mapper; }

        public async Task<PagedResult<CargoTypeDto>> Handle(GetCargoTypeLookupQuery request, CancellationToken cancellationToken)
            => _mapper.Map<PagedResult<CargoTypeDto>>(await _repository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search));
    }
}

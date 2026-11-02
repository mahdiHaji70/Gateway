using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Countries.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Countries.Queries.GetCountryLookup
{
    public class GetCountryLookupQueryHandler : IRequestHandler<GetCountryLookupQuery, PagedResult<CountryDto>>
    {
        private readonly ICountryRepository _repository;
        private readonly IMapper _mapper;

        public GetCountryLookupQueryHandler(ICountryRepository repository, IMapper mapper)
        { _repository = repository; _mapper = mapper; }

        public async Task<PagedResult<CountryDto>> Handle(GetCountryLookupQuery request, CancellationToken cancellationToken)
            => _mapper.Map<PagedResult<CountryDto>>(await _repository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search));
    }
}

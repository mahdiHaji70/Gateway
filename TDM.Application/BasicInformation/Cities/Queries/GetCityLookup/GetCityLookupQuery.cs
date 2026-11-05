using MediatR;
using TDM.Application.BasicInformation.Cities.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Cities.Queries.GetCityLookup
{
    public record GetCityLookupQuery(string? Search = null, int PageNumber = 1, int PageSize = 20)
        : IRequest<PagedResult<CityDto>>;
}

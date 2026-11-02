using MediatR;
using TDM.Application.BasicInformation.Countries.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Countries.Queries.GetCountryLookup
{
    public record GetCountryLookupQuery(string? Search = null, int PageNumber = 1, int PageSize = 20)
        : IRequest<PagedResult<CountryDto>>;
}

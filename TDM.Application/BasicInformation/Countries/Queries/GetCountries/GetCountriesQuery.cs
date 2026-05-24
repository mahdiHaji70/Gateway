using MediatR;
using TDM.Application.BasicInformation.Countries.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Countries.Queries.GetCountries
{
    public record GetCountriesQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<CountryDto>>;

}

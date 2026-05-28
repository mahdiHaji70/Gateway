using MediatR;
using TDM.Application.BasicInformation.Cities.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Cities.Queries.GetCities
{
    public record GetCitiesQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<CityDto>>;

}

using MediatR;
using TDM.Application.BasicInformation.Cities.DTOs;

namespace TDM.Application.BasicInformation.Cities.Queries.GetCityById
{
    public record GetCityByIdQuery(Guid Id) : IRequest<CityDto>;

}

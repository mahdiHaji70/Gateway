using MediatR;
using TDM.Application.BasicInformation.Countries.DTOs;

namespace TDM.Application.BasicInformation.Countries.Queries.GetCountryById
{
    public record GetCountryByIdQuery(Guid Id) : IRequest<CountryDto>;

}

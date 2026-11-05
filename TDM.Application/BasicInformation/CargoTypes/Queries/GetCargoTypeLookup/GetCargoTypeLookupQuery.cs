using MediatR;
using TDM.Application.BasicInformation.CargoTypes.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.CargoTypes.Queries.GetCargoTypeLookup
{
    public record GetCargoTypeLookupQuery(string? Search = null, int PageNumber = 1, int PageSize = 20)
        : IRequest<PagedResult<CargoTypeDto>>;
}

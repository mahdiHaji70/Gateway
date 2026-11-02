using MediatR;
using TDM.Application.BasicInformation.Traffics.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Traffics.Queries.GetTrafficLookup
{
    public record GetTrafficLookupQuery(string? Search = null, int PageNumber = 1, int PageSize = 20)
        : IRequest<PagedResult<TrafficDto>>;
}

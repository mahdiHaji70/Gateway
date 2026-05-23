using MediatR;
using TDM.Application.BasicInformation.Traffics.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Traffics.Queries.GetTraffics
{
    public record GetTrafficsQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<TrafficDto>>;

}

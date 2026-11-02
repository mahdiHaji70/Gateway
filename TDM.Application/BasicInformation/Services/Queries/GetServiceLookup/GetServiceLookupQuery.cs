using MediatR;
using TDM.Application.BasicInformation.Services.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Services.Queries.GetServiceLookup
{
    public record GetServiceLookupQuery(string? Search = null, int PageNumber = 1, int PageSize = 20)
        : IRequest<PagedResult<ServiceDto>>;
}

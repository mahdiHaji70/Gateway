using MediatR;
using TDM.Application.BasicInformation.Services.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Services.Queries.GetServices
{
    public record GetServicesQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<ServiceDto>>;
}

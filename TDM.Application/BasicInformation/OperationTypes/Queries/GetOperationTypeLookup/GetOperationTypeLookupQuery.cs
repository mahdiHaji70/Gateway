using MediatR;
using TDM.Application.BasicInformation.OperationTypes.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.OperationTypes.Queries.GetOperationTypeLookup
{
    public record GetOperationTypeLookupQuery(string? Search = null, int PageNumber = 1, int PageSize = 20)
        : IRequest<PagedResult<OperationTypeDto>>;
}

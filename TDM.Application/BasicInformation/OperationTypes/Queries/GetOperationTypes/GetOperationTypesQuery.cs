using MediatR;
using TDM.Application.BasicInformation.OperationTypes.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.OperationTypes.Queries.GetOperationTypes
{
    public record GetOperationTypesQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<OperationTypeDto>>;

}

using MediatR;
using TDM.Application.BasicInformation.OperationTypes.DTOs;

namespace TDM.Application.BasicInformation.OperationTypes.Queries.GetOperationTypeById
{
    public record GetOperationTypeByIdQuery(Guid Id) : IRequest<OperationTypeDto>;

}

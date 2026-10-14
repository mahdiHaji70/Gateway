using MediatR;
using TDM.Application.BasicInformation.Services.DTOs;

namespace TDM.Application.BasicInformation.Services.Queries.GetServiceById
{
    public record GetServiceByIdQuery(Guid Id) : IRequest<ServiceDto>;
}

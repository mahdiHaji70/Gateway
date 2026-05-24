using MediatR;
using TDM.Application.BasicInformation.Traffics.DTOs;

namespace TDM.Application.BasicInformation.Traffics.Queries.GetTrafficById
{
    public record GetTrafficByIdQuery(Guid Id) : IRequest<TrafficDto>;

}

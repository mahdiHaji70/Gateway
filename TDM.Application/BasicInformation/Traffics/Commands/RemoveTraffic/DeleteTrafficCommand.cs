using MediatR;

namespace TDM.Application.BasicInformation.Traffics.Commands.RemoveTraffic
{
    public class DeleteTrafficCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteTrafficCommand(Guid id)
        {
            Id = id;
        }
    }
}

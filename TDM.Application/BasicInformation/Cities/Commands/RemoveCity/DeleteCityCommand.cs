using MediatR;

namespace TDM.Application.BasicInformation.Cities.Commands.RemoveCity
{
    public class DeleteCityCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteCityCommand(Guid id)
        {
            Id = id;
        }
    }
}

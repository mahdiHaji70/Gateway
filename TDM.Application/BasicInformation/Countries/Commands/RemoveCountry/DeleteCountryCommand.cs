using MediatR;

namespace TDM.Application.BasicInformation.Countries.Commands.RemoveCountry
{
    public class DeleteCountryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteCountryCommand(Guid id)
        {
            Id = id;
        }
    }
}

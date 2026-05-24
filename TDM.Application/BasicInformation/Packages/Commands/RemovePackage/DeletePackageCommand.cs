using MediatR;

namespace TDM.Application.BasicInformation.Packages.Commands.RemovePackage
{
    public class DeletePackageCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeletePackageCommand(Guid id)
        {
            Id = id;
        }
    }
}

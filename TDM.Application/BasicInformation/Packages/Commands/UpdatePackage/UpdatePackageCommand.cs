using MediatR;

namespace TDM.Application.BasicInformation.Packages.Commands.UpdatePackage
{
    public record UpdatePackageCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; init; } = default!;
        public string Code { get; init; } = default!;
    }
}

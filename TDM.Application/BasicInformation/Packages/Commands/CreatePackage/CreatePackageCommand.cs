using MediatR;

namespace TDM.Application.BasicInformation.Packages.Commands.CreatePackage
{
    public record CreatePackageCommand : IRequest<Guid>
    {
        public string Name { get; init; } = default!;
        public string Code { get; init; } = default!;
    }
}

using MediatR;

namespace TDM.Application.BasicInformation.Terminals.Commands.UpdateTerminal
{
    public record UpdateTerminalCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Code { get; init; } = default!;
        public string Name { get; init; } = default!;
        public string PortCode { get; init; } = default!;
        public string Username { get; init; } = default!;
        public string Password { get; init; } = default!;
        public bool IsActive { get; init; } = default!;

    }
}

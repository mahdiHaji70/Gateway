using MediatR;

namespace TDM.Application.BasicInformation.Declarations.Commands.CreateDeclaration
{
    public record CreateDeclarationCommand : IRequest<Guid>
    {
        public string Number { get; init; } = default!;
        public DateTime StartDate { get; init; } = default!;
        public DateTime EndDate { get; init; } = default!;
        public Guid ConsigneeId { get; set; }
        public Guid ConsigneerepId { get; set; }
        public Guid TrafficId { get; set; }
        public string Description { get; set; } = default!;
        public string TerminalCode { get; set; } = default!;
    }
}

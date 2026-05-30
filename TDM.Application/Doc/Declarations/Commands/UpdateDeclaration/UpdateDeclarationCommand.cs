using MediatR;

namespace TDM.Application.BasicInformation.Declarations.Commands.UpdateDeclaration
{
    public record UpdateDeclarationCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Number { get; init; } = default!;
        public DateTime StartDate { get; init; } = default!;
        public DateTime EndDate { get; init; } = default!;
        public Guid ConsigneeId { get; set; }
        public Guid ConsigneeRepId { get; set; }
    }
}

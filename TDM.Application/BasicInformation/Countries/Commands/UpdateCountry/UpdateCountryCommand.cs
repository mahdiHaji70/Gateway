using MediatR;

namespace TDM.Application.BasicInformation.Countries.Commands.UpdateCountry
{
    public record UpdateCountryCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; init; } = default!;
        public string Code { get; init; } = default!;
    }
}

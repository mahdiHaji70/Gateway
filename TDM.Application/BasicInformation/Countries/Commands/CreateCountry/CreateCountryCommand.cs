using MediatR;

namespace TDM.Application.BasicInformation.Countries.Commands.CreateCountry
{
    public record CreateCountryCommand : IRequest<Guid>
    {
        public string Name { get; init; } = default!;
        public string Code { get; init; } = default!;
    }
}

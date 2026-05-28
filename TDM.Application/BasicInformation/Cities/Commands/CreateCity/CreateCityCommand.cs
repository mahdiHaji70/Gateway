using MediatR;

namespace TDM.Application.BasicInformation.Cities.Commands.CreateCity
{
    public record CreateCityCommand : IRequest<Guid>
    {
        public string Name { get; init; } = default!;
        public string Code { get; init; } = default!;
        public Guid CountryId { get; set; }
    }
}

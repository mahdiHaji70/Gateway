using MediatR;

namespace TDM.Application.BasicInformation.Cities.Commands.UpdateCity
{
    public record UpdateCityCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; init; } = default!;
        public string Code { get; init; } = default!;
        public Guid CountryId { get; set; } 
    }
}

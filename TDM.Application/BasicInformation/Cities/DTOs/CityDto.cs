namespace TDM.Application.BasicInformation.Cities.DTOs
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? code { get; set; }

        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }
        public string? CountryCode { get; set; }

    }
}

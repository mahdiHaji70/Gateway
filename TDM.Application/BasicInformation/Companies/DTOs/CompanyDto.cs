using TDM.Domain.Enums;

namespace TDM.Application.BasicInformation.Companies.DTOs
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public CompanyType CompanyType { get; set; }
        public string? Name { get; set; }
        public string? NationalId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string? Address { get; set; }
        public string? PostCode { get; set; }
        public string? Mobile { get; set; }
        public string? EconomicCode { get; set; }
        public string? RegisterNumber { get;     set; }
        public string? RegisterPlace { get; set; }
        public string? Phone { get; set; }
    }
}

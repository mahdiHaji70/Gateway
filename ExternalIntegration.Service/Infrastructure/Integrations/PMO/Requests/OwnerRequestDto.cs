namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class OwnerRequestDto
    {
        public string Name { get; set; }
        public string NationalID { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string CellPhone { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public Boolean? IsCompany { get; set; }
    }
}
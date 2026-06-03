namespace ExternalIntegration.Service.Sync.DTOs
{
    public class OwnerDto
    {
        public string Name { get; set; } = default!;
        public string NationalID { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime Date { get; set; }
        public string CellPhone { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string Address { get; set; } = default!;
        public Boolean? IsCompany { get; set; }
    }
}
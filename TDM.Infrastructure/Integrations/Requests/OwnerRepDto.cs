namespace TDM.Infrastructure.Integrations.Requests
{
    public class OwnerRepDto
    {
        public string Name { get; set; } = default!;
        public string NationalID { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime BirthDate { get; set; }
        public string CellPhone { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string Address { get; set; } = default!;
    }
}
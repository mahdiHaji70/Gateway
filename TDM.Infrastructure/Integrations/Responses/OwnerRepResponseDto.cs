namespace TDM.Infrastructure.Integrations.Responses
{
    public class OwnerRepResponseDto
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
namespace IntegratedIdentity.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string NationalId { get; set; } = default!;
    }
}

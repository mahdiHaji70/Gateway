using Microsoft.AspNetCore.Identity;

namespace IntegratedIdentity.Domain
{
    public class User : IdentityUser<Guid>
    {
        public required string Name { get; set; }
        public required string NationalId { get; set; }        
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

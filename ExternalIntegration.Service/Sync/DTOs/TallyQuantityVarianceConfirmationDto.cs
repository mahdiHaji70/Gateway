using System.ComponentModel.DataAnnotations;

namespace ExternalIntegration.Service.Sync.DTOs
{
    public class TallyQuantityVarianceConfirmationDto
    {
        [Required]
        public string TerminalCode { get; set; } = string.Empty;
        public Guid Id { get; set; }
    }
}

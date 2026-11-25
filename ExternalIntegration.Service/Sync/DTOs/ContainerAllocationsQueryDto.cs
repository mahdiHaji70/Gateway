using System.ComponentModel.DataAnnotations;

namespace ExternalIntegration.Service.Sync.DTOs
{
    public class ContainerAllocationsQueryDto
    {
        [Required]
        public string TerminalCode { get; set; } = string.Empty;
        [Required]
        public string VoyageNoticeNo { get; set; } = string.Empty;
    }
}

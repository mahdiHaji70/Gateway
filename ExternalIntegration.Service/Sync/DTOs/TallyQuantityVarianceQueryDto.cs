using System.ComponentModel.DataAnnotations;

namespace ExternalIntegration.Service.Sync.DTOs
{
    public class TallyQuantityVarianceQueryDto
    {
        [Required]
        public string TerminalCode { get; set; } = string.Empty;
        [Required]
        public DateTime? FromDate { get; set; }
        [Required]
        public DateTime? ToDate { get; set; }
        [Range(1, int.MaxValue)]
        public int PageIndex { get; set; } = 1;
        [Range(10, 100)]
        public int PageSize { get; set; } = 20;
    }
}

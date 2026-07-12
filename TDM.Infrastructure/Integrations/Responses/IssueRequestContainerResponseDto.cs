namespace TDM.Infrastructure.Integrations.Responses
{
    public class IssueRequestContainerResponseDto
    {
        public string ContainerNo { get; set; }
        public string ContainerTypeAndSizeCode { get; set; }
        public string SealNumber { get; set; }
        public string Remark { get; set; }
        public List<IssueRequestContainerGoodResponseDto> Goods { get; set; }
       
    }
}
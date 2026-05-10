



namespace ExternalIntegration.Service.Sync.DTOs
{
    public class CreateStorageAgreementDto
    {
        public string TerminalCode { get; set; }
        public DateTime AgreementDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public String CustomsProcedureCode { get; set; }
        public OwnerDto Owner { get; set; }
        public OwnerRepDto OwnerRep { get; set; }
        public string WorkflowRemark { get; set; }
    }
}

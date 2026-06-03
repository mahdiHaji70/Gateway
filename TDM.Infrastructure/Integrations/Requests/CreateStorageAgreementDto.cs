namespace TDM.Infrastructure.Integrations.Requests
{
    public class CreateStorageAgreementDto
    {
        public string TerminalCode { get; set; } = default!;
        public DateTime AgreementDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string CustomsProcedureCode { get; set; } = default!;
        public OwnerDto Owner { get; set; } = default!;
        public OwnerRepDto OwnerRep { get; set; } = default!;
        public string WorkflowRemark { get; set; } = default!;
    }
}

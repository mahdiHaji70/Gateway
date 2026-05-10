using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class CreateStorageAgreementRequestDto
    {
        public string TerminalCode { get; set; }
        public DateTime AgreementDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public String CustomsProcedureCode { get; set; }
        public OwnerRequestDto Owner { get; set; }
        public OwnerRepRequestDto OwnerRep { get; set; }
        public string WorkflowRemark { get; set; }
    }

}

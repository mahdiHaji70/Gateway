using System;
using System.Collections.Generic;
using System.Text;
using TDM.Infrastructure.Integrations.Requests;

namespace TDM.Infrastructure.Integrations.Responses
{
    public class IssueRequestResponseDto
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public string StorageAgreementNo { get; set; }
        public string Port { get; set; }
        public string PortCode { get; set; }
        public string Terminal { get; set; }
        public string TerminalCode { get; set; }
        public DateTime Date { get; set; }
        public string Remark { get; set; }
        public string State { get; set; }
        public OwnerResponseDto Owner { get; set; }
        public OwnerRepResponseDto OwnerRep { get; set; }
        public string RequestRemark { get; set; }
        public DateTime? TaskRegisterDate { get; set; }
        public List<IssueRequestGeneralCargoResponseDto> GeneralCargoList { get; set; }
        public List<IssueRequestBulkResponseDto> BulkList { get; set; }
        public List<IssueRequestContainerResponseDto> ContainerList { get; set; }
      
    }
}

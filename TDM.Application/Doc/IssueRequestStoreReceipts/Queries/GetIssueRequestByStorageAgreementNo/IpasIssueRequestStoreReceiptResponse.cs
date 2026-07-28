using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.IssueRequestStoreReceipt.Queries.GetIssueRequestByStorageAgreementNo
{
    public class IpasIssueRequestStoreReceiptResponse
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
        public string OwnerName { get; set; }
        public string OwnerNationalID { get; set; }
        public string OwnerRepName { get; set; }
        public string OwnerRepNationalID { get; set; }
        public string RequestRemark { get; set; }
        public DateTime? TaskRegisterDate { get; set; }
        public string HsCode { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string PackageTypeCode { get; set; } 
        public string PackageType { get; set; }
        public decimal? PackageQuantity { get; set; }
        public decimal Weight { get; set; }
        public decimal? Volume { get; set; }
        public string ContainerNo { get; set; }
      
    }
}

namespace TDM.Application.BasicInformation.DeclarationItems.Commands.RequestIpasDeclarationItems
{
    public class IpasDeclarationItemsRequest
    {
        public string TerminalCode { get; set; }
        public string IpasDeclarationId { get; set; } = default!;

        public IpasDeclarationItemsRequest(string terminalCode ,string ipasDeclarationId)
        {
            TerminalCode = terminalCode;
            IpasDeclarationId = ipasDeclarationId;
        }
    }
}
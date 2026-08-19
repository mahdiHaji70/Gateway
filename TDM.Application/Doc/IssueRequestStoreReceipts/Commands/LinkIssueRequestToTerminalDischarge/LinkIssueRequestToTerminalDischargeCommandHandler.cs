using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.IssueRequestStoreReceipt.Commands.IssueRequestConfirmation;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.IssueRequestStoreReceipts.Commands.LinkIssueRequestToTerminalDischarge
{
    public class LinkIssueRequestToTerminalDischargeCommandHandler : IRequestHandler<LinkIssueRequestToTerminalDischargeCommand, bool>
    {
        private readonly ITerminalDischargeRepository _terminalDischargeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIssueRequestStoreReceiptExternalService _issueRequestExternalService;

        public LinkIssueRequestToTerminalDischargeCommandHandler(IUnitOfWork unitOfWork,
            IIssueRequestStoreReceiptExternalService issueRequestExternalService
            , ITerminalDischargeRepository terminalDischargeRepository)
        {
            _unitOfWork = unitOfWork;
            _issueRequestExternalService = issueRequestExternalService;
            _terminalDischargeRepository = terminalDischargeRepository;
        }

        public async Task<bool> Handle(LinkIssueRequestToTerminalDischargeCommand request, CancellationToken cancellationToken)
        {
            var issueRequestItems =
               await _issueRequestExternalService.GetIssueReceiptById(request.IssurRequestId);

            var terminalDischarges=await _terminalDischargeRepository.GetIpasSubmissionByIPASDeclarationNoAsync(request.StorageAgreementNo);


            if (issueRequestItems == null || !issueRequestItems.Any())
                throw new Exception("No issue request items were found.");

            if (terminalDischarges == null || !terminalDischarges.Any())
                throw new Exception("No terminal discharge records were found.");

            var issueRequestTotalPackNB =
               issueRequestItems.Sum(x => x.PackageQuantity);

            var issueRequestTotalWeight =
                issueRequestItems.Sum(x => x.Weight);


            foreach (var item in issueRequestItems)
            {
                var terminalDischarge =
                    terminalDischarges.FirstOrDefault(x =>
                        x.IssueRequestId == null &&
                        x.DeclarationItem.Package.Code == item.PackageType &&
                        x.PackNB == item.PackageQuantity &&
                        Math.Abs(x.Weight - item.Weight) < 0.001m
                    );

                if (terminalDischarge == null)
                    throw new Exception(
                                $"TerminalDischarge matching the issue request item was not found. " +
                                $"PackageType: {item.PackageType}, " +
                                $"PackageQuantity: {item.PackageQuantity}, " +
                                $"Weight: {item.Weight}");

                terminalDischarge.IssueRequestId =
                    request.IssurRequestId;
            }

                     
            var terminalDischargeTotalWeight =
                terminalDischarges
                    .Where(x => x.IssueRequestId == request.IssurRequestId)
                    .Sum(x => x.Weight);

            var terminalDischargeTotalPackNB =
               terminalDischarges
                   .Where(x => x.IssueRequestId == request.IssurRequestId)
                   .Sum(x => x.PackNB);

            if (Math.Abs(
                    issueRequestTotalWeight -
                    terminalDischargeTotalWeight) > 0.001m)
            {
                throw new Exception(
                    $"Weight mismatch. " +
                    $"IssueRequest weight: {issueRequestTotalWeight}, " +
                    $"TerminalDischarge weight: {terminalDischargeTotalWeight}.");
            }

            if (issueRequestTotalPackNB != terminalDischargeTotalPackNB)
            {
                throw new Exception(
                    $"Package quantity mismatch. " +
                    $"IssueRequest package quantity: {issueRequestTotalPackNB}, " +
                    $"TerminalDischarge package quantity: {terminalDischargeTotalPackNB}.");
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

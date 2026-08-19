using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Cities.Commands.RemoveCity;

namespace TDM.Application.Doc.IssueRequestStoreReceipts.Commands.LinkIssueRequestToTerminalDischarge
{

    public class LinkIssueRequestToTerminalDischargeCommandValidator : AbstractValidator<LinkIssueRequestToTerminalDischargeCommand>
    {
        public LinkIssueRequestToTerminalDischargeCommandValidator()
        {
            RuleFor(x => x.IssurRequestId)
                .NotEmpty();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TDM.Domain.Common;
using TDM.Domain.Exceptions;

namespace TDM.Domain.Entities
{
    public class UserTerminal : BaseEntity
    {
        public string UserNationalId { get; set; }

        public Guid TerminalId { get; set; }
        public Terminal Terminal { get; set; }

        public UserTerminal(string userNationalId, Guid terminalId)
        => SetProperties(userNationalId, terminalId);

        public void Update(string userNationalId, Guid terminalId)
        => SetProperties(userNationalId, terminalId);

        private void SetProperties(string userNationalId, Guid terminalId)
        {
            Validate(userNationalId, terminalId);

            UserNationalId = userNationalId;
            TerminalId = terminalId;
        }

        private void Validate(string userNationalId, Guid terminalId)
        {
            if (string.IsNullOrEmpty(userNationalId))
                throw new DomainValidationException("User National Id is required.");

            if (terminalId == Guid.Empty)
                throw new DomainValidationException("Terminal Id Id is required.");
        }
    }
}

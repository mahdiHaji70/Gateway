using TDM.Domain.Enums;

namespace TDM.Domain.Entities
{
    public class DocumentSerialCounter
    {
        public DocumentSerialType SerialType { get; private set; }
        public string TerminalCode { get; private set; } = string.Empty;
        public int JalaliYear { get; private set; }
        public long LastCounter { get; private set; }
        public byte[] RowVersion { get; private set; } = [];

        private DocumentSerialCounter()
        {
        }

        public DocumentSerialCounter(DocumentSerialType serialType, string terminalCode, int jalaliYear)
        {
            SerialType = serialType;
            TerminalCode = terminalCode;
            JalaliYear = jalaliYear;
            LastCounter = 1;
        }

        public long Increment()
        {
            LastCounter++;
            return LastCounter;
        }
    }
}

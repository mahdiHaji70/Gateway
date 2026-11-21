namespace TDM.Domain.Enums
{
    public enum DocumentSerialType
    {
        StoreExit
    }

    public static class DocumentSerialTypeCode
    {
        public static string ToCode(DocumentSerialType serialType) => serialType switch
        {
            DocumentSerialType.StoreExit => "SE",
            _ => throw new ArgumentOutOfRangeException(nameof(serialType), serialType, null)
        };

        public static DocumentSerialType FromCode(string code) => code switch
        {
            "SE" => DocumentSerialType.StoreExit,
            _ => throw new ArgumentOutOfRangeException(nameof(code), code, null)
        };
    }
}

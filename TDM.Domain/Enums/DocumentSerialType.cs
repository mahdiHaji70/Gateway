namespace TDM.Domain.Enums
{
    public enum DocumentSerialType
    {
        WarehouseExit
    }

    public static class DocumentSerialTypeCode
    {
        public static string ToCode(DocumentSerialType serialType) => serialType switch
        {
            DocumentSerialType.WarehouseExit => "WHE",
            _ => throw new ArgumentOutOfRangeException(nameof(serialType), serialType, null)
        };

        public static DocumentSerialType FromCode(string code) => code switch
        {
            "WHE" => DocumentSerialType.WarehouseExit,
            _ => throw new ArgumentOutOfRangeException(nameof(code), code, null)
        };
    }
}

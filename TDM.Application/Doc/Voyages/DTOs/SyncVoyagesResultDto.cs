namespace TDM.Application.Doc.Voyages.DTOs
{
    public class SyncVoyagesResultDto
    {
        public DateTime FromDate { get; set; }
        public DateTime LastDate { get; set; }
        public int InsertedCount { get; set; }
        public int UpdatedCount { get; set; }
    }
}

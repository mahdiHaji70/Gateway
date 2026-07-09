namespace ExternalIntegration.Service.Sync.DTOs
{
    public class GetDataWithPagingDto<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}

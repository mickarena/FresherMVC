namespace Core.Pagination

{
    public class DtoPagination<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public List<T> Items { get; set; }
    }
}

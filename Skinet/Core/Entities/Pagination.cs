namespace Core.Entities
{
    public class Pagination<T>
    {
        public List<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        public int startPage { get; set; }
        public int endPage { get; set; }
    }
}

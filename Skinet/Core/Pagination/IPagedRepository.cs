namespace Core.Pagination
{
    public interface IPagedRepository<T> where T : List<T>
    {
        public List<T> PaginatedList(List<T> items, int pageIndex);
    }
}
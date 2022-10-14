namespace Core.Interfaces
{
    public interface IPagedRepository<T> where T : List<T>
    {
        public List<T> PaginatedList(List<T> items, int count, int pageIndex, int pageSize);
    }
}
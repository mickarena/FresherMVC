using Core.Entities;

namespace Core.Pagination
{
    public interface IPagedRepository<T> where T : BaseEntity
    {
        public DtoPagination<T> PaginatedList(List<T> items, int pageIndex);
    }
}

using Core.Entities;
using Core.Pagination;

namespace Infrastructure.Data
{
    public class PageRepository<T> : IPagedRepository<T> where T : BaseEntity
    {
        private DtoPagination<T> dto = new DtoPagination<T>();

        public DtoPagination<T> PaginatedList(List<T> items, int pageIndex)
        {
            dto.PageIndex = pageIndex == 0 ? 1 : pageIndex;
            var count = items.Count;
            var pageSize = 3;
            dto.Items = items.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            dto.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            return dto;
        }
    }
}

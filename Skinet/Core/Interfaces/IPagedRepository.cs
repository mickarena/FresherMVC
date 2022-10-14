using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPagedRepository<T>
    {
        void PaginatedList(List<T> items, int count, int pageIndex, int pageSize);

        Task<DtoPagination<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize);
    }
}
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPagedRepository<T> where T : List<T>
    {
        public void PaginatedList(List<T> items, int count, int pageIndex, int pageSize);

        public Task<DtoPagination<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize);
    }
}
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Pagination
{
    public interface IPagedRepository<T> where T : BaseEntity
    {
        public DtoPagination<T> PaginatedList(List<T> items, int pageIndex);
    }
}

using Core;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PageRepository<T> : IPagedRepository<T> where T : List<T>
    {
        private DtoPagination<T> dto;

        public PageRepository()
        {
            dto = new DtoPagination<T>();
        }

        public List<T> PaginatedList(List<T> items, int pageIndex)
        {
            dto.PageIndex = pageIndex;
            var count = items.Count;
            var pageSize = 3;
            var paginationItem = items.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            dto.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            return paginationItem;
        }
    }
}
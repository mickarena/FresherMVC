using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Page
    {
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public Page() { }
        public Page(int totalItems, int page, int pageSize)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentPage = page;
            int startPage = currentPage - 3;
            int endPage = currentPage + 3;

            if (startPage <= 1)
            {

                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
            }

            TotalItems = totalItems;
            TotalPages = totalPages;
            CurrentPage = currentPage;
            PageSize = pageSize;
            StartPage = startPage;
            EndPage = endPage;


        }
    }
}

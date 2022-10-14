using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Entities.Pages;

namespace Infrastructure.Data
{
    public class PageRepository : IPageRepository
    {
        readonly StoreContext _db;

        public PageRepository(StoreContext db)
        {
            _db = db;
        }

        public Pages GetDepartments(int currentPage)
        {
            int maxRows = 10;
            Pages page = new Pages();

            page.Departments = (from Departments in _db.Departments
                                select Departments)
                        .OrderBy(Departments => Departments.Id)
                        .Skip(currentPage * maxRows)
                        .Take(maxRows).ToList();

            double pageCount = (double)(_db.Departments.Count() / Convert.ToDecimal(maxRows));
            page.PageCount = (int)Math.Ceiling(pageCount);

            page.CurrentPageIndex = currentPage;

            return page;
        }


        public Pages GetNurse(int currentPage)
        {
            var _page = currentPage < 0 ? 0 : currentPage;
            int maxRows = 10;
            Pages page = new Pages();
            page.Nurses = (from Nurses in _db.Nurse
                           select Nurses)
                        .OrderBy(Nurses => Nurses.Id)
                        .Skip(currentPage * maxRows)
                        .Take(maxRows).Include(x => x.Departments).ToList();

            double pageCount = (double)(_db.Nurse.Count() / Convert.ToDecimal(maxRows));
            page.PageCount = (int)Math.Ceiling(pageCount);

            page.CurrentPageIndex = _page;

            return page;
        }


    }
}

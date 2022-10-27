using Core.Entities;
using Core.Interfaces;
using Core.Pagination;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Web.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository _departmentRepository;
        private IPagedRepository<Department> pagedRepository;


        public DepartmentController(IDepartmentRepository departmentRepository, IPagedRepository<Department> pagedRepository)
        {
            _departmentRepository = departmentRepository;
            this.pagedRepository = pagedRepository;
        }
        public IActionResult Index(int currentPage, string search)

        {
            var list = _departmentRepository.GetAll(search);
            var dto = pagedRepository.PaginatedList(list, currentPage);
            ViewBag.TotalPage = dto.TotalPages;
            ViewBag.CurrentPage = dto.PageIndex;
            ViewBag.PageSize = dto.PageSize;
            ViewBag.SearchData = search;
            return View(dto.Items);
        }
        public IActionResult Create()
        {
            Department department = new Department();
            return PartialView("Create", department);
        }

        // POST: Nurses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Create(department);
                return RedirectToAction("Index");
            }
            return PartialView("Create", department);
        }

        // GET: Nurses/Edit/5
        public IActionResult Edit(Guid id)
        {
            var nurses = _departmentRepository.GetbyId(id);
            return PartialView("Edit", nurses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Update(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        public IActionResult Delete(Guid id)
        {
           
            var nurses = _departmentRepository.GetbyId(id);
            return PartialView("Delete", nurses);
        }
        // POST: Nurses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _departmentRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}

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
        public ActionResult Index(int currentPage, string searchString)

        {
            var list = _departmentRepository.GetAll(searchString);
            var dto = pagedRepository.PaginatedList(list, currentPage);
            ViewBag.TotalPage = dto.TotalPages;
            ViewBag.CurrentPage = dto.PageIndex;
            return View(dto.Items);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nurses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Create(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Nurses/Edit/5
        public ActionResult Edit(Guid id)
        {
            var nurses = _departmentRepository.GetbyId(id);
            return View(nurses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Update(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        public ActionResult Delete(Guid id)
        {
            var nurses = _departmentRepository.GetbyId(id);
            return View(nurses);
        }
        // POST: Nurses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _departmentRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}

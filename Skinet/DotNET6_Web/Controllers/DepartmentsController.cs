using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    public class DepartmentsController : Controller
    {
        private IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }


        // GET: Department
        public ActionResult Index()
        {
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }

        // GET: Department/Details/5
        public ActionResult Details(Guid id)
        {
            var departments = _departmentRepository.GetbyId(id);

            return View(departments);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departments departments)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Create(departments);
                return RedirectToAction("Index");
            }
            return View(departments);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(Guid id)
        {
            var departments = _departmentRepository.GetbyId(id);
            return View(departments);
        }

        // POST: Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Departments departments)
        {

            if (ModelState.IsValid)
            {
                _departmentRepository.Update(departments);
                return RedirectToAction("Index");
            }
            return View(departments);
        }

        // GET: Department/Delete/5
        public ActionResult Delete(Guid id)
        {
            var departments = _departmentRepository.GetbyId(id);
            return View(departments);

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

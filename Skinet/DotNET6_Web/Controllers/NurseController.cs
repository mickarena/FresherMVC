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
    public class NurseController : Controller
    {

        private INurseRepository _nurseRepository;

        private IDepartmentRepository _departmentRepository;
        private IPageRepository _pageRepository;

        public NurseController(INurseRepository nurseRepository, IDepartmentRepository departmentRepository, IPageRepository pageRepository)
        {
            _nurseRepository = nurseRepository;
            _departmentRepository = departmentRepository;

            _pageRepository = pageRepository;
        }

        // GET: Nurses
        public ActionResult Index(int currentPage)
        {
            ViewBag.CurrentPageIndex = currentPage;
            var Page = _pageRepository.GetDepartments(currentPage);
            ViewBag.PageCount = Page.PageCount;
            return View(Page);
        }

        // GET: Nurses/Details/5
        public ActionResult Details(Guid id)
        {
            var nurses = _nurseRepository.GetbyId(id);
            LoadData();

            return View(nurses);
        }

        // GET: Nurses/Create
        public ActionResult Create()
        {
            LoadData();

            return View();
        }

        // POST: Nurses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                _nurseRepository.Create(nurse);
                return RedirectToAction("Index");
            }
            LoadData();
            return View(nurse);
        }

        // GET: Nurses/Edit/5
        public ActionResult Edit(Guid id)
        {
            var nurses = _nurseRepository.GetbyId(id);
            LoadData();
            return View(nurses);
        }

        // POST: Nurses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Nurse nurse)
        {

            if (ModelState.IsValid)
            {
                _nurseRepository.Update(nurse);
                return RedirectToAction("Index");
            }
            LoadData();
            return View(nurse);
        }

        // GET: Nurses/Delete/5
        public ActionResult Delete(Guid id)
        {
            var nurses = _nurseRepository.GetbyId(id);
            return View(nurses);

        }

        // POST: Nurses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _nurseRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public void LoadData()
        {
            var departments = _departmentRepository.GetAll();
            ViewBag.SelectDDepartments = new SelectList(departments, "Id", "Name");
        }
    }
}

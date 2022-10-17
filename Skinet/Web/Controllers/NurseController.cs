using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Web.Controllers
{
    public class NurseController : Controller
    {
        private INurseRepository _nurseRepository;

        private IDepartmentRepository _departmentRepository;

        public NurseController(INurseRepository nurseRepository, IDepartmentRepository departmentRepository)
        {
            _nurseRepository = nurseRepository;
            _departmentRepository = departmentRepository;
        }
        public ActionResult Index()
        {
            var nurses = _nurseRepository.GetAll();
            return View(nurses);
        }
        public ActionResult Create()
        {
            LoadData();
            return View();
        }

        // POST: Nurses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Nurse nurse)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                _nurseRepository.Update(nurse);
                return RedirectToAction("Index");
            }
            LoadData();
            return View(nurse);
        }

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

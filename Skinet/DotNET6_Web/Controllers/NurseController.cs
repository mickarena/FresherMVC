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

        public NurseController(INurseRepository nurseRepository)
        {
            _nurseRepository = nurseRepository;
        }





        // GET: Nurses
        public ActionResult Index()
        {
            var nurses = _nurseRepository.GetAll();
            return View(nurses);
        }

        // GET: Nurses/Details/5
        public ActionResult Details(Guid id)
        {
            var nurses = _nurseRepository.GetbyId(id);

            return View(nurses);
        }

        // GET: Nurses/Create
        public ActionResult Create()
        {
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
            return View(nurse);
        }

        // GET: Nurses/Edit/5
        public ActionResult Edit(Guid id)
        {
            var nurses = _nurseRepository.GetbyId(id);
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
    }
}

using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }       
        public async Task<IActionResult> Index()
        {
            var model = await _doctorRepository.GetDoctor();
            return View(model);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor model)
        {

            if (ModelState.IsValid)
            {
                await _doctorRepository.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        
        public async Task<IActionResult> Edit(Guid id)
        {
            var doctor = await _doctorRepository.GetById(id);
            return View(doctor);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(Doctor model)
        {
            if (ModelState.IsValid)
            {
                await _doctorRepository.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var doctor =  await _doctorRepository.GetById(id);
            return View(doctor);
        }
        
        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            if (ModelState.IsValid) {
                await _doctorRepository.Delete(id);
                return RedirectToAction("Index");
            }              
            return View(id);
        }
    }
}

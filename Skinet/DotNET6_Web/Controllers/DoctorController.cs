using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorController(IDoctorRepository doctorRepository)
        {
                _doctorRepository = doctorRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await _doctorRepository.GetDoctor();
            return View("Index");
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
    }
}

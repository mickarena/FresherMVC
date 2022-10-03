using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
    }
}

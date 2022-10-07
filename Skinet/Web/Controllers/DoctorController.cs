using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DoctorController(IDoctorRepository doctorRepository, IWebHostEnvironment webHostEnvironment)
        {
            _doctorRepository = doctorRepository;
            _webHostEnvironment = webHostEnvironment;
        }       
        public async Task<IActionResult> Index(int pg = 1)
        {
            var model = await _doctorRepository.GetDoctor();

            const int pageSize = 3;
            if (pg < 1)
                pg = 1;
            int recsCount = model.Count();

            var page = new Page(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = model.Skip(recSkip).Take(page.PageSize).ToList();

            this.ViewBag.Page = page;

            //return View(model);
            return View(data);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor model)
        {

            if (!ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                model.Image = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                string path = Path.Combine(wwwRootPath + "/image/doctors", model.Image);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fileStream);
                }

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
            if (!ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                model.Image = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                string path = Path.Combine(wwwRootPath + "/image/doctors", model.Image);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fileStream);
                }
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

        public async Task<IActionResult> Search(string searchName)
        {
            var result = await _doctorRepository.Search(searchName);
            return View("Index", result);
        }
    }
}

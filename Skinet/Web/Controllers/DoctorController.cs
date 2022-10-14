using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Index(int pg = 1, int pageSize = 1)
        {
            var model = await _doctorRepository.GetDoctor();  
            
            var page =  new Page(model.Count(), pg , pageSize);
            var data = model.Skip((pg - 1) * pageSize).Take(page.PageSize).ToList();
            ViewBag.Page = page;

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        

        [HttpPost]
        public async Task<IActionResult> Create(Doctor model)
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
        
        public async Task<IActionResult> Edit(Guid id)
        {
            var doctor = await _doctorRepository.GetById(id);
            return View(doctor);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(Doctor model)
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
        
        public async Task<IActionResult> Delete(Guid id)
        {
            var doctor =  await _doctorRepository.GetById(id);
            return View(doctor);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Deleted(Guid id)
        {
            if (ModelState.IsValid) {
                var doctor = await _doctorRepository.GetById(id);
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "image/doctors", doctor.Image);
                if (System.IO.File.Exists(imagePath))
                    System.IO.File.Delete(imagePath);
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

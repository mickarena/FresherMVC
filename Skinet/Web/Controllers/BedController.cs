using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Core.Entities;
using System;

namespace Web.Controllers
{
    public class BedController : Controller
    {
        private IBedRepository _bedRepository;

        public BedController(IBedRepository bedRepository)
        {
            _bedRepository = bedRepository;
        }

        // GET: BedController
        public async Task<ActionResult> Index()
        {
            
            
            var test = await _bedRepository.ListAllAsync();
            return View(test);
        }

        // GET: BedController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BedController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BedController/Create
        [HttpPost]
       
        public async Task<ActionResult> Create(HospitalBed bed)
        {
            try
            {
                var beds = await _bedRepository.Create(bed);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BedController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var beds = await _bedRepository.GetById(id);
            return View(beds);
        }

        // POST: BedController/Edit/5
        [HttpPost]
        public async Task< ActionResult> Edit(HospitalBed bed)
        {
            try
            {
                var beds = await _bedRepository.Update(bed);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BedController/Delete/5
        public async Task< ActionResult> Delete(Guid id)
        {
            var beds = await _bedRepository.GetById(id);
            return View(beds);
        }

        // POST: BedController/Delete/5
        [HttpPost]
        
        public async Task<ActionResult>Deleted(Guid id)
        {
            try
             {
                var beds = await _bedRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(id);
            }
        }
    }
}
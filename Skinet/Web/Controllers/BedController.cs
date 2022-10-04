using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Core.Entities;

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
        [ValidateAntiForgeryToken]
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BedController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BedController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BedController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
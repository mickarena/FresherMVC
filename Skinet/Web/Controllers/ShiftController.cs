using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ShiftController : Controller
    {
        private readonly IShiftRepository _shiftRepository;
        public ShiftController(IShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _shiftRepository.GetShift();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Shift shift)
        {
            if (!ModelState.IsValid)
            {
                await _shiftRepository.Create(shift);
                return RedirectToAction("Index");
            } return View(shift);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var shift = await _shiftRepository.GetById(id);
            return View(shift);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Shift shift)
        {
            if (!ModelState.IsValid)
            {
                await _shiftRepository.Update(shift);
                return RedirectToAction("Index");
            } return View(shift);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var shift = await _shiftRepository.GetById(id);
            return View(shift);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            if (ModelState.IsValid)
            {
                await _shiftRepository.Delete(id);
                return RedirectToAction("Index");
            }
            return View(id);
        }

        public async Task<IActionResult> Search(string searchName)
        {
            var result = await _shiftRepository.Search(searchName);
            return View("Index", result);
        }
    }
}
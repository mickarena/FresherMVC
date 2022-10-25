using Core.Entities;
using Core.Interfaces;
using Core.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ShiftController : Controller
    {
        private readonly IShiftRepository _shiftRepository;
        private IPagedRepository<Shift> pagedRepository;
        public ShiftController(IShiftRepository shiftRepository, IPagedRepository<Shift> pagedRepository)
        {
            _shiftRepository = shiftRepository;
            this.pagedRepository = pagedRepository;
        }

        // Search
        public async Task<IActionResult> Search(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var result = await _shiftRepository.Search(searchString);
            return View("Index", result);
        }

        // GET/Index
        public async Task<IActionResult> Index(int currentPage)
        {
            var model = _shiftRepository.GetType();
            var dto = pagedRepository.PaginatedList(model, currentPage);
            ViewBag.TotalPage = dto.TotalPages;
            ViewBag.CurrentPage = dto.PageIndex;
            return View(dto.Items);
        }

        // POST/Delete
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

        // GET/CreateOrEdit
        public async Task<IActionResult> CreateOrEdit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return View();
            }
            else
            {
                var shift = await _shiftRepository.GetById(id);
                return View(shift);
            }
        }

        // POST/CreateOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(Shift shift)
        {
            if (shift.Id == Guid.Empty)
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    await _shiftRepository.Create(shift);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await _shiftRepository.Edit(shift);
                    return RedirectToAction("Index");
                }
            }
            return View(shift);
        }
    }
}
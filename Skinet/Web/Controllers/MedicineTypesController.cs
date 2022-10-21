using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure.Data;
using Core.Interfaces;
using Core.Pagination;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Web.Controllers
{
    public class MedicineTypesController : Controller
    {
        private IMedicineTypeRepository _medicineType;
        private IPagedRepository<MedicineType> pagedRepository;

        public MedicineTypesController(IMedicineTypeRepository medicineType, IPagedRepository<MedicineType> pagedRepository)
        {
            _medicineType = medicineType;
            this.pagedRepository = pagedRepository;
        }

        // GET: MedicineTypes
        public async Task<IActionResult> Index(int currentPage, string search)

        {
            var list = _medicineType.GetType(search);
            var dto = pagedRepository.PaginatedList(list, currentPage);
            ViewBag.TotalPage = dto.TotalPages;
            ViewBag.CurrentPage = dto.PageIndex;
            ViewBag.SearchData = search;
            return View(dto.Items);
        }

        // GET: MedicineTypes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var medicineType = _medicineType.GetById(id).Result;
            if (medicineType == null)
            {
                return NotFound();
            }

            return View(medicineType);
        }

        // GET: MedicineTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicineTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicineType medicineType)
        {
            if (ModelState.IsValid)
            {
                medicineType.Id = Guid.NewGuid();
                await _medicineType.Create(medicineType);
                return RedirectToAction(nameof(Index));
            }
            return View(medicineType);
        }

        // GET: MedicineTypes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var medicineType = _medicineType.GetById(id).Result;
            if (medicineType == null)
            {
                return NotFound();
            }
            return View(medicineType);
        }

        // POST: MedicineTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MedicineType medicineType)
        {
            if (id != medicineType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _medicineType.Update(medicineType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineTypeExists(medicineType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medicineType);
        }

        // GET: MedicineTypes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var medicineType = _medicineType.GetById(id).Result;
            if (medicineType == null)
            {
                return NotFound();
            }

            return View(medicineType);
        }

        // POST: MedicineTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_medicineType.GetType(null) == null)
            {
                return Problem("Entity set 'StoreContext.MedicineTypes'  is null.");
            }
            var medicineType = _medicineType.GetById(id);
            if (medicineType != null)
            {
                await _medicineType.DeleteAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MedicineTypeExists(Guid id)
        {
            return _medicineType.GetById(id).IsCompletedSuccessfully;
        }
    }
}
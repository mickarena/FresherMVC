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

namespace Web.Controllers
{
    public class MedicineInfomationsController : Controller
    {
        private IMedicineInfoRepository _medicineInfo;
        private IMedicineTypeRepository _medicineType;

        public MedicineInfomationsController(IMedicineInfoRepository medicineInfo, IMedicineTypeRepository medicineType)
        {
            _medicineInfo = medicineInfo;
            _medicineType = medicineType;
        }

        // GET: MedicineInfomations
        public async Task<IActionResult> Index()
        {
            return View(_medicineInfo.GetType());
        }

        // GET: MedicineInfomations/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var medicineInfomation = _medicineInfo.GetById(id).Result;
            if (medicineInfomation == null)
            {
                return NotFound();
            }

            return View(medicineInfomation);
        }

        // GET: MedicineInfomations/Create
        public IActionResult Create()
        {
            ViewData["MedicineIDType"] = new SelectList(_medicineType.GetType(), "Id", "Name");
            return View();
        }

        // POST: MedicineInfomations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicineIDType,Name,ImportDate,ExpireDate,Quantity,UnitPrice,IsEmpty,Id")] MedicineInfomation medicineInfomation)
        {
            if (ModelState.IsValid)
            {
                medicineInfomation.Id = Guid.NewGuid();
                _medicineInfo.Create(medicineInfomation);
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicineIDType"] = new SelectList(_medicineType.GetType(), "Id", "Name", medicineInfomation.MedicineIDType);
            return View(medicineInfomation);
        }

        // GET: MedicineInfomations/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var medicineInfomation = _medicineInfo.GetById(id).Result;
            if (medicineInfomation == null)
            {
                return NotFound();
            }
            ViewData["MedicineIDType"] = new SelectList(_medicineType.GetType(), "Id", "Name");
            return View(medicineInfomation);
        }

        // POST: MedicineInfomations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MedicineIDType,Name,ImportDate,ExpireDate,Quantity,UnitPrice,IsEmpty,Id")] MedicineInfomation medicineInfomation)
        {
            if (id != medicineInfomation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _medicineInfo.Update(medicineInfomation);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineInfomationExists(medicineInfomation.Id))
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
            ViewData["MedicineIDType"] = new SelectList(_medicineType.GetType(), "Id", "Name", medicineInfomation.MedicineIDType);
            return View(medicineInfomation);
        }

        // GET: MedicineInfomations/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var medicineInfomation = _medicineInfo.GetById(id).Result;
            if (medicineInfomation == null)
            {
                return NotFound();
            }

            return View(medicineInfomation);
        }

        // POST: MedicineInfomations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_medicineInfo.GetById(id).IsFaulted == null)
            {
                return Problem("Entity set 'StoreContext.MedicineInfomations'  is null.");
            }
            var medicineInfomation = _medicineInfo.GetById(id);
            if (medicineInfomation != null)
            {
                _medicineInfo.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineInfomationExists(Guid id)
        {
            return _medicineInfo.GetById(id).IsCompletedSuccessfully;
        }
    }
}
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entity;
using Infrastructure.Data;

namespace Web.Controllers
{
    public class MedicineInfomationsController : Controller
    {
        private readonly StoreContext _context;

        public MedicineInfomationsController(StoreContext context)
        {
            _context = context;
        }

        // GET: MedicineInfomations
        public async Task<IActionResult> Index()
        {
            var storeContext = _context.MedicineInfomations.Include(m => m.MedicineType);
            return View(await storeContext.ToListAsync());
        }

        // GET: MedicineInfomations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.MedicineInfomations == null)
            {
                return NotFound();
            }

            var medicineInfomation = await _context.MedicineInfomations
                .Include(m => m.MedicineType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicineInfomation == null)
            {
                return NotFound();
            }

            return View(medicineInfomation);
        }

        // GET: MedicineInfomations/Create
        public IActionResult Create()
        {
            ViewData["MedicineIDType"] = new SelectList(_context.MedicineTypes, "Id", "Name");
            return View();
        }

        // POST: MedicineInfomations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicineIDType,ImportDate,ExpireDate,Quantity,UnitPrice,IsEmpty,Id")] MedicineInfomation medicineInfomation)
        {
            if (ModelState.IsValid)
            {
                medicineInfomation.Id = Guid.NewGuid();
                _context.Add(medicineInfomation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicineIDType"] = new SelectList(_context.MedicineTypes, "Id", "Name", medicineInfomation.MedicineIDType);
            return View(medicineInfomation);
        }

        // GET: MedicineInfomations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.MedicineInfomations == null)
            {
                return NotFound();
            }

            var medicineInfomation = await _context.MedicineInfomations.FindAsync(id);
            if (medicineInfomation == null)
            {
                return NotFound();
            }
            ViewData["MedicineIDType"] = new SelectList(_context.MedicineTypes, "Id", "Name", medicineInfomation.MedicineIDType);
            return View(medicineInfomation);
        }

        // POST: MedicineInfomations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MedicineIDType,ImportDate,ExpireDate,Quantity,UnitPrice,IsEmpty,Id")] MedicineInfomation medicineInfomation)
        {
            if (id != medicineInfomation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicineInfomation);
                    await _context.SaveChangesAsync();
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
            ViewData["MedicineIDType"] = new SelectList(_context.MedicineTypes, "Id", "Name", medicineInfomation.MedicineIDType);
            return View(medicineInfomation);
        }

        // GET: MedicineInfomations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.MedicineInfomations == null)
            {
                return NotFound();
            }

            var medicineInfomation = await _context.MedicineInfomations
                .Include(m => m.MedicineType)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            if (_context.MedicineInfomations == null)
            {
                return Problem("Entity set 'StoreContext.MedicineInfomations'  is null.");
            }
            var medicineInfomation = await _context.MedicineInfomations.FindAsync(id);
            if (medicineInfomation != null)
            {
                _context.MedicineInfomations.Remove(medicineInfomation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineInfomationExists(Guid id)
        {
            return _context.MedicineInfomations.Any(e => e.Id == id);
        }
    }
}
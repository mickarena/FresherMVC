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
    public class MedicineBillInfoesController : Controller
    {
        private readonly StoreContext _context;

        public MedicineBillInfoesController(StoreContext context)
        {
            _context = context;
        }

        // GET: MedicineBillInfoes
        public async Task<IActionResult> Index()
        {
            var storeContext = _context.MedicineBillInfos.Include(m => m.MedicineBills).Include(c => c.MedicineInfomations);
            return View(await storeContext.ToListAsync());
        }

        // GET: MedicineBillInfoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.MedicineBillInfos == null)
            {
                return NotFound();
            }

            var medicineBillInfo = await _context.MedicineBillInfos
                .Include(m => m.MedicineBills).Include(c => c.MedicineInfomations)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicineBillInfo == null)
            {
                return NotFound();
            }

            return View(medicineBillInfo);
        }

        // GET: MedicineBillInfoes/Create
        public IActionResult Create()
        {
            ViewData["MedicineBillID"] = new SelectList(_context.MedicineBills, "Id", "Id");
            ViewData["IdMedicineInfo"] = new SelectList(_context.MedicineInfomations, "Id", "Name");
            return View();
        }

        // POST: MedicineBillInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicineBillID,IdMedicineInfo,Quantity,UnitPrice,Id")] MedicineBillInfo medicineBillInfo)
        {
            ModelState.Remove("Price");
            if (ModelState.IsValid)
            {
                medicineBillInfo.Id = Guid.NewGuid();
                medicineBillInfo.Price = medicineBillInfo.UnitPrice * medicineBillInfo.Quantity;
                _context.Add(medicineBillInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicineBillID"] = new SelectList(_context.MedicineBills, "Id", "Id", medicineBillInfo.MedicineBillID);
            ViewData["IdMedicineInfo"] = new SelectList(_context.MedicineInfomations, "Id", "Name", medicineBillInfo.IdMedicineInfo);
            return View(medicineBillInfo);
        }

        // GET: MedicineBillInfoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.MedicineBillInfos == null)
            {
                return NotFound();
            }

            var medicineBillInfo = await _context.MedicineBillInfos.FindAsync(id);
            if (medicineBillInfo == null)
            {
                return NotFound();
            }
            ViewData["MedicineBillID"] = new SelectList(_context.MedicineBills, "Id", "Id", medicineBillInfo.MedicineBillID);
            ViewData["IdMedicineInfo"] = new SelectList(_context.MedicineInfomations, "Id", "Name", medicineBillInfo.IdMedicineInfo);
            return View(medicineBillInfo);
        }

        // POST: MedicineBillInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MedicineBillID,IdMedicineInfo,Quantity,UnitPrice,Id")] MedicineBillInfo medicineBillInfo)
        {
            ModelState.Remove("Price");
            if (id != medicineBillInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    medicineBillInfo.Price = medicineBillInfo.UnitPrice * medicineBillInfo.Quantity;
                    _context.Update(medicineBillInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineBillInfoExists(medicineBillInfo.Id))
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
            ViewData["MedicineBillID"] = new SelectList(_context.MedicineBills, "Id", "Id", medicineBillInfo.MedicineBillID);
            ViewData["IdMedicineInfo"] = new SelectList(_context.MedicineInfomations, "Id", "Name", medicineBillInfo.IdMedicineInfo);
            return View(medicineBillInfo);
        }

        // GET: MedicineBillInfoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.MedicineBillInfos == null)
            {
                return NotFound();
            }

            var medicineBillInfo = await _context.MedicineBillInfos
                .Include(m => m.MedicineBills).Include(c => c.MedicineInfomations)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicineBillInfo == null)
            {
                return NotFound();
            }

            return View(medicineBillInfo);
        }

        // POST: MedicineBillInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.MedicineBillInfos == null)
            {
                return Problem("Entity set 'StoreContext.MedicineBillInfos'  is null.");
            }
            var medicineBillInfo = await _context.MedicineBillInfos.FindAsync(id);
            if (medicineBillInfo != null)
            {
                _context.MedicineBillInfos.Remove(medicineBillInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineBillInfoExists(Guid id)
        {
            return _context.MedicineBillInfos.Any(e => e.Id == id);
        }
    }
}
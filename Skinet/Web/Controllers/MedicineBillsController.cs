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
    public class MedicineBillsController : Controller
    {
        private readonly StoreContext _context;

        public MedicineBillsController(StoreContext context)
        {
            _context = context;
        }

        // GET: MedicineBills
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicineBills.ToListAsync());
        }

        // GET: MedicineBills/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.MedicineBills == null)
            {
                return NotFound();
            }

            var medicineBill = await _context.MedicineBills
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicineBill == null)
            {
                return NotFound();
            }

            return View(medicineBill);
        }

        // GET: MedicineBills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicineBills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientID,DoctorID,DateCreate,PayStatus,Id")] MedicineBill medicineBill)
        {
            if (ModelState.IsValid)
            {
                medicineBill.Id = Guid.NewGuid();
                _context.Add(medicineBill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicineBill);
        }

        // GET: MedicineBills/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.MedicineBills == null)
            {
                return NotFound();
            }

            var medicineBill = await _context.MedicineBills.FindAsync(id);
            if (medicineBill == null)
            {
                return NotFound();
            }
            return View(medicineBill);
        }

        // POST: MedicineBills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PatientID,DoctorID,DateCreate,PayStatus,Id")] MedicineBill medicineBill)
        {
            if (id != medicineBill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicineBill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineBillExists(medicineBill.Id))
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
            return View(medicineBill);
        }

        // GET: MedicineBills/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.MedicineBills == null)
            {
                return NotFound();
            }

            var medicineBill = await _context.MedicineBills
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicineBill == null)
            {
                return NotFound();
            }

            return View(medicineBill);
        }

        // POST: MedicineBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.MedicineBills == null)
            {
                return Problem("Entity set 'StoreContext.MedicineBills'  is null.");
            }
            var medicineBill = await _context.MedicineBills.FindAsync(id);
            if (medicineBill != null)
            {
                _context.MedicineBills.Remove(medicineBill);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineBillExists(Guid id)
        {
            return _context.MedicineBills.Any(e => e.Id == id);
        }
    }
}
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class WorkShiftController : Controller
    {
        private readonly IWorkShiftRepository _workShiftRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public WorkShiftController(IWorkShiftRepository workShiftRepository, IWebHostEnvironment webHostEnvironment)
        {
            _workShiftRepository = workShiftRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _workShiftRepository.GetWorkShift();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var workShift = await _workShiftRepository.GetById(id);
            return View(workShift);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var workShift = await _workShiftRepository.GetById(id);
            return View(workShift);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            if (ModelState.IsValid)
            {
                await _workShiftRepository.Delete(id);
                return RedirectToAction("Index");
            }
            return View(id);
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Core.Entities;
//using Infrastructure.Data;

//namespace Web.Controllers
//{
//    public class WorkShiftsController : Controller
//    {
//        private readonly StoreContext _context;

//        public WorkShiftsController(StoreContext context)
//        {
//            _context = context;
//        }

//        // GET: WorkShifts
//        public async Task<IActionResult> Index()
//        {
//            var storeContext = _context.WorkShifts.Include(w => w.Doctor).Include(w => w.Shift);
//            return View(await storeContext.ToListAsync());
//        }

//        // GET: WorkShifts/Details/5
//        public async Task<IActionResult> Details(Guid? id)
//        {
//            if (id == null || _context.WorkShifts == null)
//            {
//                return NotFound();
//            }

//            var workShift = await _context.WorkShifts
//                .Include(w => w.Doctor)
//                .Include(w => w.Shift)
//                .FirstOrDefaultAsync(m => m.IdWork == id);
//            if (workShift == null)
//            {
//                return NotFound();
//            }

//            return View(workShift);
//        }

//        // GET: WorkShifts/Create
//        public IActionResult Create()
//        {
//            ViewData["Id"] = new SelectList(_context.Set<Doctor>(), "Id", "Address");
//            ViewData["IdShift"] = new SelectList(_context.Shifts, "IdShift", "IdShift");
//            return View();
//        }

//        // POST: WorkShifts/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("IdWork,IdShift,Id,Date,Status")] WorkShift workShift)
//        {
//            if (ModelState.IsValid)
//            {
//                workShift.IdWork = Guid.NewGuid();
//                _context.Add(workShift);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["Id"] = new SelectList(_context.Set<Doctor>(), "Id", "Address", workShift.Id);
//            ViewData["IdShift"] = new SelectList(_context.Shifts, "IdShift", "IdShift", workShift.IdShift);
//            return View(workShift);
//        }

//        // GET: WorkShifts/Edit/5
//        public async Task<IActionResult> Edit(Guid? id)
//        {
//            if (id == null || _context.WorkShifts == null)
//            {
//                return NotFound();
//            }

//            var workShift = await _context.WorkShifts.FindAsync(id);
//            if (workShift == null)
//            {
//                return NotFound();
//            }
//            ViewData["Id"] = new SelectList(_context.Set<Doctor>(), "Id", "Address", workShift.Id);
//            ViewData["IdShift"] = new SelectList(_context.Shifts, "IdShift", "IdShift", workShift.IdShift);
//            return View(workShift);
//        }

//        // POST: WorkShifts/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(Guid id, [Bind("IdWork,IdShift,Id,Date,Status")] WorkShift workShift)
//        {
//            if (id != workShift.IdWork)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(workShift);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!WorkShiftExists(workShift.IdWork))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["Id"] = new SelectList(_context.Set<Doctor>(), "Id", "Address", workShift.Id);
//            ViewData["IdShift"] = new SelectList(_context.Shifts, "IdShift", "IdShift", workShift.IdShift);
//            return View(workShift);
//        }

//        // GET: WorkShifts/Delete/5
//        public async Task<IActionResult> Delete(Guid? id)
//        {
//            if (id == null || _context.WorkShifts == null)
//            {
//                return NotFound();
//            }

//            var workShift = await _context.WorkShifts
//                .Include(w => w.Doctor)
//                .Include(w => w.Shift)
//                .FirstOrDefaultAsync(m => m.IdWork == id);
//            if (workShift == null)
//            {
//                return NotFound();
//            }

//            return View(workShift);
//        }

//        // POST: WorkShifts/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(Guid id)
//        {
//            if (_context.WorkShifts == null)
//            {
//                return Problem("Entity set 'StoreContext.WorkShifts'  is null.");
//            }
//            var workShift = await _context.WorkShifts.FindAsync(id);
//            if (workShift != null)
//            {
//                _context.WorkShifts.Remove(workShift);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool WorkShiftExists(Guid id)
//        {
//          return _context.WorkShifts.Any(e => e.IdWork == id);
//        }
//    }
//}
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Infrastructure.Data;

namespace Web.Controllers
{
    public class WorkShiftController : Controller
    {
        private readonly IWorkShiftRepository _workShiftRepository;
        private readonly IShiftRepository _shiftRepository;
        private readonly StoreContext _context;
        public WorkShiftController(IWorkShiftRepository workShiftRepository, IShiftRepository shiftRepository, IDoctorRepository doctorRepository, StoreContext context)
        {
            _workShiftRepository = workShiftRepository;
            _shiftRepository = shiftRepository;
            _context = context;
        }

        // GET/Index
        public async Task<IActionResult> Index()
        {
            var model = await _workShiftRepository.GetWorkShift();
            var storeContext = _workShiftRepository.GetType();
            ViewData["IdShift"] = new SelectList(_shiftRepository.GetType(), "Id", "ShiftName");
            return View(model);
        }

        // GET/Create
        public IActionResult Create()
        {
            ViewData["IdShift"] = new SelectList(_shiftRepository.GetType(), "Id", "ShiftName");
            return View();
        }

        // POST/Create
        [HttpPost]
        public async Task<IActionResult> Create(WorkShift workShift)
        {
            if (ModelState.IsValid)
            {
                await _workShiftRepository.Create(workShift);
                return RedirectToAction("Index");
            }
            ViewData["IdShift"] = new SelectList(_shiftRepository.GetType(), "Id", "ShiftName", workShift.Id);
            return View(workShift);
        }

        // GET/Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var workShift = await _workShiftRepository.GetById(id);
            ViewData["IdShift"] = new SelectList(_shiftRepository.GetType(), "Id", "ShiftName");
            return View(workShift);
        }

        // POST/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(WorkShift workShift)
        {
            if (ModelState.IsValid)
            {
                await _workShiftRepository.Edit(workShift);
                return RedirectToAction("Index");
            }
            ViewData["IdShift"] = new SelectList(_shiftRepository.GetType(), "Id", "ShiftName", workShift.Id);
            return View(workShift);
        }

        // GET/Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            ViewData["IdShift"] = new SelectList(_shiftRepository.GetType(), "Id", "ShiftName");
            var workShift = await _workShiftRepository.GetById(id);
            return View(workShift);
        }

        // POST/Delete
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
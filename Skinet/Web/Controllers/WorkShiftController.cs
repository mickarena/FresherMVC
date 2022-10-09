using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    public class WorkShiftController : Controller
    {
        private readonly IWorkShiftRepository _workShiftRepository;
        private readonly IShiftRepository _shiftRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly StoreContext _context;
        public WorkShiftController(IWorkShiftRepository workShiftRepository, IShiftRepository shiftRepository, IDoctorRepository doctorRepository, StoreContext context)
        {
            _workShiftRepository = workShiftRepository;
            _shiftRepository = shiftRepository;
            _doctorRepository = doctorRepository;
            _context = context;
        }

        //public async Task<ActionResult> About()
        //{
        //    IQueryable<WorkAbout> data =
        //        from student in _context.Students
        //        group student by student.EnrollmentDate into dateGroup
        //        select new EnrollmentDateGroup()
        //        {
        //            EnrollmentDate = dateGroup.Key,
        //            StudentCount = dateGroup.Count()
        //        };
        //    return View(await data.AsNoTracking().ToListAsync());
        //}

        // GET/Index
        public async Task<IActionResult> Index()
        {
            var model = await _workShiftRepository.GetWorkShift();
            var storeContext = _workShiftRepository.GetType();
            ViewData["IdShift"] = new SelectList(_shiftRepository.GetType(), "Id", "ShiftName");
            ViewData["IdDoctor"] = new SelectList(_doctorRepository.GetType(), "Id", "Name");
            return View(model);
        }

        // GET/Create
        public IActionResult Create()
        {
            ViewData["IdShift"] = new SelectList(_shiftRepository.GetType(), "Id", "ShiftName");
            ViewData["IdDoctor"] = new SelectList(_doctorRepository.GetType(), "Id", "Name");
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
            ViewData["IdDoctor"] = new SelectList(_doctorRepository.GetType(), "Id", "Name", workShift.Id);
            return View(workShift);
        }

        // GET/Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var workShift = await _workShiftRepository.GetById(id);
            ViewData["IdShift"] = new SelectList(_shiftRepository.GetType(), "Id", "ShiftName");
            ViewData["IdDoctor"] = new SelectList(_doctorRepository.GetType(), "Id", "Name");
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
            ViewData["IdDoctor"] = new SelectList(_doctorRepository.GetType(), "Id", "Name", workShift.Id);
            return View(workShift);
        }

        // GET/Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            ViewData["IdShift"] = new SelectList(_shiftRepository.GetType(), "Id", "ShiftName");
            ViewData["IdDoctor"] = new SelectList(_doctorRepository.GetType(), "Id", "Name");
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
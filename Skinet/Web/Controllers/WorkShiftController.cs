using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

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

        // View Create
        public IActionResult Create()
        {
            return View();
        }

        // Post Create
        [HttpPost]
        public async Task<IActionResult> Create(WorkShift workShift)
        {
            if (!ModelState.IsValid)
            {
                await _workShiftRepository.Create(workShift);
                return RedirectToAction("Index");
            }
            return View(workShift);
        }

        // View Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var workShift = await _workShiftRepository.GetById(id);
            return View(workShift);
        }

        // Post Edit
        [HttpPost]
        public async Task<IActionResult> Update(WorkShift workShift)
        {
            if (!ModelState.IsValid)
            {
                await _workShiftRepository.Update(workShift);
                return RedirectToAction("Index");
            }
            return View(workShift);
        }

        // View Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            var workShift = await _workShiftRepository.GetById(id);
            return View(workShift);
        }

        // Post Delete
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
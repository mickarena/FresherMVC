﻿using Core.Entities;
using Core.Interfaces;
using Core.Pagination;
using Microsoft.AspNetCore.Mvc;
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

        // GET/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST/Create
        [HttpPost]
        public async Task<IActionResult> Create(Shift shift)
        {
            if (ModelState.IsValid)
            {
                await _shiftRepository.Create(shift);
                return RedirectToAction("Index");
            }
            return View(shift);
        }

        // GET/Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var shift = await _shiftRepository.GetById(id);
            return View(shift);
        }

        // POST/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Shift shift)
        {
            if (ModelState.IsValid)
            {
                await _shiftRepository.Edit(shift);
                return RedirectToAction("Index");
            }
            return View(shift);
        }

        // GET/Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            var shift = await _shiftRepository.GetById(id);
            return View(shift);
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
    }
}
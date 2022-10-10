﻿using System;
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
    public class MedicineBillsController : Controller
    {
        private IMedBillRepository _billRepository;

        public MedicineBillsController(IMedBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        // GET: MedicineBills
        public async Task<IActionResult> Index()
        {
            return View(_billRepository.GetType());
        }

        // GET: MedicineBills/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var medicineBill = _billRepository.GetById(id).Result;
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
        public async Task<IActionResult> Create(MedicineBill medicineBill)
        {
            if (ModelState.IsValid)
            {
                medicineBill.Id = Guid.NewGuid();
                _billRepository.Create(medicineBill);
                return RedirectToAction(nameof(Index));
            }
            return View(medicineBill);
        }

        // GET: MedicineBills/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var medicineBill = _billRepository.GetById(id).Result;
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
        public async Task<IActionResult> Edit(Guid id, MedicineBill medicineBill)
        {
            if (id != medicineBill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _billRepository.Update(medicineBill);
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
        public async Task<IActionResult> Delete(Guid id)
        {
            var medicineBill = _billRepository.GetById(id).Result;
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
            if (_billRepository.GetById(id) == null)
            {
                return Problem("Entity set 'StoreContext.MedicineBills'  is null.");
            }
            var medicineBill = _billRepository.GetById(id);
            if (medicineBill != null)
            {
                _billRepository.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MedicineBillExists(Guid id)
        {
            return _billRepository.GetById(id).IsCompletedSuccessfully;
        }
    }
}
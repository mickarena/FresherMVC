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
using Core.Pagination;

namespace Web.Controllers
{
    public class MedicineBillInfoesController : Controller
    {
        public MedicineBillInfoesController(IMedBillRepository medicineBill, IMedBillInfoRepository medicineBillInfo, IMedicineInfoRepository medicineInfo, IPagedRepository<MedicineBillInfo> pagedRepository)
        {
            _MedicineBill = medicineBill;
            _MedicineBillInfo = medicineBillInfo;
            _MedicineInfo = medicineInfo;
            this.pagedRepository = pagedRepository;
        }

        private IMedBillRepository _MedicineBill { get; set; }
        private IMedBillInfoRepository _MedicineBillInfo { get; set; }
        private IMedicineInfoRepository _MedicineInfo { get; set; }
        private IPagedRepository<MedicineBillInfo> pagedRepository;

        // GET: MedicineBillInfoes
        public async Task<IActionResult> Index(int currentPage, Guid searchString)
        {
            var list = _MedicineBillInfo.GetType();
            if (searchString != Guid.Empty)
            {
                list = list.Where(c => c.MedicineBillID == searchString).ToList();
            }
            var dto = pagedRepository.PaginatedList(list, currentPage);
            ViewBag.TotalPage = dto.TotalPages;
            ViewBag.CurrentPage = dto.PageIndex;
            return View(dto.Items);
        }

        // GET: MedicineBillInfoes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var medicineBillInfo = _MedicineBillInfo.GetById(id).Result;
            if (medicineBillInfo == null)
            {
                return NotFound();
            }

            return View(medicineBillInfo);
        }

        // GET: MedicineBillInfoes/Create
        public IActionResult Create()
        {
            ViewData["MedicineBillID"] = new SelectList(_MedicineBill.GetType(), "Id", "Id");
            ViewData["IdMedicineInfo"] = new SelectList(_MedicineInfo.GetType(), "Id", "Name");
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
                _MedicineBillInfo.Create(medicineBillInfo);
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicineBillID"] = new SelectList(_MedicineBill.GetType(), "Id", "Id", medicineBillInfo.MedicineBillID);
            ViewData["IdMedicineInfo"] = new SelectList(_MedicineInfo.GetType(), "Id", "Name", medicineBillInfo.IdMedicineInfo);
            return View(medicineBillInfo);
        }

        // GET: MedicineBillInfoes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var medicineBillInfo = _MedicineBillInfo.GetById(id).Result;
            if (medicineBillInfo == null)
            {
                return NotFound();
            }
            ViewData["MedicineBillID"] = new SelectList(_MedicineBill.GetType(), "Id", "Id");
            ViewData["IdMedicineInfo"] = new SelectList(_MedicineInfo.GetType(), "Id", "Name");
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
                    _MedicineBillInfo.Update(medicineBillInfo);
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
            ViewData["MedicineBillID"] = new SelectList(_MedicineBill.GetType(), "Id", "Id", medicineBillInfo.MedicineBillID);
            ViewData["IdMedicineInfo"] = new SelectList(_MedicineInfo.GetType(), "Id", "Name", medicineBillInfo.IdMedicineInfo);
            return View(medicineBillInfo);
        }

        // GET: MedicineBillInfoes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var medicineBillInfo = _MedicineBillInfo.GetById(id).Result;
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
            if (_MedicineBillInfo.GetType() == null)
            {
                return Problem("Entity set 'StoreContext.MedicineBillInfos'  is null.");
            }
            var medicineBillInfo = _MedicineBillInfo.GetById(id).Result;
            if (medicineBillInfo != null)
            {
                _MedicineBillInfo.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineBillInfoExists(Guid id)
        {
            return _MedicineBillInfo.GetById(id).IsCompletedSuccessfully;
        }
    }
}
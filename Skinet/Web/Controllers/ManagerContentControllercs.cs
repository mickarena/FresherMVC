using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System;

namespace Web.Controllers
{
    public class ManagerContentControllercs : Controller
    {
        //
        // GET: /Admin/ManageApplicantsConsent/
        private readonly IConsentService _consentSvc;
        private readonly IProcessFlowConfigurationService _processFlowConfigurationSvc;
        public ManageApplicantsConsentController(IConsentService consentSvc, IProcessFlowConfigurationService processFlowConfigurationSvc)
        {
            this._consentSvc = consentSvc;
            this._processFlowConfigurationSvc = processFlowConfigurationSvc;
        }

        public ActionResult Index()
        {
            var listCategory = new List<SelectListItem>
                                         {
                                            new SelectListItem(){ Text = Constants.Category.General  ,Value =  Constants.Category.General},
                                            new SelectListItem(){ Text = Constants.Category.Religion  ,Value =  Constants.Category.Religion},
                                            new SelectListItem(){ Text = Constants.Category.Health  ,Value =  Constants.Category.Health}
                                         };


            var listApplicationYear = _processFlowConfigurationSvc.List().Select(p => new
            {
                Text = p.ApplicationYear,
                Value = p.Id
            });

            ViewBag.listCategory = listCategory.ToList();
            ViewBag.listApplicationYear = listApplicationYear.Distinct().OrderByDescending(p => p.Text).ToList();

            return View();
        }

        public JsonResult GetConsentById(int id)
        {
            var item = _consentSvc.Details(id);
            if (item == null || item.StatusId == Constants.CoreGlobal.ObjectStatusInactive)
            {
                var result = new { Status = "Error", Msg = string.Format(Constants.Messages.MSG91, "Consent") };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            var checkIsActive = item.ApplicationConsents.Any(p => p.StatusId == Constants.CoreGlobal.ObjectStatusActive);
            return Json(new
            {
                Status = "OK",
                d = new
                {
                    Id = item.Id,
                    ProcessFlowConfigurationId = item.ProcessFlowConfigurationId,
                    Name = item.Name,
                    Category = item.Category,
                    CheckIsActive = checkIsActive
                }
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Insert(int processFlowConfigurationId, string name, string category)
        {
            object result = null;
            name = name.Trim();
            category = category.Trim();
            var dublicateConsent = _consentSvc.List().Any(p => p.Name.ToLower() == name.ToLower() && (p.ProcessFlowConfigurationId == processFlowConfigurationId));
            if (dublicateConsent)
            {
                result = new { Status = "Error", Msg = Constants.Messages.MSG125 };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            var dublicateReligionCategory = _consentSvc.List().Any(p => p.ProcessFlowConfigurationId == processFlowConfigurationId && (category == Constants.Category.Religion) && p.Category == category);
            if (dublicateReligionCategory)
            {
                result = new { Status = "Error", Msg = Constants.Messages.MSG122 };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            var dublicateReligionHealth = _consentSvc.List().Any(p => p.ProcessFlowConfigurationId == processFlowConfigurationId && (category == Constants.Category.Health) && p.Category == category);
            if (dublicateReligionHealth)
            {
                result = new { Status = "Error", Msg = Constants.Messages.MSG123 };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            var item = new Consent()
            {
                ProcessFlowConfigurationId = processFlowConfigurationId,
                Name = name,
                Category = category,
                StatusId = Constants.CoreGlobal.ObjectStatusActive,
                InsAt = DateTime.Now,
                InsBy = HttpContext.User.Identity.Name,
                UpdAt = DateTime.Now,
                UpdBy = HttpContext.User.Identity.Name
            };
            _consentSvc.Insert(item);
            result = new { Status = "OK", Msg = "" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Update(int id, int processFlowConfigurationId, string name, string category)
        {
            object result = null;
            name = name.Trim();
            category = category.Trim();
            var dublicateConsent = _consentSvc.List().Any(p => p.Name.ToLower() == name.ToLower() && (p.ProcessFlowConfigurationId == processFlowConfigurationId) && p.Id != id);
            if (dublicateConsent)
            {
                result = new { Status = "Error", Msg = Constants.Messages.MSG125 };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            var dublicateReligionCategory = _consentSvc.List().Any(p => p.ProcessFlowConfigurationId == processFlowConfigurationId && (category == Constants.Category.Religion) && p.Category == category && p.Id != id);
            if (dublicateReligionCategory)
            {
                result = new { Status = "Error", Msg = Constants.Messages.MSG122 };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            var dublicateReligionHealth = _consentSvc.List().Any(p => p.ProcessFlowConfigurationId == processFlowConfigurationId && (category == Constants.Category.Health) && p.Category == category && p.Id != id);
            if (dublicateReligionHealth)
            {
                result = new { Status = "Error", Msg = Constants.Messages.MSG123 };
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            var item = _consentSvc.Details(id);
            if (item == null || item.StatusId == Constants.CoreGlobal.ObjectStatusInactive)
            {
                result = new { Status = "Error", Msg = string.Format(Constants.Messages.MSG91, "Consent") };
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            item.ProcessFlowConfigurationId = processFlowConfigurationId;
            item.Name = name;
            item.Category = category;
            item.UpdAt = DateTime.Now;
            item.UpdBy = HttpContext.User.Identity.Name;
            _consentSvc.Update(item);
            result = new { Status = "OK", Msg = "" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Delete(int id)
        {
            object result;
            var item = _consentSvc.Details(id);
            if (item == null || item.StatusId == Constants.CoreGlobal.ObjectStatusInactive)
            {
                result = new { Status = "Error", Msg = string.Format(Constants.Messages.MSG91, "Consent") };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (item.ApplicationConsents.Any(t => string.Equals(t.StatusId, Constants.CoreGlobal.ObjectStatusActive)))
            {
                result = new { Status = "Error", Msg = Constants.Messages.MSG97 };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            item.StatusId = Constants.CoreGlobal.ObjectStatusInactive;
            item.UpdAt = DateTime.Now;
            item.UpdBy = HttpContext.User.Identity.Name;
            _consentSvc.Update(item);
            result = new { Status = "OK", Msg = "" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SearchConsent(int rows, int page, string sidx, string sord)
        {
            var listConsent = _consentSvc.List();
            switch (sidx)
            {
                case "ApplicationYear":
                    listConsent = sord == "asc"
                                             ? listConsent.OrderBy(p => p.ProcessFlowConfiguration.ApplicationYear)
                                             : listConsent.OrderByDescending(p => p.ProcessFlowConfiguration.ApplicationYear);
                    break;
                case "Name":
                    listConsent = sord == "asc"
                                             ? listConsent.OrderBy(p => p.Name)
                                             : listConsent.OrderByDescending(p => p.Name);
                    break;
                case "Category":
                    listConsent = sord == "asc"
                                             ? listConsent.OrderBy(p => p.Category)
                                             : listConsent.OrderByDescending(p => p.Category);
                    break;
                default:
                    break;
            }
            var pagedConsent = listConsent.Skip((page - 1) * rows).Take(rows);
            var searchResult = new
            {
                rows = pagedConsent.Select(p => new
                {
                    Id = p.Id,
                    CheckDependency = p.ApplicationConsents.Any(a => a.StatusId == Constants.CoreGlobal.ObjectStatusActive),
                    ApplicationYear = p.ProcessFlowConfiguration.ApplicationYear,
                    Name = p.Name,
                    Category = p.Category,
                    Action = string.Empty
                }),
                Page = page,
                total = (int)Math.Ceiling((double)listConsent.Count() / rows),
                records = listConsent.Count()
            };
            return Json(searchResult, JsonRequestBehavior.AllowGet);
        }
    }
}

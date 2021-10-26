using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineSearchWebApp.Models;

namespace MedicineSearchWebApp.Controllers
{
    public class MedecineController : Controller
    {
        // GET: MedecineController
        public ActionResult Index(string sort)
        {
            MedicineSearchContext context = new MedicineSearchContext();
            ViewBag.CatSortParam = string.IsNullOrEmpty(sort) ? "CATEGORY" : "";
            ViewBag.MDATESortParam = sort == "MANUFACTURING DATE" ? "DESCM" : "MANUFACTURING DATE";
            ViewBag.EDATESortParam = sort == "EXPIRY DATE" ? "DESCE" : "EXPIRY DATE";
            ViewBag.StockSortParam = sort == "STOCK" ? "DESCS" : "STOCK";
            ViewBag.PriceSortParam = sort == "PRICE" ? "DESCP" : "PRICE";
            var med = from i in context.Medecines.ToList() select i;
            switch (sort)
            {
                case "CATEGORY":
                    med = med.OrderByDescending(i => i.MedicineCategory);
                    break;
                case "MANUFACTURING DATE":
                    med = med.OrderBy(i => i.MedicineMdate);
                    break;
                case "DESCM":
                    med = med.OrderByDescending(i => i.MedicineMdate);
                    break;
                case "EXPIRY DATE":
                    med = med.OrderBy(i => i.MedicineEdate);
                    break;
                case "DESCE":
                    med = med.OrderByDescending(i => i.MedicineEdate);
                    break;
                case "STOCK":
                    med = med.OrderBy(i => i.MedicineStock);
                    break;
                case "DESCS":
                    med = med.OrderByDescending(i => i.MedicineStock);
                    break;
                case "PRICE":
                    med = med.OrderBy(i => i.MedicinePrice);
                    break;
                case "DESCP":
                    med = med.OrderByDescending(i => i.MedicinePrice);
                    break;
                default:
                    med = med.OrderBy(i => i.MedicineCategory);
                    break;
            }
            return View(med.ToList());
        }
        public IActionResult byName()
        {

            MedecineADO meds = new MedecineADO();
            meds.medicineList = meds.getAllMedicine();
            return View(meds);
        }
        public IActionResult byCategory()
        {

            MedecineADO meds = new MedecineADO();
            meds.medicineList = meds.getAllMedicineCategory();
            return View(meds);
        }
        public IActionResult medsByName(int d)
        {

            MedecineADO meds = new MedecineADO();
            List<MedecineADO> m = meds.getAllMedicineByName(d);
            return PartialView(m);
        }
        public IActionResult medByCategory(string category)
        {

            MedecineADO meds = new MedecineADO();
            List<MedecineADO> m = meds.getAllMedicineByCategory(category);
            return PartialView(m);
        }

        // GET: MedecineController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedecineController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedecineController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MedecineController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedecineController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MedecineController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedecineController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

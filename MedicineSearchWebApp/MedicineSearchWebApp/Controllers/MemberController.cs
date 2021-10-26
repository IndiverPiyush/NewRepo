using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineSearchWebApp.Models;

namespace MedicineSearchWebApp.Controllers
{
    public class MemberController : Controller
    {
        public ActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMember(IFormCollection collection)
        {
            try
            {
                MedicineSearchContext cnt = new MedicineSearchContext();
                Medecine md = new Medecine();
                md.ProviderId = int.Parse(collection["ProviderId"].ToString());
                md.MedicineName = collection["MedicineName"].ToString();
                md.MedicineCategory = collection["MedicineCategory"].ToString();
                md.MedicineDosage = int.Parse(collection["MedicineDosage"].ToString());
                md.MedicineMdate = DateTime.Parse(collection["MedicineMdate"].ToString());
                md.MedicineEdate = DateTime.Parse(collection["MedicineEdate"].ToString());
                md.MedicineStock = int.Parse(collection["MedicineStock"].ToString());
                md.MedicinePrice = decimal.Parse(collection["MedicinePrice"].ToString());
                cnt.Medecines.Add(md);
                cnt.SaveChanges();
                return RedirectToAction(nameof(display));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult display(string sort)
        {
            MedicineSearchContext cnt = new MedicineSearchContext();
            Medecine md = new Medecine();
            ViewBag.CatSortParam = string.IsNullOrEmpty(sort) ? "CATEGORY" : "";
            ViewBag.NameSortParam = sort == "NAME" ? "DESN" : "NAME";
            ViewBag.MDATESortParam = sort == "MANUFACTURING DATE" ? "DESCM" : "MANUFACTURING DATE";
            ViewBag.EDATESortParam = sort == "EXPIRY DATE" ? "DESCE" : "EXPIRY DATE";
            ViewBag.StockSortParam = sort == "STOCK" ? "DESCS" : "STOCK";
            ViewBag.PriceSortParam = sort == "PRICE" ? "DESCP" : "PRICE";

            var med = from i in cnt.Medecines where i.ProviderId == 5002 select i;
            switch (sort)
            {
                case "NAME":
                    med = med.OrderBy(i => i.MedicineName);
                    break;
                case "DESCN":
                    med = med.OrderByDescending(i => i.MedicineName);
                    break;
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
        public ActionResult Edit(int id)
        {
            MedicineSearchContext cnt = new MedicineSearchContext();
            Medecine md = new Medecine();
            var med = (from i in cnt.Medecines where i.MedicineId == id select i).FirstOrDefault();
            if(med != null)
            {
                md.MedicineDosage = med.MedicineDosage;
                md.MedicineMdate = med.MedicineMdate;
                md.MedicineEdate = med.MedicineEdate;
                md.MedicineStock = med.MedicineStock;
                md.MedicinePrice = med.MedicinePrice;
            }
            return View(md);
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                MedicineSearchContext cnt = new MedicineSearchContext();
                var md = (from i in cnt.Medecines where i.MedicineId == id select i).FirstOrDefault();
               if(md != null)
                {
                    md.MedicineDosage = int.Parse(collection["MedicineDosage"].ToString());
                    md.MedicineMdate = DateTime.Parse(collection["MedicineMdate"].ToString());
                    md.MedicineEdate = DateTime.Parse(collection["MedicineEdate"].ToString());
                    md.MedicineStock = int.Parse(collection["MedicineStock"].ToString());
                    md.MedicinePrice = decimal.Parse(collection["MedicinePrice"].ToString());
                }
                cnt.SaveChanges();
                return RedirectToAction(nameof(display));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            MedicineSearchContext cnt = new MedicineSearchContext();
            Medecine md = new Medecine();
            var med = (from i in cnt.Medecines where i.MedicineId == id select i).FirstOrDefault();
            if(med != null)
            {
                md.MedicineName = med.MedicineName;
                md.MedicineCategory = med.MedicineCategory;
                md.MedicineDosage = med.MedicineDosage;
                md.MedicineMdate = med.MedicineMdate;
                md.MedicineEdate = med.MedicineEdate;
                md.MedicineStock = med.MedicineStock;
                md.MedicinePrice = med.MedicinePrice;
                md.ProviderId = med.ProviderId;
            }
            return View(md);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                MedicineSearchContext cnt = new MedicineSearchContext();
                var md = (from i in cnt.Medecines where i.MedicineId == id select i).FirstOrDefault();
                cnt.Medecines.Remove(md);
                cnt.SaveChanges();
                return RedirectToAction(nameof(display));
            }
            catch
            {
                return View();
            }
        }
    }
}

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

        public ActionResult display()
        {
            MedicineSearchContext cnt = new MedicineSearchContext();
            Medecine md = new Medecine();
            var medicine = from i in cnt.Medecines where i.ProviderId == 5002 select i;
            if (medicine != null)
            {
                return View(medicine.ToList());
            }
            else
            {
                return View();
            }
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

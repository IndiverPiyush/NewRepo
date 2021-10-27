using MedicineSearchWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineSearchWebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        public ActionResult AdminLogin()
        {
            return View();
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        public IActionResult Index()
        {
            //MedicineSearchContext context = new MedicineSearchContext();
            return View();

        }

        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            
                    MedicineSearchContext cnt = new MedicineSearchContext();
            if (collection["AdminUser"] == "Admin" && collection["AdminPassword"].ToString() == "Admin")
            {
                return RedirectToAction(nameof(AdminHomePage));
            }
            else
            {
                return RedirectToAction(nameof(AdminHomePage));
            }
            
               

        }

        public IActionResult AdminHomePage()
        {
            //MedicineSearchContext context = new MedicineSearchContext();
            return View();

        }
        public ActionResult Display()
        {
            MedicineSearchContext context = new MedicineSearchContext();
            return View(context.Vendors.ToList());
        }
        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                MedicineSearchContext msc = new MedicineSearchContext();
                Vendor mem = new Vendor();
                mem.VendorOrgName = collection["VendorOrgName"].ToString();
                mem.VendorArea = collection["VendorArea"].ToString();
                mem.VendorCity = collection["VendorCity"].ToString();
                mem.VendorMobile = collection["VendorMobile"].ToString();
                mem.VendorWallet = int.Parse(collection["VendorWallet"].ToString());
                mem.VendorPassword = collection["VendorPassword"].ToString();
                mem.VendorSpeciality = collection["VendorSpeciality"].ToString();
                msc.Vendors.Add(mem);
                msc.SaveChanges();
                return RedirectToAction(nameof(Display));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            MedicineSearchContext msc = new MedicineSearchContext();
            Vendor mem = new Vendor();
            var vid = (from i in msc.Vendors where i.VendorId == id select i).FirstOrDefault();
            if (vid != null)
            {
                mem.VendorOrgName = vid.VendorOrgName;
                mem.VendorArea = vid.VendorArea;
                mem.VendorCity = vid.VendorCity;
                mem.VendorMobile = vid.VendorMobile;
                mem.VendorWallet = vid.VendorWallet;
                mem.VendorPassword = vid.VendorPassword;
                mem.VendorSpeciality = vid.VendorSpeciality;
            }
            return View(mem);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                MedicineSearchContext msc = new MedicineSearchContext();
                Vendor mem = new Vendor();
                var vid = (from i in msc.Vendors where i.VendorId == id select i).FirstOrDefault();
                if (vid != null)
                {
                    mem.VendorOrgName = collection["VendorOrgName"].ToString();
                    mem.VendorArea = collection["VendorArea"].ToString();
                    mem.VendorCity = collection["VendorCity"].ToString();
                    mem.VendorMobile = collection["VendorMobile"].ToString();
                    mem.VendorWallet = int.Parse(collection["VendorWallet"].ToString());
                    mem.VendorPassword = collection["VendorPassword"].ToString();
                    mem.VendorSpeciality = collection["VendorSpeciality"].ToString();
                }
                msc.SaveChanges();
                return RedirectToAction(nameof(Display));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            MedicineSearchContext msc = new MedicineSearchContext();
            Vendor mem = new Vendor();
            var vid = (from i in msc.Vendors where i.VendorId == id select i).FirstOrDefault();
            if (vid != null)
            {
                mem.VendorOrgName = vid.VendorOrgName;
                mem.VendorArea = vid.VendorArea;
                mem.VendorCity = vid.VendorCity;
                mem.VendorMobile = vid.VendorMobile;
                mem.VendorWallet = vid.VendorWallet;
                mem.VendorPassword = vid.VendorPassword;
                mem.VendorSpeciality = vid.VendorSpeciality;
            }
            return View(mem);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                MedicineSearchContext msc = new MedicineSearchContext();
                Vendor mem = new Vendor();
                var vid = (from i in msc.Vendors where i.VendorId == id select i).FirstOrDefault();
                msc.Vendors.Remove(vid);
                msc.SaveChanges();
                return RedirectToAction(nameof(Display));
            }
            catch
            { 
                return View();
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineSearchWebApp.Models;

namespace MedicineSearchWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: RegistrationController
        public ActionResult Index()

        {
            MedicineSearchContext cnt = new MedicineSearchContext();

            return View(cnt.Customers.ToList());
        }

        // GET: RegistrationController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: RegistrationController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: RegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                MedicineSearchContext cnt = new MedicineSearchContext();
                Customer cs = new Customer();
                cs.UserName = collection["UserName"].ToString();
                cs.UserMobile = collection["UserMobile"].ToString();
                cs.UserEmail = collection["UserEmail"].ToString();
                cs.UserArea = collection["UserArea"].ToString();
                cs.UserCity = collection["UserCity"].ToString();
                cs.UserWalletbal = int.Parse(collection["UserWalletbal"].ToString());
                cs.UserPassword = collection["UserPassword"].ToString();
                cs.AllergicTo = collection["AllergicTo"].ToString(); ;
                cnt.Customers.Add(cs);
                cnt.SaveChanges();
                //Response.Redirect("/Home/Index");
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistrationController/Edit/5
        public ActionResult Edit(/*int id*/)
        {
            MedicineSearchContext cnt = new MedicineSearchContext();
            Customer cs = new Customer();
            int uid = (int)HttpContext.Session.GetInt32("userid");

            var csdet = (from i in cnt.Customers where i.UserId == uid select i).FirstOrDefault();
            if (csdet != null)
            {
                cs.UserWalletbal = csdet.UserWalletbal;
                
            }
            return View(cs);
        }

        // POST: RegistrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*int id,*/ IFormCollection collection)
        {
            try
            {
                MedicineSearchContext cnt = new MedicineSearchContext();
                Customer dt = new Customer();
                int uid = (int)HttpContext.Session.GetInt32("userid");

                var csdet = (from i in cnt.Customers where i.UserId == uid select i).FirstOrDefault();
                if (csdet != null)
                {
                    csdet.UserWalletbal = csdet.UserWalletbal+decimal.Parse(collection["UserWalletbal"].ToString());
                    
                    cnt.SaveChanges();
                }
                return RedirectToAction(nameof(Edit));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrationController/Delete/5
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

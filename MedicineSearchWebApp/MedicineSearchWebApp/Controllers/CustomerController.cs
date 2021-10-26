using MedicineSearchWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineSearchWebApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerController
        public ActionResult Index()
        {
            MedicineSearchContext context = new MedicineSearchContext();
            return View(context.Customers.ToList());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            MedicineSearchContext cnt = new MedicineSearchContext();
            Customer ct = new Customer();
            var ctdet = (from i in cnt.Customers where i.UserId == id select i).FirstOrDefault();
            if(ctdet != null)
            {
                ct.UserId = ctdet.UserId;
                ct.UserName = ctdet.UserName;
                ct.UserMobile = ctdet.UserMobile;
                ct.UserEmail = ctdet.UserEmail;
                ct.UserArea = ctdet.UserArea;
                ct.UserCity = ctdet.UserCity;
                ct.UserWalletbal = ctdet.UserWalletbal;
                ct.AllergicTo = ctdet.AllergicTo;
            }
            return View(ct);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
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

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            MedicineSearchContext cnt = new MedicineSearchContext();
            Customer ct = new Customer();
            var ctdet = (from i in cnt.Customers where i.UserId == id select i).FirstOrDefault();
            if (ctdet != null)
            {
                ct.UserId = ctdet.UserId;
                ct.UserName = ctdet.UserName;
                ct.UserMobile = ctdet.UserMobile;
                ct.UserEmail = ctdet.UserEmail;
                ct.UserArea = ctdet.UserArea;
                ct.UserCity = ctdet.UserCity;
                ct.UserWalletbal = ctdet.UserWalletbal;
                ct.AllergicTo = ctdet.AllergicTo;
            }
            return View(ct);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                MedicineSearchContext cnt = new MedicineSearchContext();
                var ctdet = (from i in cnt.Customers where i.UserId == id select i).FirstOrDefault();
                if (ctdet != null)
                {
                    ctdet.UserId= int.Parse(collection["UserId"].ToString());
                    ctdet.UserName = collection["UserName"].ToString();
                    ctdet.UserMobile = collection["UserMobile"].ToString();
                    ctdet.UserEmail = collection["UserEmail"].ToString();
                    ctdet.UserArea = collection["UserArea"].ToString();
                    ctdet.UserCity = collection["UserCity"].ToString();
                    ctdet.UserWalletbal = decimal.Parse(collection["UserWalletbal"].ToString());
                    ctdet.AllergicTo = collection["AllergicTo"].ToString();
                    cnt.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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

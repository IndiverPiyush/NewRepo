using MedicineSearchWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MedicineSearchWebApp.Models;
using Microsoft.AspNetCore.Http;

namespace MedicineSearchWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //MedicineSearchContext context = new MedicineSearchContext();
            return View();
            
        }

        [HttpPost]
        public IActionResult Index(IFormCollection collection, string submit)
        {
            Console.WriteLine(collection["UserMobile"].ToString());
            switch (submit) {
                case "Index":
                    MedicineSearchContext cnt = new MedicineSearchContext();
                    Customer dt = new Customer();
                    var depdet = (from i in cnt.Customers select i).FirstOrDefault();
                    if (collection["UserMobile"].ToString() == depdet.UserMobile && collection["UserPassword"].ToString() == depdet.UserPassword)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return RedirectToAction(nameof(Details));
                    }
                case "Index1":
                    MedicineSearchContext cnt1 = new MedicineSearchContext();
                    Vendor vt = new Vendor();
                    var vdepdet = (from i in cnt1.Vendors select i).FirstOrDefault();
                    if (collection["UserMobile"].ToString() == vdepdet.VendorMobile && collection["UserPassword"].ToString() == vdepdet.VendorPassword)
                    {
                        return RedirectToAction(nameof(VendorHomePage));
                    }
                    else
                    {
                        return RedirectToAction(nameof(Details2));
                    }
                }
            return View();

        }


        public IActionResult Details()
        {
            //MedicineSearchContext context = new MedicineSearchContext();
            return View();

        }

        public IActionResult Details2()
        {
            //MedicineSearchContext context = new MedicineSearchContext();
            return View();

        }

        public IActionResult VendorHomePage()
        {
            //MedicineSearchContext context = new MedicineSearchContext();
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult viewCustomers()
        {
            MedicineSearchContext context = new MedicineSearchContext();
            return View(context.Customers.ToList());

        }
    }
}

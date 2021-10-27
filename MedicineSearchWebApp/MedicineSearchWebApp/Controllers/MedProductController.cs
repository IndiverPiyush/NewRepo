using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineSearchWebApp.Models;
using MedicineSearchWebApp.Repository;


namespace MedicineSearchWebApp.Controllers
{
    [Route("MedProduct")]
    public class MedProductController : Controller
    {
        [Route("")]
        [Route("Index")]
        [Route("~/")]
        public IActionResult Index()
        {
            MedicineModel productModel = new MedicineModel();
            ViewBag.products = productModel.getAll();
            return View();
        }
    }
}

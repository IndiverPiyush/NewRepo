using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineSearchWebApp.Models;
using System.Data.SqlClient;

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
        public IActionResult Order(Medecine med, int id)
        {
            //int i = med.MedicineId;
            int a = id;
            double p;
            string name;
            int v;
            TempData["UserName"] = HttpContext.Session.GetString("username"); 
            TempData["MedicineId"] = a;
            HttpContext.Session.SetInt32("MID", a);
            SqlConnection connection = new SqlConnection("Data Source=AZ-MV-SQLSERVER;Initial Catalog=MedicineSearch;Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from medecine where MEDICINE_ID =" + id, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                name = dr["MEDICINE_NAME"].ToString();
                TempData["MedicineName"] = name;
                HttpContext.Session.SetString("name", name);
                v = int.Parse(dr["PROVIDER_ID"].ToString());
                HttpContext.Session.SetInt32("VID", v);
                p = (double)double.Parse(dr["MEDICINE_PRICE"].ToString());
                TempData["MedicinePrice"] = p;
                HttpContext.Session.SetInt32("price", (int)p);

            }
            connection.Close();
            
            
            return View();
        }
        [HttpPost]
        public IActionResult Order(IFormCollection collection)
        {
            int qty = int.Parse(collection["qtyText"].ToString());
            int vendorId = (int)HttpContext.Session.GetInt32("VID");
            double p = (double)HttpContext.Session.GetInt32("price");
            string mname = HttpContext.Session.GetString("name");
            int mid = (int)HttpContext.Session.GetInt32("MID");
            string customerName = HttpContext.Session.GetString("username");
            int customerId = (int)HttpContext.Session.GetInt32("userid");
            int wallet = (int) HttpContext.Session.GetInt32("userwallet");
            int orderNo;
            DateTime time = System.DateTime.Now;
            double total = 0;
            total = qty * p;

            if (total > wallet)
            {
                TempData["Error"] = "Wallet Balance is low";
                return View();
            }
            else
            {
                SqlConnection connection = new SqlConnection("Data Source=AZ-MV-SQLSERVER;Initial Catalog=MedicineSearch;Integrated Security=True");
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO ORDER_HISTORY VALUES(@cid, @cname, @mid, @mname, @vid, @qty, @total, @time)", connection);
                cmd.Parameters.AddWithValue("@cid",customerId);
                cmd.Parameters.AddWithValue("@cname", customerName);
                cmd.Parameters.AddWithValue("@mid", mid);
                cmd.Parameters.AddWithValue("@mname", mname);
                cmd.Parameters.AddWithValue("@vid", vendorId);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@time", time);
                cmd.ExecuteNonQuery();
                SqlCommand updateCusWallet = new SqlCommand("update CUSTOMER set USER_WALLETBAL = USER_WALLETBAL - " + total + " WHERE USER_ID = " + customerId, connection);
                updateCusWallet.ExecuteNonQuery();
                SqlCommand updateVendorWallet = new SqlCommand("update VENDOR set VENDOR_WALLET = VENDOR_WALLET + " + total + " WHERE VENDOR_ID = " + vendorId, connection);
                updateVendorWallet.ExecuteNonQuery();
                SqlCommand lastOrder = new SqlCommand("select top 1 * from order_history order by order_no desc", connection);
                SqlDataReader dr = lastOrder.ExecuteReader();
                while (dr.Read())
                {
                    orderNo = int.Parse(dr["ORDER_NO"].ToString());
                    TempData["orderNo"] = orderNo;
                    customerId = int.Parse(dr["CUSTOMER_ID"].ToString());
                    TempData["customerId"] = customerId;
                    TempData["customername"] = HttpContext.Session.GetString("username");
                    mname = dr["MEDICINE_NAME"].ToString();
                    TempData["mname"] = mname;
                    vendorId = int.Parse(dr["VENDOR_ID"].ToString());
                    TempData["vendorId"] = vendorId;
                    qty = int.Parse(dr["MEDICINE_QUANTITY"].ToString());
                    TempData["qty"] = qty;
                    total = int.Parse(dr["ORDER_AMOUNT"].ToString());
                    TempData["total"] = total;
                    time = DateTime.Parse(dr["DATE_TIME"].ToString());
                    TempData["time"] = time;
                }
                return View("OrderDetails");
            }
        }
        public IActionResult OrderDetails()
        {
            return View();
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

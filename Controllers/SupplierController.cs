using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SupplierController : Controller
    {
        private StoreContext store;
        public SupplierController()
        {
            store = new StoreContext();
        }
        // GET: Supplier
        public ActionResult Index()
        {
            var supplier = store.Suppliers.ToList();
            ViewBag.Suppliers = supplier;
            return View();
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool result = false;
            var supplier = store.Suppliers.FirstOrDefault(s => s.Id == id);

            if(supplier != null)
            {
                store.Suppliers.Remove(supplier);
                store.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult SaveSupplier(Supplier supplier)
        {
            store.Suppliers.Add(supplier);
            store.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
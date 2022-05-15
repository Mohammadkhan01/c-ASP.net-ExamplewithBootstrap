using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Config;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    
    public class CategoryController : Controller
    {
        private StoreContext store;
        public CategoryController()
        {
            store = new StoreContext();
        }
        // GET: Category
        public ActionResult Index()
        {
            var categories = store.Categories.ToList();
            return View(categories);

        }
        public ActionResult Create()
        {
            return View(new Category { CategoryId = 0 }) ;
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
                return View("Create", store);

            if (category.CategoryId > 0)
                store.Entry(category).State = System.Data.Entity.EntityState.Modified;
            else
                store.Categories.Add(category);
                store.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var category = store.Categories.SingleOrDefault(c => c.CategoryId == id);

            if (category == null)
                return HttpNotFound();
            store.Categories.Remove(category);
            store.SaveChanges();

            return RedirectToAction("Index");


        }

        public ActionResult Edit(int? id)
        {
            
                if (id == null)
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

                var category = store.Categories.SingleOrDefault(c => c.CategoryId == id);

                if (category == null)
                    return HttpNotFound();

                return View("Create", category);
                

            }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                store.Dispose();
            base.Dispose(disposing);
        }
    }
}
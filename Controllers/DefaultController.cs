using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        aaa95_anjuman_testEntities2 aaa95;
        public DefaultController()
        {
            aaa95 = new aaa95_anjuman_testEntities2();
        }
        // GET: Default
        public ActionResult Index()
        {
            var products = aaa95.users.ToList();
            return View(products);
        }
        public ActionResult Create()
        {
            return View(new user { userid =0});
        }

        public ActionResult Search(string search)
        {
            //var bank_Account = from p in aaa95.users
            //                   where p.username.Contains(search)
            //                   select p;
            //aaa95.users.Where(p => p.username == search).ToList();
            var matching = aaa95.users.Where(p => p.username.Contains(search));

            return View("Index", matching);
        }

        [HttpPost]
        public ActionResult Create(user bank_Account)
        {
            if (ModelState.IsValid)
            {
                if (bank_Account.userid > 0)
                    aaa95.Entry(bank_Account).State = System.Data.Entity.EntityState.Modified;
                else
                    aaa95.users.Add(bank_Account);

                aaa95.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", bank_Account);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var users = aaa95.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View("Create", users);
        }
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);            
            }
            user bank_Account = aaa95.users.Find(id);
            if(bank_Account == null)
            {
                return HttpNotFound();
            }

            aaa95.users.Remove(bank_Account);
            aaa95.SaveChanges();
            return RedirectToAction("Index");
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                aaa95.Dispose();
                base.Dispose(disposing);
            }
        }
    }
}
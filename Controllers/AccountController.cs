using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.Entity;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private StoreContext store;

        public AccountController()
        {
            store = new StoreContext();
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (!ModelState.IsValid)            
                return View("Register", user);

            if(store.Users.Where(u => u.Email == user.Email).Any())
            {
                ModelState.AddModelError("Email", "This Email Already Exists");
                return View("Register", user);
            }

            if (store.Users.Where(u => u.UserName == user.UserName).Any())
            {
                ModelState.AddModelError("UserName", "This User  Already Exists");
                return View("Register", user);
            }
            store.Users.Add(user);
            store.SaveChanges();

            return Content ("Your registration is successful");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginFormViewModel user)
        {
            if (!ModelState.IsValid)
                return View("Login", user);

            var loginUser = store.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password && u.IsActive == true).FirstOrDefault();

            if(loginUser == null)
            {
                ModelState.AddModelError("UserName", "UserName or Password is incorrect . Please provide valid username and password.");
                return View("Login", user);
            }
            else
            {
                Session["UserName"] = loginUser.UserName;
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SagaEvent.Models;

namespace SagaEvent.Controllers
{
    public class HomeController : Controller
    {

        sagaeventEntities db = new sagaeventEntities(); 

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutUS()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(USER user)
        {
            if(db.USERS.Any(x=>x.userEmail == user.userEmail))
            {
                ViewBag.Notification = "This account is already existed!";
                return View();
            }

            else
            {
                db.USERS.Add(user);
                db.SaveChanges();

                Session["userIDSession"] = user.userId.ToString();
                Session["userrNameSession"] = user.userFullName.ToString();

                return RedirectToAction("Index", "Home");
            }

            
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");

        }

        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(USER user)
        {
            var checkLogin = db.USERS.Where(x=>x.userEmail.Equals(user.userEmail) &&  x.userPassword.Equals(user.userPassword)).FirstOrDefault();

            if (checkLogin != null)
            {
                Session["userIDSession"] = checkLogin.userId.ToString();
                Session["userrNameSession"] = checkLogin.userFullName.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Wrong Email or Password";
            }
            return View();

        }

        public ActionResult alleventpage()
        {
            var eventlist = db.EVENTS.ToList();
            return View(eventlist);
        }


        public ActionResult Categories(string type)
        {
            
            var eventlist = db.EVENTS.Where(x => x.eventType == type).ToList();
            return View(eventlist);
        }

    }
}
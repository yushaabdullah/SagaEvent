using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data.Entity;
using SagaEvent.Models;
using SagaEvent.Controllers;


namespace SagaEvent.Controllers
{
    public class AdminController : Controller
    {
        sagaeventEntities db = new sagaeventEntities();

        // GET: Admin
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(ADMIN user)
        {
            var checkLogin = db.ADMINs.Where(x => x.adminEmail.Equals(user.adminEmail) &&  x.adminPassword.Equals(user.adminPassword)).FirstOrDefault();

            if (checkLogin != null)
            {
                Session["adminIDSession"] = checkLogin.adminID.ToString();
                Session["adminEmailSession"] = checkLogin.adminEmail.ToString();
                return RedirectToAction("AdminDashBoard", "Admin");
            }
            else
            {
                ViewBag.Notification = "Wrong Email or Password";
            }
            return View();

        }

        public ActionResult AdminDashBoard()
        {
            return View();
        }
        public ActionResult AdminLogout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(ADMIN ad1)
        {
            if (ModelState.IsValid)
            {
                ADMIN object1 = new ADMIN();
                object1.adminEmail = ad1.adminEmail;
                object1.adminPassword = ad1.adminPassword;
                db.ADMINs.Add(object1);
                db.SaveChanges();
            }
            ModelState.Clear();
            return RedirectToAction("AdminDashBoard", "Admin");
        }




        public ActionResult AddEvent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEvent(EVENT event1, HttpPostedFileBase file)
        {

            string mainconn = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "insert into [dbo].[EVENTS] (eventName,eventType,eventDescription, eventPreparationTime,eventPrice,eventPhoto) values (@eventName,@eventType,@eventDescription, @eventPreparationTime,@eventPrice,@eventPhoto)";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            sqlcomm.Parameters.AddWithValue("@eventName", event1.eventName);
            //if(file != null && file.ContentLength > 0)
            //{
            //    string filename = Path.GetFileName(file.FileName);
            //    string imgpath = Path.Combine(Server.MapPath("~/proimages/"),filename);
            //    file.SaveAs(imgpath);
            //}
            //sqlcomm.Parameters.AddWithValue("@proimage", "~/proimages/"+file.FileName );
            sqlcomm.Parameters.AddWithValue("@eventType", event1.eventType);
            sqlcomm.Parameters.AddWithValue("@eventDescription", event1.eventDescription);
            sqlcomm.Parameters.AddWithValue("@eventPreparationTime", event1.eventPreparationTime);
            sqlcomm.Parameters.AddWithValue("@eventPrice", event1.eventPrice);
            sqlcomm.Parameters.AddWithValue("@eventPhoto", event1.eventPhoto);

            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
            return RedirectToAction("AddEvent", "Admin");
        }



        public ActionResult ViewEvents()
        {
            var eventlist = db.EVENTS.ToList();
            return View(eventlist);
        }

       
        public ActionResult DeleteEvent(int eventId)
        {
            var res = db.EVENTS.Where(x => x.eventId == eventId).First();
            db.EVENTS.Remove(res);
            db.SaveChanges();

            var eventlist2 = db.EVENTS.ToList();
            return View("ViewEvents", eventlist2);
        }


        public ActionResult EditEvent(EVENT pro2)
        {
            return View(pro2);
        }
        public ActionResult EditEventSave(EVENT pro2, HttpPostedFileBase file)
        {
            //int proidxyz = pro2.proid;
            string mainconn = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "update [dbo].[EVENTS] set eventName=@eventName ,eventType =@eventType ,eventDescription = @eventDescription , eventPreparationTime =@eventPreparationTime,eventPrice=@eventPrice,eventPhoto=@eventPhoto where eventName=@eventName  ";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();

            sqlcomm.Parameters.AddWithValue("@eventName", pro2.eventName);
            
            sqlcomm.Parameters.AddWithValue("@eventType", pro2.eventType);
            sqlcomm.Parameters.AddWithValue("@eventDescription", pro2.eventDescription);
            sqlcomm.Parameters.AddWithValue("@eventPreparationTime", pro2.eventPreparationTime);
            sqlcomm.Parameters.AddWithValue("@eventPrice", pro2.eventPrice);
            sqlcomm.Parameters.AddWithValue("@eventPhoto", pro2.eventPhoto);

            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
            return RedirectToAction("ViewEvents", "Admin");
        }



        public ActionResult ViewUser()
        {
            var userlist = db.USERS.ToList();
            return View(userlist);
        }
        public ActionResult DeleteUser(int userId)
        {
            var res = db.USERS.Where(x => x.userId == userId).First();
            db.USERS.Remove(res);
            db.SaveChanges();

            var userlist = db.USERS.ToList();
            return View("viewuser", userlist);
        }


    }
}
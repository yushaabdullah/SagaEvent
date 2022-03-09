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
    public class OrderController : Controller
    {
        sagaeventEntities db = new sagaeventEntities();
        // GET: Order
        public ActionResult Order(int eventID)
        {
            Session["eventID"] = eventID;

            var eventt = db.EVENTS.Where(x => x.eventId == eventID).FirstOrDefault();

            EVENT obj = eventt;

            return View(obj);
        }

        public ActionResult OrderContinue()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OrderContinue(ORDER obj)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);

            string eventid = Session["eventID"].ToString();
            string userid = Session["userIDSession"].ToString();
           

            string sqlquery = "insert into [dbo].[ORDERS] (orderStatus,paymentStatus,guestNumber, eventDate,eventId,foodId,userId,eventPlace) values (@orderStatus,@paymentStatus,@guestNumber, @eventDate,@eventId,@foodId,@userId,@eventPlace)";

            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();

            sqlcomm.Parameters.AddWithValue("@orderStatus", "received");
            sqlcomm.Parameters.AddWithValue("@paymentStatus", "unpaid");
            sqlcomm.Parameters.AddWithValue("@guestNumber", obj.guestNumber);
            sqlcomm.Parameters.AddWithValue("@eventDate", obj.eventDate);
            sqlcomm.Parameters.AddWithValue("@eventId", eventid);
            sqlcomm.Parameters.AddWithValue("@foodId", 1);
            sqlcomm.Parameters.AddWithValue("@userId", userid);
            sqlcomm.Parameters.AddWithValue("@eventPlace",obj.eventPlace);

            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();

            TempData["alertMessage"]="Congratulatins! Your Order has been placed.";

            return RedirectToAction("Confirmation", "Order");
  
        }

        public ActionResult Confirmation()
        {
            return View();
        }

    }
}
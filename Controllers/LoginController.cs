using System;
using System.Data.Common;
using System.Security.Cryptography.Xml;
using flightbooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace flightbooking.Controllers{

    public class LoginController:Controller
    {
        private readonly ISession session;
        private readonly Ace52024Context db;
        public LoginController(Ace52024Context _db, IHttpContextAccessor httpContextAccessor){
            db=_db;
            session = httpContextAccessor.HttpContext.Session;
        }
        public ActionResult Login(){
            return View();
        }

         [HttpPost]

         public ActionResult Login(Kushcustomer c){
            var result= (from i in db.Kushcustomers
                         where i.Custid == c.Custid && i.Custpwd == c.Custpwd
                         select i).SingleOrDefault();
            if(result!=null){
                HttpContext.Session.SetString("cid",result.Custid.ToString());
                return RedirectToAction("GetAllBookings","Booking");
            }
            else{
                return View();
            }
         }

          public ActionResult Register(){
            return View();
        }

         [HttpPost]

         public ActionResult Register(Models.Kushcustomer c){
            if(ModelState.IsValid){
                db.Kushcustomers.Add(c);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
            
         }

         public ActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
         }
    }
}
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
                HttpContext.Session.SetString("cname",result.Custname);
                return RedirectToAction("Welcome");
            }
            else{
                return View();
            }
         }

         public ActionResult Welcome(){
            ViewBag.Custid=(HttpContext.Session.GetString("cid"));
            if(ViewBag.Custid!=null){
                ViewBag.Data = HttpContext.Session.GetString("cname");
                return View();
            }
            return RedirectToAction("Login");
         }

          public ActionResult Register(){
            ViewBag.Custid=(HttpContext.Session.GetString("cid"));
            if(ViewBag.Custid!=null){
            return View();
            }
            return RedirectToAction("Login");
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
        [HttpGet]
         public ActionResult Edit(){
            ViewBag.Custid=(HttpContext.Session.GetString("cid"));
            if(ViewBag.Custid!=null){
                Kushcustomer kc = db.Kushcustomers.Find(int.Parse(ViewBag.Custid));
                return View(kc);
            }
            else{
                return RedirectToAction("Login","Login");
            }
         }

         [HttpPost]
         public ActionResult Edit(Kushcustomer kc){
            if(ModelState.IsValid){
                db.Kushcustomers.Update(kc);
                db.SaveChanges();
                return RedirectToAction("Welcome");
            }
            else{return RedirectToAction("Login","Edit");}
         }

         public ActionResult Details(){
            ViewBag.Custid=(HttpContext.Session.GetString("cid"));
            if(ViewBag.Custid!=null){
                Kushcustomer kc = db.Kushcustomers.Find(int.Parse(ViewBag.Custid));
                return View(kc);
            }
            else{
                return RedirectToAction("Login","Login");
            }
         }

         public ActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
         }
    }
}
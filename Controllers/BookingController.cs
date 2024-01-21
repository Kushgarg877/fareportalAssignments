using System.Data.Common;
using flightbooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace flightbooking.Controllers{
    public class BookingController:Controller{
        private readonly Ace52024Context db;
        public BookingController(Ace52024Context _db){
            db=_db;
        }

        public ActionResult GetAllBookings(){

             ViewBag.Custid=HttpContext.Session.GetString("cid");
            if(ViewBag.Custid!=null){
                var list = (from i in db.Kushbookings
                            where i.Custid == int.Parse(HttpContext.Session.GetString("cid")) 
                            select i).ToList();
                return View(list);
            }
            else{
                return RedirectToAction("Login","Login");
            }
        }

        public ActionResult Details(int id){

            ViewBag.Custid=HttpContext.Session.GetString("cid");
            if(ViewBag.Custid!=null){
                var results = db.Kushbookings.Include(x => x.Flight).ThenInclude(x => x.Arr);
            // var result = db.Kushbookings.Include(x => x.Flight).ThenInclude(x => x.Dep);
            var kb = results.Where(x => x.Bookid ==id).SingleOrDefault();
            
            return View(kb);
            }

            return RedirectToAction("Login","Login");
            
        }




        // public ActionResult Edit(int id){

        //     var results = db.Kushbookings.Include(x => x.Flight).ThenInclude(x => x.Arr);
        //     TempData["kb"] = results.Where(x => x.Bookid ==id).SingleOrDefault();
            
        //     return View(TempData["kb"] );
        // }
        // [HttpPost]
        // public ActionResult Edit(){

        //     TempData["kb"] ="";
        //     return RedirectToAction("Edit","Flight");
        // }




        public ActionResult Delete(int id){
            
            ViewBag.Custid=HttpContext.Session.GetString("cid");
            if(ViewBag.Custid!=null){
                Kushbooking kb =db.Kushbookings.Where(x => x.Bookid==id).SingleOrDefault();
                return View(kb);
            }
            else{
                return RedirectToAction("Login","Login");
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id){
            Kushbooking kb =db.Kushbookings.Where(x => x.Bookid==id).SingleOrDefault();
            if(kb!=null){
                db.Kushbookings.Remove(kb);
            db.SaveChanges();
            return RedirectToAction("GetAllBookings");
            }
            else{
                return RedirectToAction("Login","Login");
            }
            
        }
    }  
}
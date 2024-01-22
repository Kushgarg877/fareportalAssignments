using System.Data;
using flightbooking.Models;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;

namespace flightbooking.Controllers{

    public class FlightController:Controller
    {
        
        private readonly Ace52024Context db;
        public FlightController(Ace52024Context _db){
            db=_db;
        }

        public ActionResult option(){
            ViewBag.Custid=(HttpContext.Session.GetString("cid"));
            if(ViewBag.Custid!=null){
            return View();}
            return RedirectToAction("Login","Login");
        }

        [HttpPost]
        public ActionResult option(Place p){
            ViewBag.Custid=(HttpContext.Session.GetString("cid"));
            if(ViewBag.Custid!=null){
            TempData["s"] = p.Source;
            TempData["d"] = p.Destination;
            return RedirectToAction("Avflights");}
            return RedirectToAction("Login","Login");
        }

        public ActionResult Avflights(){
            ViewBag.Custid=(HttpContext.Session.GetString("cid"));
            if(ViewBag.Custid!=null){
            Place p = new Place();
            p.Source = TempData["s"].ToString();
            p.Destination = TempData["d"].ToString();
            var list=(  from i in db.Flightdetails
                        where i.Source==p.Source && i.Destination==p.Destination
                        select i
                     ).ToList();
            return View(list);}
            else{
                return RedirectToAction("Login","Login");
            }
            
        }
        
        // public ActionResult Book(int id){
        //     var list = (Flightdetail)db.Flightdetails.Where(x=>x.FlightDid==id);
        //     return View(list);
        // }

    
        public ActionResult Booked(int id){
            ViewBag.Custname=HttpContext.Session.GetString("cname");
            ViewBag.Custid=(HttpContext.Session.GetString("cid"));
            if(ViewBag.Custid!=null){
            ViewBag.Custid=HttpContext.Session.GetString("cid");
            Flightdetail fd = db.Flightdetails.Where(x=>x.FlightDid==id).SingleOrDefault();
            if(fd!=null){
                Kushbook kb = new Kushbook();
                kb.Custoid = int.Parse(ViewBag.Custid);
                kb.FlightsDid = fd.FlightDid;
                kb.Bookdate = DateTime.Now;
                db.Kushbooks.Add(kb);
                db.SaveChanges();
                return View();
            }
            return RedirectToAction("Welcome","Login");}
            return RedirectToAction("Login","Login");
            
        }

        // public ActionResult FlightBooking(){
        //     ViewBag.Custid=HttpContext.Session.GetString("cid");
        //     if(ViewBag.Custid!=null){
        //         ViewBag.fid = new SelectList(db.Kushairports,"Aid","Alocation");
        //         return View();
        //     }
        //     else{
        //         return RedirectToAction("Login","Login");
        //     }
        // }
/*
        [HttpPost]
        public ActionResult FlightBooking(Kushflight f){
            ViewBag.Custid=HttpContext.Session.GetString("cid");
            if(ViewBag.Custid != null){
                db.Kushflights.Add(f);
                db.SaveChanges();
                Kushbooking kb = new Kushbooking();
                kb.Custid = int.Parse(ViewBag.Custid);
                kb.Flightid = f.FlightId;
                kb.Bookdate = DateTime.Now;
                db.Kushbookings.Add(kb);
                db.SaveChanges();
                return RedirectToAction("GetAllBookings","Booking");
            }
            else{
                return RedirectToAction("Login","Login");
            }                
        }

        public ActionResult Edit(int id){

            ViewBag.Custid=HttpContext.Session.GetString("cid");
            if(ViewBag.Custid!=null){
                ViewBag.feid = new SelectList(db.Kushairports,"Aid","Alocation");
                Kushflight kf = new Kushflight();
                var results = db.Kushflights.Include(x => x.Kushbookings);
                foreach(var item in results){
                    kf = (  from i in item.Kushbookings
                            where i.Bookid == id
                            select item
                        ).SingleOrDefault();
                }
                return View(kf);
            }
            else{
                return RedirectToAction("Login","Login");
            }
        }

        [HttpPost]
        public ActionResult Edit(Kushflight kf){
            db.Kushflights.Update(kf);
            db.SaveChanges();

            return RedirectToAction("GetAllBookings","Booking");
        }*/

    }
}
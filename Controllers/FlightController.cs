using System.Data;
using flightbooking.Models;
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

        public ActionResult FlightBooking(){

            ViewBag.fid = new SelectList(db.Kushairports,"Aid","Alocation");
            return View();
        }

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
        }

    }
}
using System;
using System.Data.Common;
using flightbooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace flightbooking.Controllers{
    public class AdminController:Controller{
        private readonly Ace52024Context db;
        public AdminController(Ace52024Context _db){
            db=_db;
        }

        public ActionResult AdminLogin(){
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin a){
            if (a.Apwd == "admin"){
                return RedirectToAction("flightlist");
            }
            else{
                return View("Login","Login");
            }
        }

        public ActionResult Createflight(){
            ViewBag.fdcs = new SelectList(db.Flightdetails,"Source","Source");
            ViewBag.fdcd = new SelectList(db.Flightdetails,"Destination","Destination");
            return View();
        }

        [HttpPost]
        public ActionResult Createflight(Flightdetail fd){
            db.Flightdetails.Add(fd);
            db.SaveChanges();

            return RedirectToAction("flightlist");
        }

        public ActionResult flightlist(){
            var list =db.Flightdetails;
            return View(list);
        }

        public ActionResult bookinglist(){
            var list =db.Kushbooks;
            return View(list);
        }

        [HttpGet]
        public ActionResult Edit(int id){
            Console.WriteLine(id);
            ViewBag.fdes = new SelectList(db.Flightdetails,"Source","Source");
            ViewBag.fded = new SelectList(db.Flightdetails,"Destination","Destination");
            Flightdetail fd = db.Flightdetails.Where(x => x.FlightDid==id).SingleOrDefault();
            return View(fd);
        }

        [HttpPost]
        public ActionResult Edit(Flightdetail fd){
            db.Flightdetails.Update(fd);
            db.SaveChanges();
            return RedirectToAction("flightlist");
        }
        [HttpGet]
        public ActionResult Delete(int id){
            Flightdetail fd = db.Flightdetails.Where(x => x.FlightDid==id).SingleOrDefault();
            return View(fd);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id){
            Flightdetail fd = db.Flightdetails.Where(x => x.FlightDid==id).SingleOrDefault();
            if(fd!=null){
                db.Flightdetails.Remove(fd);
            db.SaveChanges();
            return RedirectToAction("flightlist");
            }
            else{
                return RedirectToAction("Login","Login");
            }
        }
    }
}

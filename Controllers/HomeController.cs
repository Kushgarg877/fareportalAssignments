using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using flightbooking.Models;

namespace flightbooking.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Custname=HttpContext.Session.GetString("cid");
        if(ViewBag.Custname!=null){
            Console.WriteLine(ViewBag.Custname);

            return View();
        }
        else{
            return RedirectToAction("Login","Login");
        }
        
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

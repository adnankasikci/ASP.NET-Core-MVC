using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyAspNetProject.Models;

namespace MyAspNetProject.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    // public HomeController(ILogger<HomeController> logger){}
    // public IActionResult Error(){return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });}
}

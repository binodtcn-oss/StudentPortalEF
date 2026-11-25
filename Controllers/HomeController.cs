using Microsoft.AspNetCore.Mvc;

namespace StudentPortalEntityFramework.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Home";
        ViewBag.Message = "Welcome to the ASP.NET MVC + Entity Framework demo!";
        return View();
    }
}

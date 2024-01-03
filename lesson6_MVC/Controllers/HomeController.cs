using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lesson6_MVC.Models;

namespace lesson6_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // custom path for endpoint - conflicts with the conventional routing
    // [HttpGet("/home")]
    public IActionResult Index()
    {
        return View();
    }

    // custom path for endpoint - conflicts with the conventional routing
    // [HttpGet("/privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [HttpGet]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

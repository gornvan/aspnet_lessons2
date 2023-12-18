using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Single_Responsibility.Models;

namespace Single_Responsibility.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // ANTIPATTERN
        // Controller should only handle the data forwading (converting) between Browser and the Service
        if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
        {
            return NotFound();
        }
        return View();
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

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SOLID.Filters;
using SOLID.Models;

namespace SOLID.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [ForbiddenDayOfWeekFilterAtribute(DayOfWeek.Monday /* another example of OPEN-CLOSED ignorance - the Day is not configurable */)]
    public IActionResult Index()
    {
        //// ANTIPATTERN
        //// Controller should only handle the data forwading (converting) between Browser and the Service
        //if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
        //{
        //    return NotFound();
        //}
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

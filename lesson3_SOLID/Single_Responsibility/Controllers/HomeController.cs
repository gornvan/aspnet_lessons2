using Microsoft.AspNetCore.Mvc;
using SOLID.Filters;
using SOLID.Models;
using System.Diagnostics;

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
        // Example of a real-world unsegregated interface (Interface Segregation ignorance)
        // "Request" is an example of a BIG interface which is often unneeded

        // Instead of Request.Body PREFER using [FromBody] atrribute (see Privacy HttpPost method)

        // Instead of Request.Query PREFER using [FromQuery] atrribute (see Privacy HttpPost method)

        // Request.Headers;
        // Request.Form;
        // Request.Cookies;

        return View();
    }

    [HttpPost]
    public IActionResult Privacy([FromBody]int point, [FromQuery] string search)
    {
        return View();
    }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

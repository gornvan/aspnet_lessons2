using Microsoft.AspNetCore.Mvc;

namespace FabricMarket_MVC.Controllers
{
    public class XssController : BaseController
	{
		private readonly ILogger<HomeController> _logger;

        public XssController(IConfiguration config) : base(config)
        {
        }

        // Vulnerable page which would execute the script provided into searchValue!!!
        // https://localhost:7209/XSS/Vulnerable?searchValue=<script>alert('hello XSS')</script>
        public IActionResult Vulnerable(string searchValue)
		{
            return View((object)searchValue);
		}

        public IActionResult Protected(string searchValue)
        {
            return View((object)searchValue);
        }
    }
}

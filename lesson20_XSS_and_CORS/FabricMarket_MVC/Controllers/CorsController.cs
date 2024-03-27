using Microsoft.AspNetCore.Mvc;

namespace FabricMarket_MVC.Controllers
{
    public class CorsController : BaseController
	{
        public CorsController(IConfiguration config) : base(config)
        {
        }

        public IActionResult Index(string searchValue)
        {
            ViewBag.ApiBaseUrl = ApiBaseUrl;
            return View((object)searchValue);
        }
    }
}

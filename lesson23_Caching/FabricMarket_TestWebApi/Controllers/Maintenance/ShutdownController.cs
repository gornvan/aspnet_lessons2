using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FabricMarket_TestWebApi.Controllers.Maintenance
{

    [ApiController]
    [Route("api/[controller]")]
    public class ShutdownController : ControllerBase
    {
        [HttpPost]
        public void Index()
        {
            Console.WriteLine("REQUESTED TO SHUT DOWN");
            //Process.GetCurrentProcess().Kill();
        }
    }
}

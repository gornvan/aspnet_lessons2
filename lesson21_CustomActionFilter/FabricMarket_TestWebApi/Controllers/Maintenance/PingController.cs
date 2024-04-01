using Microsoft.AspNetCore.Mvc;

namespace FabricMarket_TestWebApi.Controllers.Maintenance
{

    [ApiController]
    [Route("api/[controller]")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "\"pong\"";
        }
    }
}

using FabricMarket_BLL.Contracts.SystemSettings;
using lesson11_FabricMarket_DomainModel.Models.SystemSettings;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ILogger = Serilog.ILogger;


namespace FabricMarket_TestWebApi.Controllers.System
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemSettingsController : ControllerBase
    {

        private readonly ISystemSettingsService _settingsService;
        private readonly ILogger _logger;

        public SystemSettingsController(
            ISystemSettingsService systemSettingsService,
            ILogger logger
        ) {
            _settingsService = systemSettingsService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(SystemSettingEnum id) {
            try
            {
                var settingValue = await _settingsService.ReadSetting(id);
                return Ok(settingValue);
            }
            catch (Exception ex)
            {
                var msg = "Failed to write System Setting";
                _logger.Error(ex, msg);

                return StatusCode((int)HttpStatusCode.InternalServerError, msg);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(SystemSettingEnum id, string newValue)
        {
            // to be replaced with:
            // await _settingsService.WriteSetting(id, newValue);
            // after implementing an exception filter
            try
            {
                await _settingsService.WriteSetting(id, newValue);
                return Ok();
            }
            catch (Exception ex)
            {
                var msg = "Failed to write System Setting";
                _logger.Error(ex, msg);
                
                return StatusCode((int)HttpStatusCode.InternalServerError, msg);
            }
        }
    }
}

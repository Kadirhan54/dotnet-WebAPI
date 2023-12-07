using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application;

namespace WebApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Week10HomeWorkConfigurationController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;

        public Week10HomeWorkConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet]
        public IActionResult GetValue()
        {
            var str = _configurationService.GetValue("YetgenPostgreSQLDB");
            return Ok(str);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application;

namespace WebApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Week10HomeWorkController : ControllerBase
    {
        

        [HttpGet]
        public IActionResult GetValue()
        {
            var str = ExampleClass.ExampleMethod("YetgenPostgreSQLDB");
            return Ok(str);
        }
    }
}

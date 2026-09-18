using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SenTox.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetColor()
        {
            return Ok("SB");
        }
    }
}

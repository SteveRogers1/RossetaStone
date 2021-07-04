using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RossetaStone.Data;

namespace RossetaStone.Controllers
{
    [ApiController]
    [Route("test")]
    public class TestController : Controller
    {
        
        public IActionResult Get()
        {
            return Ok("Cтраница администратора");
        }
    }
}

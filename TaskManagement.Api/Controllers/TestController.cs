using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("crash")]
        public IActionResult Crash()
        {
            try
            {
                throw new Exception("Boom! Something went wrong.");
            }
            catch(Exception ex)
            {
                return BadRequest(new
                {
                    Status=400,
                    Message=ex.Message,
                });

            }
        }
    }
}


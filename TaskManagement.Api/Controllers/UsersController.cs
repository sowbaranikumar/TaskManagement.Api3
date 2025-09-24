using Microsoft.AspNetCore.Mvc;
using TaskManagement.Business.DTOs;
using TaskManagement.Business.Interfaces;
using TaskManagement.Business.ResponseModels;
namespace TaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices _usersServices;

        public UsersController(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _usersServices.GetAllUsersAsync();
            return Ok(ApiResponseFactory.Success(users));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            var user = await _usersServices.GetUserByIdAsync(id);
            if (user == null)
                return NotFound(ApiResponseFactory.NotFound<object>());

            return Ok(ApiResponseFactory.Success(user));
        }
    }
}

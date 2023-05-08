using Customers.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService UsersService;

        public UsersController(IUsersService usersService)
        {
            UsersService = usersService;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> Get()
        {
            var users = await UsersService.GetAllUsers();
            return Ok("all good");
        }
    }
}
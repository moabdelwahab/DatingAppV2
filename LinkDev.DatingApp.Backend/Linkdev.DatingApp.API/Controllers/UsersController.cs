using Microsoft.AspNetCore.Mvc;
using LinkDev.DatingApp.Application;
using System.Threading.Tasks;
using LinkDev.DatingApp.Application.Contracts;

namespace LinkDev.DatingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersManager _usersManager;
        public UsersController(IUsersManager usersManager)
        {
            this._usersManager = usersManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var result = await _usersManager.GetUsers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUsers(int id)
        {
            var result = await _usersManager.GetUserById(id);
            return Ok(result);
        }

    }
}
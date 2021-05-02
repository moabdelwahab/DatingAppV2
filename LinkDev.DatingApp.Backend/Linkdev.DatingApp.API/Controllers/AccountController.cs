using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LinkDev.DatingApp.Application.Contracts;
using LinkDev.DatingApp.Core;
using LinkDev.DatingApp.Presistence;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.DatingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUsersManager _userManager;
        public AccountController(IUsersManager userManager)
        {
            this._userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<int>> Register(string username, string password)
        {
            using var hmac = new HMACSHA512();
            var user = new AppUser()
            {
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };
            var id = await this._userManager.AddUser(user);
            return Ok(id);
        }

    }
}
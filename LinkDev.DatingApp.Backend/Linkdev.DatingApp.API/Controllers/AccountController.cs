using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LinkDev.DatingApp.Application.Contracts;
using LinkDev.DatingApp.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using LinkDev.DatingApp.Application.BE;
using LinkDev.DatingApp.Application.BE.DTOs;
using LinkDev.DatingApp.Application.Errors;
using System;

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
    public async Task<ActionResult<int>> Register(RegisterDto registerDto)
    {
        if (await _userManager.UserExist(registerDto.username) == null)
        {

            using var hmac = new HMACSHA512();
            var user = new AppUser()
            {
                UserName = registerDto.username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.password)),
                PasswordSalt = hmac.Key
            };
            var id = await this._userManager.AddUser(user);
            return Ok(id);
        }
        else
        {
            return BadRequest("The username is exist , please choose another one ");
        }
    }

    [HttpPost("Login")]
    public async Task<ActionResult<int>> Login(LoginDTO loginDTO)
     {
         var loginUser = await _userManager.Login(loginDTO);
         return Ok(loginUser);
     }

}
}
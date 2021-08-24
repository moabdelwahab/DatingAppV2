using Microsoft.AspNetCore.Mvc;
using LinkDev.DatingApp.Application;
using System.Threading.Tasks;
using LinkDev.DatingApp.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using LinkDev.DatingApp.Application.BE.DTOs;

namespace LinkDev.DatingApp.API.Controllers
{
    [Authorize]
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

        [Authorize]
        [HttpGet("{username}")]
        public async Task<ActionResult> GetUser(string username)
        {
            var result = await _usersManager.GetUserByUsername(username);
            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> Update(UpdateMemberDto memberDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _usersManager.UpdateUser(username,memberDto);
            return Ok();
        }

    }
}
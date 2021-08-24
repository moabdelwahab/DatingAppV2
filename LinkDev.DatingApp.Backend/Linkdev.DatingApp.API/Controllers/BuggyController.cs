using System.Threading.Tasks;
using LinkDev.DatingApp.Application.Contracts;
using LinkDev.DatingApp.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.DatingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : ControllerBase
    {
        private readonly IUsersManager _userManager;
        public BuggyController(IUsersManager userManager)
        {
            this._userManager = userManager;
        }

        [Authorize]
        [HttpGet("auth")] // 401
        public ActionResult<string> GetSecret()
        {
            return "Secret is ";
        }

         [HttpGet("not-found")]
        public async Task<ActionResult<AppUser>> GetNotFound()
        {
            var things = await _userManager.GetUsers();
            var thing = things.Find(x=>x.Id==1);
            if(thing==null) return NotFound();   
            else return Ok(thing);
        }


        [HttpGet("server-error")]
        public async Task<ActionResult<AppUser>> GetServerError ()
        {
            var things = await _userManager.GetUsers();
            var thing = things.Find(x=>x.Id==1);
            thing.UserName.ToString();
             return Ok(thing);
        }

        [HttpGet("bad-request")]
        public  ActionResult<AppUser> GetBadRequest()
        {
            return BadRequest("This is a bad Request ! ... ");
        }
    }
}
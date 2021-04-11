using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Database;
using SchoolRegister.Models;
using SchoolRegister.Services;

namespace SchoolRegister.Controllers
{
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly UsersManagment _usersManagment;

        public UserController(MainDbContext context)
        {
            _usersManagment = new UsersManagment(context);
        }

        [AllowAnonymous]
        [HttpGet("login")]
        public async Task<IActionResult> Login([FromBody] Credential credential)
        {
            try
            {
                ClaimsPrincipal claimsPrincipal = _usersManagment.Authorize(credential);
                if (claimsPrincipal != null)
                {
                    await HttpContext.SignInAsync(claimsPrincipal);
                    return Ok();
                }
            }
            catch (Exception)
            {
                return Unauthorized();
            }
            return Unauthorized();
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("test")]
        public IActionResult Test()
        {
            _usersManagment.AddSeedUsers();
            return Ok();
        }
    }
}
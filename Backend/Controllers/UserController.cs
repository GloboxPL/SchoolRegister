using System;
using System.Collections.Generic;
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
        private readonly UsersManagment _users;

        public UserController(MainDbContext context)
        {
            _users = new UsersManagment(context);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] User userCredential)
        {
            try
            {
                ClaimsPrincipal claimsPrincipal = _users.Authorize(userCredential);
                if (claimsPrincipal != null)
                {
                    await HttpContext.SignInAsync(claimsPrincipal);
                    User user = _users.GetUserByAuthData(claimsPrincipal);
                    return Json(user);
                }
            }
            catch (Exception)
            {
                return Unauthorized();
            }
            return Unauthorized();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

        [HttpPost("user/password")]
        public IActionResult PasswordChange([FromForm] string newPassword)
        {
            User user = _users.GetUserByAuthData(HttpContext.User);
            _users.ChangePassword(user, newPassword);
            return Ok();
        }

        [HttpPost("user/create")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateUsers([FromBody] IEnumerable<User> users)
        {
            try
            {
                _users.AddUsers(users);
                return Ok();
            }
            catch (DataMisalignedException)
            {
                return Conflict();
            }
        }

        [HttpGet("user/teachers-list")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetTeachers()
        {
            var teachers = _users.GetTeachers();
            return Json(teachers);
        }

        [HttpGet("user/students-no-class")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetStudentsWithoutClass()
        {
            var students = _users.GetStudentsWithoutClass();
            return Json(students);
        }


        [AllowAnonymous]
        [HttpPost("admin")]
        public IActionResult CreateAdmin()
        {
            _users.AddSeedUsers();
            return Ok();
        }
    }
}
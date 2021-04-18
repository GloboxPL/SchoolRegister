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

        [HttpPost("student/create")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateStudents([FromBody] IEnumerable<Student> students)
        {
            try
            {
                _users.AddUsers(students);
                return Ok();
            }
            catch (DataMisalignedException)
            {
                return Conflict();
            }
        }

        [HttpPost("teacher/create")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateTeachers([FromBody] IEnumerable<Teacher> teachers)
        {
            try
            {
                _users.AddUsers(teachers);
                return Ok();
            }
            catch (DataMisalignedException)
            {
                return Conflict();
            }
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
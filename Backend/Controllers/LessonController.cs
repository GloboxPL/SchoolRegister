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
    public class LessonController : Controller
    {
        private readonly LessonsManagment _lessons;

        public LessonController(MainDbContext context)
        {
            _lessons = new LessonsManagment(context);
        }

        [HttpPost("lesson/attendance")]
        [Authorize(Roles = "Admin")]
        public ActionResult CheckAttendance([FromBody] Dictionary<int, AttendanceStatus> attendances, [FromQuery] int lessonId)
        {
            _lessons.CheckAttendance(attendances, lessonId);
            return Ok();
        }
    }
}
using System.Linq;
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
using Backend.Models.Dto;

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

        [HttpGet("lessons-teacher/{id}")]
        public ActionResult GetTeacherLessons([FromRoute] int id)
        {
            var lessons = _lessons.GetTeacherLessons(id).Select(x => new LessonDto(x));
            return Json(lessons);
        }

        [HttpGet("lessons-student/{id}")]
        public ActionResult GetStudentLessons([FromRoute] int id)
        {
            var lessons = _lessons.GetStudentLessons(id).Select(x => new LessonDto(x));
            return Json(lessons);
        }

        [HttpPost("frequency/{id}")]
        public ActionResult CheckFrequency([FromRoute] int id, [FromBody] int[] studentsIds)
        {
            _lessons.CheckFrequency(id, studentsIds);
            return Ok();
        }

        [HttpGet("lesson-students/{name}")]
        public ActionResult GetStudentsByClass([FromRoute] string name)
        {
            var lessons = _lessons.GetStudentsByClass(name);
            return Json(lessons);
        }

    }
}
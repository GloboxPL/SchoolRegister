using Backend.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Database;
using SchoolRegister.Models;
using SchoolRegister.Models.Dto;
using SchoolRegister.Services;

namespace SchoolRegister.Controllers
{
    [ApiController]
    [Authorize]
    public class GroupController : Controller
    {
        private readonly GroupsManagment _groups;

        public GroupController(MainDbContext context)
        {
            _groups = new GroupsManagment(context);
        }

        [HttpPost("create-class")]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateGroup([FromBody] NewGroupDto groupDto)
        {
            Group group = _groups.AddGroup(groupDto);
            return Json(group);
        }

        [HttpGet("classes-list")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetGroups()
        {
            var groups = _groups.GetGroups();
            return Json(groups);
        }

        [HttpPost("add-lesson")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddLesson([FromBody] NewLessonDto lesson)
        {
            _groups.AddLesson(lesson);
            return Ok();
        }
    }
}
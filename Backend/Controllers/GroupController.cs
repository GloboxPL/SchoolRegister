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
    public class GroupController : Controller
    {
        private readonly GroupsManagment _groups;

        public GroupController(MainDbContext context)
        {
            _groups = new GroupsManagment(context);
        }

        [HttpPost("group/create")]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateGroup([FromForm] string name)
        {
            Group group = _groups.AddGroup(name);
            return Json(group);
        }

        [HttpPost("group/students")]
        [Authorize(Roles = "Admin")]
        public ActionResult AddStudentsToGroup([FromBody] GroupIn groupIn)
        {
            Group group = _groups.AddStudentsToGroup(groupIn.Name, groupIn.Ids);
            return Ok();
        }
    }
}
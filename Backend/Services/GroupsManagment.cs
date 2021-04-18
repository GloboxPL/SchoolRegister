using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using SchoolRegister.Database;
using SchoolRegister.Models;

namespace SchoolRegister.Services
{
    public class GroupsManagment
    {
        private readonly MainDbRepository _repo;

        public GroupsManagment(MainDbContext context)
        {
            _repo = new MainDbRepository(context);
        }

        public Group AddGroup(string name)
        {
            Group group = new Group(name);
            group = _repo.CreateGroup(group);
            _repo.SaveChanges();
            return group;
        }

        internal Group AddStudentsToGroup(string name, int[] ids)
        {
            Group group = _repo.ReadGroup(name);
            List<Student> students = _repo.ReadStudents(ids).ToList();
            foreach (var student in students)
            {
                group.Students.Add(student);
            }
            _repo.UpdateGroup(group);
            _repo.SaveChanges();
            return group;
        }
    }
}
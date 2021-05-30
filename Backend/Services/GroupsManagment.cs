using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using SchoolRegister.Database;
using SchoolRegister.Models;
using SchoolRegister.Models.Dto;
using Backend.Models.Dto;

namespace SchoolRegister.Services
{
    public class GroupsManagment
    {
        private readonly MainDbRepository _repo;

        public GroupsManagment(MainDbContext context)
        {
            _repo = new MainDbRepository(context);
        }

        public Group AddGroup(NewGroupDto groupDto)
        {
            Group group = new Group(groupDto.Name);

            group.Students = _repo.ReadStudents(groupDto.StudentsIds.ToArray()).ToList();
            group.Teacher = _repo.ReadUser(groupDto.TeacherId) as Teacher;
            _repo.CreateGroup(group);
            _repo.SaveChanges();
            return group;
        }

        public IEnumerable<string> GetGroups()
        {
            var groups = _repo.ReadAllGroups();
            return groups;
        }

        public Lesson AddLesson(NewLessonDto lessonDto)
        {
            Lesson lesson = new Lesson
            {
                Teacher = _repo.ReadUser(lessonDto.TeacherId) as Teacher,
                Group = _repo.ReadGroup(lessonDto.ClassName),
                Subject = lessonDto.Name,
                Day = lessonDto.Day,
                Time = lessonDto.Lesson
            };
            _repo.CreateLesson(lesson);
            _repo.SaveChanges();
            return lesson;
        }
    }
}
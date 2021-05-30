using System;
using System.Collections.Generic;
using System.Linq;
using SchoolRegister.Database;
using SchoolRegister.Models;
using SchoolRegister.Models.Dto;

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

        public Group AddStudentsToGroup(string name, int[] ids)
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

        public Lesson AddLesson(LessonIn lessonIn)
        {
            DateTime time = DateTime.Parse(lessonIn.StartTime);
            Lesson lesson = new Lesson
            {
                Teacher = _repo.ReadUser(lessonIn.TeacherId) as Teacher,
                Group = _repo.ReadGroup(lessonIn.GroupName),
                Subject = lessonIn.Subject,
                Topic = lessonIn.Topic,
                Notes = lessonIn.Notes,
                StartTime = time,
                EndTime = time.AddMinutes(45)
            };
            _repo.CreateLesson(lesson);
            _repo.SaveChanges();
            return lesson;
        }
    }
}
using System.Collections;
using SchoolRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SchoolRegister.Database
{
    public class MainDbRepository
    {
        private readonly MainDbContext _context;

        public MainDbRepository(MainDbContext context)
        {
            _context = context;
        }

        public void CreateUsers(IEnumerable<User> users)
        {
            _context.Users.AddRange(users);
        }

        public User VerifyUser(string email, string passwordHash)
        {
            User user = _context.Users.Where(x => x.Email == email && x.Password == passwordHash).Single();
            return user;
        }

        public User ReadUser(int id)
        {
            User user = _context.Users.Where(x => x.Id == id).Single();
            return user;
        }

        public IEnumerable<Teacher> ReadTeachers()
        {
            var teachers = _context.Teacher;
            return teachers;
        }

        public IEnumerable<Student> ReadStudentsWithoutClass()
        {
            var students = _context.Students.Where(x => x.Group == null).AsEnumerable();
            return students;
        }
        public IEnumerable<Student> ReadStudentsByClass(string name)
        {
            var students = _context.Students.Where(x => x.Group.Name == name).AsEnumerable();
            return students;
        }

        public User UpdateUser(User user)
        {
            user = _context.Users.Update(user).Entity;
            return user;
        }

        public void CreateGroup(Group group)
        {
            _context.Groups.Add(group);
        }

        public Group UpdateGroup(Group group)
        {
            group = _context.Groups.Update(group).Entity;
            return group;
        }

        public Group ReadGroup(string name)
        {
            Group group = _context.Groups.Where(x => x.Name == name).Single();
            return group;
        }

        public IEnumerable<Student> ReadStudents(int[] ids)
        {
            var students = _context.Students.Where(x => ids.Contains(x.Id));
            return students;
        }

        public Lesson CreateLesson(Lesson lesson)
        {
            lesson = _context.Lessons.Add(lesson).Entity;
            return lesson;
        }

        public Lesson ReadLesson(int lessonId)
        {
            Lesson lesson = _context.Lessons.Where(x => x.Id == lessonId).Single();
            return lesson;
        }

        public Student ReadStudent(int id)
        {
            var student = _context.Students.Where(x => x.Id == id).Single();
            return student;
        }

        public IEnumerable<string> ReadAllGroups()
        {
            var groups = _context.Groups.Select(x => x.Name).AsEnumerable();
            return groups;
        }

        public IEnumerable<Lesson> ReadLessonsByClass(string name)
        {
            var lessons = _context.Lessons.Where(x => x.Group.Name == name).AsEnumerable();
            return lessons;
        }

        public IEnumerable<Lesson> ReadLessonsByTeacher(int id)
        {
            var lessons = _context.Lessons.Where(x => x.Teacher.Id == id).Include(x => x.Group).AsEnumerable();
            return lessons;
        }

        public IEnumerable<Lesson> ReadLessonsByStudent(int id)
        {
            var student = _context.Students.Where(x => x.Id == id).Include(x => x.Group).Single();
            var lessons = _context.Lessons.Where(x => x.Group.Name == student.Group.Name).Include(x => x.Group).AsEnumerable();
            return lessons;
        }

        public void CreateAttendance(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
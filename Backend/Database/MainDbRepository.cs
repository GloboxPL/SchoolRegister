using SchoolRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public User UpdateUser(User user)
        {
            user = _context.Users.Update(user).Entity;
            return user;
        }

        public Group CreateGroup(Group group)
        {
            group = _context.Groups.Add(group).Entity;
            return group;
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

        public void CreateAttendance(IEnumerable<Attendance> attendances)
        {
            _context.Attendances.AddRange(attendances);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
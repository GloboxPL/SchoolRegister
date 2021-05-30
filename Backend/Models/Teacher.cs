using System;
using System.Collections.Generic;

namespace SchoolRegister.Models
{
    public class Teacher : User
    {
        public virtual ICollection<Lesson> Lessons { get; set; } = new HashSet<Lesson>();

        public Teacher() : base() { }

        public Teacher(User user) : base(user)
        {
            Role = Role.Teacher;
        }

        public Teacher(string name, string surname, string email, string password)
        : base(name, surname, email, password, Role.Teacher) { }
    }
}
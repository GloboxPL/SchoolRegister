using System;
using System.Collections.Generic;

namespace SchoolRegister.Models
{
    public class Teacher : User
    {
        public Teacher() : base() { }

        public Teacher(string name, string surname, string email, string password)
        : base(name, surname, email, password, Role.Teacher) { }



        public ICollection<Lesson> Lessons { get; set; } = new HashSet<Lesson>();
    }
}
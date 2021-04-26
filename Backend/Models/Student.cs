using System;
using System.Collections.Generic;

namespace SchoolRegister.Models
{
    public class Student : User
    {
        public virtual ICollection<Parent> Parents { get; set; } = new HashSet<Parent>();
        public virtual ICollection<Group> Groups { get; set; } = new HashSet<Group>();

        public Student() : base() { }

        public Student(string name, string surname, string email, string password)
        : base(name, surname, email, password, Role.Student) { }
    }
}
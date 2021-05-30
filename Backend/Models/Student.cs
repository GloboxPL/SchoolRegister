using System;
using System.Collections.Generic;

namespace SchoolRegister.Models
{
    public class Student : User
    {
        public virtual ICollection<Parent> Parents { get; set; } = new HashSet<Parent>();
        public virtual Group Group { get; set; }

        public Student() : base() { }

        public Student(User user) : base(user)
        {
            Role = Role.Student;
        }

        public Student(string name, string surname, string email, string password)
        : base(name, surname, email, password, Role.Student) { }
    }
}
using System.Collections.Generic;

namespace SchoolRegister.Models
{
    public class Parent : User
    {
        public virtual ICollection<Student> Children { get; set; } = new HashSet<Student>();

        public Parent() { }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.Models
{
    public class Group
    {
        [Key()]
        public string Name { get; protected set; }
        public bool IsWholeClass { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public virtual ICollection<Lesson> Lessons { get; set; } = new HashSet<Lesson>();
        public virtual Teacher Teacher { get; set; }

        public Group() { }
    }
}
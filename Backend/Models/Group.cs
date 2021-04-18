using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.Models
{
    public class Group
    {
        [Key()]
        public string Name { get; protected set; }
        public bool IsWholeClass { get; set; } = true;
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        public virtual ICollection<Lesson> Lessons { get; set; } = new HashSet<Lesson>();
        public virtual Teacher Teacher { get; set; } = null;

        public Group() { }

        public Group(string name)
        {
            Name = name;
        }
    }

    public class GroupIn
    {
        public string Name { get; set; }
        public int[] Ids { get; set; }
    }
}
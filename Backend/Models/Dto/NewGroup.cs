using System.Collections.Generic;

namespace SchoolRegister.Models.Dto
{
    public class NewGroupDto
    {
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public IEnumerable<int> StudentsIds { get; set; }
    }
}
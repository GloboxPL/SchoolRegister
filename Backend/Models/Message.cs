using System.Collections.Generic;

namespace SchoolRegister.Models
{
    public class Message
    {
        public int Id { get; protected set; }
        public string Content { get; set; }
        public virtual User Sender { get; set; }
        public virtual ICollection<User> Recivers { get; set; } = new HashSet<User>();
        public virtual ICollection<Attachment> Attachments { get; set; } = new HashSet<Attachment>();
    }
}
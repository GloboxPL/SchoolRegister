namespace SchoolRegister.Models
{
    public class Attachment
    {
        public int Id { get; protected set; }
        public byte[] Content { get; set; }
        public string FileFormat { get; set; }
        public virtual Message Message { get; set; }
    }
}
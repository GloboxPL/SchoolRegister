namespace SchoolRegister.Models.Dto
{
    public class UserMinDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public UserMinDto(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Surname = user.Surname;
        }
    }
}
using System;
using System.Collections.Generic;
using SchoolRegister.Services;

namespace SchoolRegister.Models
{
    public class User
    {
        public int Id { get; protected set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        //public ICollection<Message> SendedMessages { get; set; } = new HashSet<Message>();
        //public ICollection<Message> RecivedMessages { get; set; } = new HashSet<Message>();

        public User() { }

        public User(string name, string surname, string email, string password, Role role)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = Argon2.Hash(password);
            Role = role;
        }

        protected User(User user)
        {
            Name = user.Name;
            Surname = user.Surname;
            Email = user.Email;
            Password = user.Password;
        }
    }

    public enum Role
    {
        Student,
        Parent,
        Teacher,
        Master,
        Admin
    }
}
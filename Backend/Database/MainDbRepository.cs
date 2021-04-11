using Microsoft.EntityFrameworkCore;
using SchoolRegister.Models;
using System;
using System.Linq;

namespace SchoolRegister.Database
{
    public class MainDbRepository
    {
        private readonly MainDbContext _context;

        public MainDbRepository(MainDbContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
        }

        public User ReadUser(string email, string passwordHash)
        {
            User user = _context.Users.Where(x => x.Email == email && x.PasswordHash == passwordHash).Single();
            return user;
        }

        public User ReadUser(Guid id)
        {
            User user = _context.Users.Where(x => x.Id == id).Single();
            return user;
        }

        public User UpdateUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
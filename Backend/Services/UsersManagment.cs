using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using SchoolRegister.Database;
using SchoolRegister.Models;

namespace SchoolRegister.Services
{
    public class UsersManagment
    {
        private readonly MainDbRepository _repo;

        public UsersManagment(MainDbContext context)
        {
            _repo = new MainDbRepository(context);
        }

        public ClaimsPrincipal Authorize(User userCredential)
        {
            string passwordHash = Argon2.Hash(userCredential.Password);
            User user = _repo.VerifyUser(userCredential.Email, passwordHash);
            if (user != null)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                return claimsPrincipal;
            }
            return null;
        }

        public void ChangePassword(User user, string newPassword)
        {
            string passwordHash = Argon2.Hash(newPassword);
            user.Password = passwordHash;
            _repo.UpdateUser(user);
            _repo.SaveChanges();
        }

        public IEnumerable<User> AddUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                if (user is Student)
                {
                    user.Role = Role.Student;
                }
                else if (user is Teacher)
                {
                    user.Role = Role.Teacher;
                }
                else if (user is Parent)
                {
                    user.Role = Role.Parent;
                }
            }
            if (IsValidUsers(users))
            {
                _repo.CreateUsers(users);
                _repo.SaveChanges();
                return users;
            }
            else
            {
                throw new DataMisalignedException("Invalid data");
            }

        }

        public User GetUserByAuthData(ClaimsPrincipal user)
        {
            int id = Int32.Parse(user.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            return _repo.ReadUser(id);
        }
        private bool IsValidUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                if (user.Name == null || user.Surname == null || user.Email == null || user.Password == null)
                {
                    return false;
                }
            }
            return true;
        }

        public void AddSeedUsers()
        {
            var users = new User[]{
                new User("Jacek","Adamus","jacek@gmail.com","jacek",Role.Admin)//,
                /* new Teacher("Piotr","Nowak","nowak@gmail.com","piotr"),
                new Student("Michał","Kowalski","mike@gmail.com","michal"), */
            };
            _repo.CreateUsers(users);
            _repo.SaveChanges();
        }
    }
}
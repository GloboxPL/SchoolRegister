using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using SchoolRegister.Database;
using SchoolRegister.Models;
using SchoolRegister.Models.Dto;

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
            List<User> concreteUsers = new List<User>();
            foreach (var user in users)
            {
                user.Password = Argon2.Hash("pass");
                if (user.Role == Role.Student)
                {
                    concreteUsers.Add(new Student(user));
                }
                else if (user.Role == Role.Teacher)
                {
                    concreteUsers.Add(new Teacher(user));
                }
                else if (user.Role == Role.Parent)
                {
                    concreteUsers.Add(new Parent(user));
                }
            }
            if (IsValidUsers(users))
            {
                _repo.CreateUsers(concreteUsers);
                _repo.SaveChanges();
                return users;
            }
            else
            {
                throw new DataMisalignedException("Invalid data");
            }

        }

        public User GetUserByAuthData(ClaimsPrincipal claim)
        {
            int id = Int32.Parse(claim.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            User user = _repo.ReadUser(id);
            user.Password = String.Empty;
            return user;
        }

        public IEnumerable<UserMinDto> GetTeachers()
        {
            var teachers = _repo.ReadTeachers();
            return teachers.Select(x => new UserMinDto(x));
        }

        public IEnumerable<UserMinDto> GetStudentsWithoutClass()
        {
            var students = _repo.ReadStudentsWithoutClass();
            return students.Select(x => new UserMinDto(x));
        }

        private bool IsValidUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                if (user.Name == null || user.Surname == null || user.Email == null)
                {
                    return false;
                }
            }
            return true;
        }

        public void AddSeedUsers()
        {
            var users = new User[]{
                new User("Jacek","Adamus","admin@mail.com","pass",Role.Admin)
            };
            _repo.CreateUsers(users);
            _repo.SaveChanges();
        }
    }
}
using System.Collections.Generic;
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

        public ClaimsPrincipal Authorize(Credential credential)
        {
            string passwordHash = Argon2.Hash(credential.Password);
            User user = _repo.ReadUser(credential.Email, passwordHash);
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

        public void AddSeedUsers()
        {
            var users = new User[]{
                new User("Jacek","Adamus","jacek@gmail.com","jacek",Role.Admin),
                new Teacher("Piotr","Nowak","nowak@gmail.com","piotr"),
                new Student("Michał","Kowalski","mike@gmail.com","michal"),
            };
            foreach (var user in users)
            {
                _repo.CreateUser(user);
            }
            _repo.SaveChanges();
        }
    }
}
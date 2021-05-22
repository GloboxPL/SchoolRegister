using System;
using System.Text;
using Konscious.Security.Cryptography;

namespace SchoolRegister.Services
{
    public static class Argon2
    {
        private static readonly byte[] saltBytes = { 1, 2, 3, 4, 5 };
        public static string Hash(string password)
        {
            return password;
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            var argon = new Argon2id(passwordBytes);
            argon.DegreeOfParallelism = 16;
            argon.MemorySize = 8192;
            argon.Iterations = 40;
            argon.Salt = saltBytes;
            var hashBytes = argon.GetBytes(128);
            var hash = Convert.ToBase64String(hashBytes);
            return hash;
        }
    }
}
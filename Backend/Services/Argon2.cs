using System.Text;
using Konscious.Security.Cryptography;

namespace SchoolRegister.Services
{
    public static class Argon2
    {
        public static string Hash(string password)
        {
            byte[] saltBytes = { 1, 2, 3, 4, 5 };
            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
            var argon = new Argon2id(passwordBytes);
            argon.DegreeOfParallelism = 16;
            argon.MemorySize = 8192;
            argon.Iterations = 40;
            argon.Salt = saltBytes;
            var hashBytes = argon.GetBytes(128);
            var hash = Encoding.ASCII.GetString(hashBytes);
            return hash;
        }
    }
}
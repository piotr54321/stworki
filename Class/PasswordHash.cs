using System;
using System.Text;
using System.Security.Cryptography;

namespace Projekt.Class
{
    class PasswordHash
    {
        public string GetHash(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hash = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hash;
        }
    }
}

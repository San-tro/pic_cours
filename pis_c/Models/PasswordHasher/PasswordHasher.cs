using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace Parties.Models.PasswordHasher
{
    public class PasswordHasher : IPasswordHasher
    {
        public string GetHash(string password)
        {
            return GetMd5Hash(password);
        }

        public bool IsMatch(string password, string hash)
        {
            return GetMd5Hash(password).Equals(hash);
        }

        private string GetMd5Hash(string str)
        {
            var hasher = MD5.Create();
            var hashed = hasher.ComputeHash(Encoding.Default.GetBytes(str));

            var stringBuilder = new StringBuilder();

            foreach (var el in hashed)
                stringBuilder.Append(el.ToString("x2"));

            return stringBuilder.ToString();
        }
    }
}
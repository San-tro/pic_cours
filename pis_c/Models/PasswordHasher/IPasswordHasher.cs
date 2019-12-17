using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parties.Models.PasswordHasher
{
    public interface IPasswordHasher
    {
        string GetHash(string pasword);
        bool IsMatch(string password, string hash);
    }
}
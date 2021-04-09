using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec2021.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "TestApp"; // издатель токена
        public const string AUDIENCE = "TestAppClient"; // потребитель токена
        const string KEY = "sdlfnadnfjkuuooknshucwx";   // ключ для шифрации
        public const int LIFETIME = 100; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

    }
}

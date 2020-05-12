using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Mov4e
{
    public static class Hash
    {
        public static string HashPassword(string pass)
        {

            byte[] salt = new byte[16];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            byte[] hashedPass;
            using (var hasher = new Rfc2898DeriveBytes(pass, salt, 1000))
            {
                hashedPass = hasher.GetBytes(20);
            }

            byte[] saltyHashedPassword = new byte[36];
            Array.Copy(hashedPass, 0, saltyHashedPassword, 0, 20);
            Array.Copy(salt, 0, saltyHashedPassword, 20, 16);

            string hasedPass = null;
            hasedPass = Convert.ToBase64String(saltyHashedPassword);

            return hasedPass;

        }

        public static bool CompareHashedPasswords(string DBpass, string InsertedPass)
        {
            byte[] hashbytes = Convert.FromBase64String(DBpass);
            byte[] saltExtracted = new byte[16];
            Array.Copy(hashbytes, 20, saltExtracted, 0, 16);

            string insertedPassword = InsertedPass;
            var loginHasher = new Rfc2898DeriveBytes(insertedPassword, saltExtracted, 1000);
            byte[] hashExtracted = loginHasher.GetBytes(20);
            bool flag = false;

            for (int i = 0; i < 20; i++)
            {
                if (hashbytes[i] != hashExtracted[i])
                {
                    flag = true;
                }
            }
            return flag;
        }
    }
}

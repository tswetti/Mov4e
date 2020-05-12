using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mov4e.Hash;
using Mov4e.Exceptions;

namespace Mov4e.Validation
{
     public static class ValidateLogIn
    {
        /// <summary>
        /// This method checks if the loggin info is correct.
        /// </summary>
        /// <param name="userView"></param>
        /// <param name="userFromDB"></param>
        public static void isLoginInformatinOk(string viewPass, string pass)
        {        
            if (CompareHashedPasswords(pass, viewPass) == true)
            {
                throw new LogInException("Wrong Password!");
            }
        }

        /// <summary>
        /// checks if user exists in DB
        /// </summary>
        /// <param name="exists"></param>
        public static void userExists(bool exists)
        {
            if (exists == false)
            {
                throw new LogInException("No such User!");
            }
        }
    }
}

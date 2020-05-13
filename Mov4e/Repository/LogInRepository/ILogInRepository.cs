using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Model;

namespace Mov4e.Repository.LogInRepository
{
    public interface ILogInRepository
    {
        /// <summary>
        /// This method gets info for the user (if exists)
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        string GetPasswordForUser(string username);

        /// <summary>
        /// This method gets user's id by its username (if there is such user).
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        int GetCurrentUserID(string username);

        /// <summary>
        /// checks if the user exists in DB
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        bool checkIfUserIsInDB(string username);

        /// <summary>
        /// This method returns the position of the user. It uses username to find it;
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        string GetCurrentUserPosition(string userName);
    }
}

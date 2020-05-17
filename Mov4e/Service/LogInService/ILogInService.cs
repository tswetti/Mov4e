using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4e.Service.LogInService
{
    public interface ILogInService
    {
        /// <summary>
        /// This method saves password and username in model of type User(it will be used for comaprison)
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        void SaveDataFromView(string username, string password);

        /// <summary>
        /// This method checks if the login is correct
        /// </summary>
        /// <returns></returns>
        bool CorrectLogin();

        /// <summary>
        /// This method returns logged user Id
        /// </summary>
        /// <returns></returns>
        int GetIDLoggedUser();

        /// <summary>
        /// This method returns the position of the user;
        /// </summary>
        /// <returns></returns>
        string GetPosition();

        /// <summary>
        /// This method creates new password. It uses username to find user and email to verify if this is the user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        void CreateNewPass(string username, string email);
    }
}

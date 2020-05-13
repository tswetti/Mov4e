using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Model;

namespace Mov4e.Repository.ProfileScreenRepository
{
    public interface IProfileSettingsRepository
    {
        /// <summary>
        /// Returns User by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUserFromDB(int id);

        /// <summary>
        /// Returns Info about the user by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserInfo GetDataForThisUser(int id);

        /// <summary>
        /// Changes the mail of logged user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Mail"></param>
        void ChangeMail(int id, string Mail);

        /// <summary>
        /// Returns collection of E-Mails. It is normal used in validation.
        /// </summary>
        /// <returns></returns>
        ICollection<string> GetListOfEMails();

        /// <summary>
        /// This method changes the age of logged user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="age"></param>
        void ChangeAge(int id, int age);

        /// <summary>
        /// This method changes the gender of logged user. WTF m8??? Why I have implemented this???
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gender"></param>
        void ChangeGender(int id, string gender);

        /// <summary>
        /// This method changes the password of current user that is logged.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newPass"></param>
        void ChangePassword(int id, string newPass);

        /// <summary>
        /// This method returns collection of UserNames. It is normal used in validation.
        /// </summary>
        /// <returns></returns>
        ICollection<string> GetListOfUserNames();

        /// <summary>
        /// This method changes the UserName of logged user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userName"></param>
        void ChangeUserName(int id, string userName);

        /// <summary>
        /// This method changes the first name of logged user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        void ChangeFirstName(int id, string firstName);

        /// <summary>
        /// This method changes the last name of logged user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lastName"></param>
        void ChangeLastName(int id, string lastName);

    }
}

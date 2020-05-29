using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Service.ProfileScreenService;
using Mov4e.View.ProfileScreenView;

namespace Mov4e.Presenter.ProfileScreenPresenter
{
    public class SettingsPresenter : ISettingsPresenter
    {
        IProfileScreenSettingsService _profileScreenService;
        IProfileScreen _profileScreen;

        public SettingsPresenter(IProfileScreen _profileS)
        {
            _profileScreenService = new ProfileScreenSettingsService();
            _profileScreen=_profileS;
        }

        //for tests
        public SettingsPresenter(IProfileScreen _profileS, IProfileScreenSettingsService _profileService)
        {
            _profileScreenService = _profileService;
            _profileScreen = _profileS;
        }

        /// <summary>
        /// This method changes the e-mail of the user.
        /// </summary>
        /// <param name="NewMail"></param>
        public void ChangeEmail(string NewMail)
        {
            try
            {
                _profileScreenService.UpdateMail(NewMail);
                _profileScreen.Email = NewMail;              
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _profileScreen.ErrorMessage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);
          
            }
        }

        /// <summary>
        /// This method changes the age of the user.
        /// </summary>
        /// <param name="Age"></param>
        public void ChangeAge(int Age)
        {
            try
            {
                _profileScreenService.UpdateAge(Age);
                _profileScreen.Age = Age;
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _profileScreen.ErrorMessage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);
         
            }
        }

        /// <summary>
        /// This method changes the gender of the user.
        /// </summary>
        /// <param name="gender"></param>
        public void ChangeGender(string gender)
        {
            try
            {
                _profileScreenService.UpdateGender(gender);
                _profileScreen.Gender = gender;
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _profileScreen.ErrorMessage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);

            }
        }

        /// <summary>
        /// This method changes the passowrd of the user.
        /// </summary>
        /// <param name="oldPass"></param>
        /// <param name="newPass"></param>
        public void ChangePassword(string oldPass, string newPass,string repeatedPass)
        {
            try
            {
                _profileScreenService.UpdatePassword(oldPass, newPass,repeatedPass);
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                throw;
            }
        }

        /// <summary>
        /// This method changes the user name of the user.
        /// </summary>
        /// <param name="userName"></param>
        public void ChangeUserName(string userName)
        {
            try
            {
                _profileScreenService.UpdateUserName(userName);
                _profileScreen.UserName = userName;
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _profileScreen.ErrorMessage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);
            }
        }

        /// <summary>
        /// This method changes the first name of the user.
        /// </summary>
        /// <param name="firstName"></param>
        public void ChangeFirstName(string firstName)
        {
            try
            {
                _profileScreenService.UpdateFirstName(firstName);
                _profileScreen.FirstName = firstName;
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _profileScreen.ErrorMessage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);

            }
        }

        /// <summary>
        /// This method changes the last name of the user.
        /// </summary>
        /// <param name="lastName"></param>
        public void ChangeLastName(string lastName)
        {
            try
            {
                _profileScreenService.UpdateLastName(lastName);
                _profileScreen.LastName = lastName;
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _profileScreen.ErrorMessage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);
            }
        }
    }
}

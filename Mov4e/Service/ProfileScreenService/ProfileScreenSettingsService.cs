using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Repository.ProfileScreenRepository;
using static Mov4e.Hash;
using static Mov4e.Validation.ValidateProfile;
using Mov4e.Exceptions;
using System.Net.Mail;
using System.Net;

namespace Mov4e.Service.ProfileScreenService
{
    public class ProfileScreenSettingsService : IProfileScreenSettingsService
    {
        private IProfileSettingsRepository _profileScreeenSettings;
        private User CurrentUser = new User();
        private UserInfo CurrentUserInfo = new UserInfo();

        public ProfileScreenSettingsService()
        {
            _profileScreeenSettings = new ProfileSettingsRepository();
            CurrentUser= _profileScreeenSettings.GetUserFromDB(Properties.Settings.Default.id);
            CurrentUserInfo=_profileScreeenSettings.GetDataForThisUser(Properties.Settings.Default.id);
        }

        //for tests
        public ProfileScreenSettingsService(IProfileSettingsRepository _profileSettings)
        {
            _profileScreeenSettings = _profileSettings;
            CurrentUser = _profileScreeenSettings.GetUserFromDB(Properties.Settings.Default.id);
            CurrentUserInfo = _profileScreeenSettings.GetDataForThisUser(Properties.Settings.Default.id);
        }

        public void UpdateMail(string Mail)
        {
            try
            {
                isEMailTaken(_profileScreeenSettings.GetListOfEMails(), Mail);
                isEMailCorrect(Mail);
                _profileScreeenSettings.ChangeMail(this.CurrentUser.id, Mail);
                CurrentUserInfo.email = Mail;

                this.SendMessage(CurrentUserInfo.email, "Hello " + CurrentUser.userName + "! You have changed your e-mail successfully!");
            }
            catch (IncorrectUserDataException)
            {
                throw;
            }
        }
        public void UpdateAge(int Age)
        {
            try
            {
                isAgeValid(Age);
                _profileScreeenSettings.ChangeAge(this.CurrentUser.id, Age);
                CurrentUserInfo.age = Age;
            }
            catch (IncorrectUserDataException)
            {
                throw;
            }
        }

        public void UpdateGender(string gender)
        {
            try
            {
                isGenderValid(gender);
                _profileScreeenSettings.ChangeGender(this.CurrentUser.id, gender);
                CurrentUserInfo.gender = gender;
            }
            catch (IncorrectUserDataException)
            {
                throw;
            }
        }



        public void UpdatePassword(string oldPass, string newPass, string repeatedPass)
        {
            try
            {
                areNewPassAndRepeatedSame(newPass, repeatedPass);
                arePasswordsSame(CurrentUser.password, oldPass);
                isPasswordCorrect(newPass);
                _profileScreeenSettings.ChangePassword(Properties.Settings.Default.id, HashPassword(newPass));
                CurrentUser.password = newPass;

                this.SendMessage(CurrentUserInfo.email, "Hello " + CurrentUser.userName + "! You have changed your password successfully!");
            }
            catch (IncorrectUserDataException)
            {
                throw;
            }
        }

        public void UpdateUserName(string userName)
        {
            try
            {
                isUserNameTaken(_profileScreeenSettings.GetListOfUserNames(), userName);
                isUserNameValid(userName);
                _profileScreeenSettings.ChangeUserName(this.CurrentUser.id, userName);
                CurrentUser.userName = userName;

                this.SendMessage(CurrentUserInfo.email, "Hello " + CurrentUser.userName + "! You have changed your username successfully!");
            }
            catch (IncorrectUserDataException)
            {
                throw;
            }

        }

        public void UpdateFirstName(string firstName)
        {
            try
            {
                areFirstAndLastNameValid(firstName, CurrentUserInfo.lastName);
                _profileScreeenSettings.ChangeFirstName(this.CurrentUser.id, firstName);
                CurrentUserInfo.firstName = firstName;
            }
            catch (IncorrectUserDataException)
            {
                throw new IncorrectUserDataException("Incorrect First name!");
            }
        }

        public void UpdateLastName(string lastName)
        {
            try
            {
                areFirstAndLastNameValid(CurrentUserInfo.firstName, lastName);
                _profileScreeenSettings.ChangeLastName(this.CurrentUser.id, lastName);
                CurrentUserInfo.lastName = lastName;
            }
            catch (IncorrectUserDataException)
            {
                throw new IncorrectUserDataException("Incorrect Last name!");
            }
        }

        private void SendMessage(string email, string messg)
        {
            //wrushta mail i na men holp plz???
            MailAddress from = new MailAddress("testprojectss31@gmail.com", "Mov4e Team");
            MailAddress to = new MailAddress(CurrentUserInfo.email, CurrentUserInfo.firstName + " " + CurrentUserInfo.lastName);
            MailMessage message = new MailMessage(from, to);

            message.Subject = "Registered";
            string mess = messg;
            message.Body = mess;

            SmtpClient client = new SmtpClient();

            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("testprojectss31@gmail.com", "feoaxemcqtvjoseh");

            try
            {
                client.SendAsync(message, null);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

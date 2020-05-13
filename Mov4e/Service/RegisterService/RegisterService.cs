using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Repository.RegisterRepository;
using static Mov4e.Hash;
using static Mov4e.Validation.ValidateRegister;
using Mov4e.Exceptions;
using System.Net.Mail;
using System.Net;
using Mov4e.Model;

namespace Mov4e.Service.RegisterService
{
    public class RegisterService : IRegisterService
    {
        private IRegisterRepository _registerRepozitory;
        private User newUser = new User();
        private UserInfo newUserInfo = new UserInfo();

        public RegisterService()
        {
            _registerRepozitory = new RegisterRepository();
        }

        //for tests
        public RegisterService(IRegisterRepository _regRepo)
        {
            _registerRepozitory = _regRepo;

        }

        private void SaveUserAndInfoInDB(User newUser, UserInfo newUserInfo)
        {
            _registerRepozitory.SaveUser(newUser, newUserInfo);
        }

        public void SaveUser(string userName, string password)
        {
            //Validate username
            try
            {
                isUserNameTaken(_registerRepozitory.GetListOfUserNames(), userName);
                isUserNameValid(userName);
                newUser.userName = userName;
            }
            catch (IncorrectUserDataException)
            {
                throw;
            }

            //Validate password
            try
            {
                isPasswordCorrect(password);
                newUser.password = HashPassword(password);
            }
            catch (IncorrectUserDataException)
            {
                throw;
            }
        }

        private void SaveFirstAndLastName(string firstName,string lastName)
        {
            try
            {
                areFirstAndLastNameValid(firstName, lastName);
                newUserInfo.firstName = firstName;
                newUserInfo.lastName = lastName;
            }
            catch (IncorrectUserDataException)
            {
                throw;
            }
        }

        private void SaveEmail(string email)
        {
            try
            {
                isEMailTaken(_registerRepozitory.GetListOfEMails(), email);
                isEMailCorrect(email);
                newUserInfo.email = email;
            }
            catch (IncorrectUserDataException)
            {
                throw;
            }
        }

        private void SaveGender(string gender)
        {
            try
            {
                isGenderValid(gender);
                newUserInfo.gender = gender;
            }
            catch (IncorrectUserDataException)
            {
                throw;
            }
        }

        private void SaveAge(int age)
        {
            try
            {
                isAgeValid(age);
                newUserInfo.age = age;
            }
            catch (IncorrectUserDataException)
            {
                throw;
            }
        }
        public void SaveUserInfo(string firstName, string lastName, string email, string gender, int age)
        {
            //Validate First and Last name
            this.SaveFirstAndLastName(firstName, lastName);

            //Validate E-mail
            this.SaveEmail(email);

            //Validate gender
            this.SaveGender(gender);

            //Validate age
            this.SaveAge(age);

            newUserInfo.position = "normal";
            newUserInfo.picture =(byte[])(new System.Drawing.ImageConverter()).ConvertTo(Properties.Resources.Default_profile_pic, typeof(byte[]));
        }

        public void SaveDataInDB()
        {
            newUserInfo.user = newUser;
            newUser.user_info = newUserInfo;
            this.SaveUserAndInfoInDB(newUser, newUserInfo);
            this.SendMessage(newUserInfo.email);
        }

        private void SendMessage(string email)
        {
            //wrushta mail i na men holp plz???
            MailAddress from = new MailAddress("testprojectss31@gmail.com", "Mov4e Team");
            MailAddress to = new MailAddress(newUserInfo.email, newUserInfo.firstName+" "+newUserInfo.lastName);
            MailMessage message = new MailMessage(from, to);
            
            message.Subject = "Registered";
            string mess = "Hello " + newUser.userName + " you have successfully registered in our app!" + Environment.NewLine + "If you have any questions please do not hesitate to contact us!" + Environment.NewLine + Environment.NewLine + " From: Mov4e Team";
            message.Body = mess;

            SmtpClient client = new SmtpClient();
                
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("testprojectss31@gmail.com", "feoaxemcqtvjoseh");

            try
            {
                client.SendAsync(message,null);
            }
            catch (Exception)
            {
                throw;
            }
        } 
    }
}

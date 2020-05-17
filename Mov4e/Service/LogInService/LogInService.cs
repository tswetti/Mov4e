using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Repository.LogInRepository;
using static Mov4e.Hash;
using System.Security.Cryptography;
using Mov4e.Exceptions;
using static Mov4e.Validation.ValidateLogIn;
using Mov4e.Model;
using System.Net.Mail;
using System.Net;

namespace Mov4e.Service.LogInService
{
    public class LogInService:ILogInService
    {
        private ILogInRepository _loginRepozitory;
        private string password = null;
        private User UserViewData = new User();

        public User GetUser()
        {
            return UserViewData;
        }
        public LogInService()
        {
            _loginRepozitory = new LogInRepository();
        }

        //Only For Tests
        public LogInService(ILogInRepository _logInRepo)
        {
            _loginRepozitory = _logInRepo;
        }

        public void SaveDataFromView(string username, string password)
        {
            UserViewData.userName = username;
            UserViewData.password = password;
        }
        //metod na servica vikasht metod na repoto
        private void GetUserPassFromDB()
        {
           password = _loginRepozitory.GetPasswordForUser(UserViewData.userName);  
        }

        public int GetIDLoggedUser()
        {
            return _loginRepozitory.GetCurrentUserID(UserViewData.userName);
        }

        public bool CorrectLogin()
        {
            try
            {
                userExists(_loginRepozitory.checkIfUserIsInDB(UserViewData.userName));
                this.GetUserPassFromDB();
                isLoginInformatinOk(UserViewData.password, password);
                return true;
            }
            
            catch (LogInException)
            {
                throw;           
            }
            
        }

        public string GetPosition()
        {
            return _loginRepozitory.GetCurrentUserPosition(UserViewData.userName);
        }

        public void CreateNewPass(string username, string email)
        {
            try
            {
                userExists(_loginRepozitory.checkIfUserIsInDB(username));
                compareEmails(_loginRepozitory.GetEmailForUser(username), email);
                string newPass = this.PassGenerator();
                Validation.ValidateRegister.isPasswordCorrect(newPass);
                _loginRepozitory.UpdatePass(username, HashPassword(newPass));
                this.SendMessage(email, username, _loginRepozitory.GetUserFullName(username), newPass);

            }
            catch (LogInException)
            {
                throw;
            }
        }

        private string PassGenerator()
        {
            string lowers = "abcdefghijklmnopqrstuvwxyz";
            string uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string number = "0123456789";
            string symbols = "!@#%^&*/,!?~=)(=+-|_";
            string pass = null;

            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[16];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            pass = Convert.ToBase64String(randomBytes);
           
            Random r = new Random();

            for (int i = 0; i < 3; i++)
            {
                pass += lowers[r.Next(0, lowers.Length)];
                pass += uppers[r.Next(0, uppers.Length)];
                pass += number[r.Next(0, number.Length)];
                pass += symbols[r.Next(0, symbols.Length)];
            }

            return pass;
        }

        private void SendMessage(string email, string username, string name, string pass)
        {
            //wrushta mail i na men holp plz???
            MailAddress from = new MailAddress("testprojectss31@gmail.com", "Mov4e Team");
            MailAddress to = new MailAddress(email,name);
            MailMessage message = new MailMessage(from, to);

            message.Subject = "Reset Password";
            string mess = "Hello " + username + "! You have successfully reset your password!" + 
                           Environment.NewLine +"Your new password is: "+pass+
                           Environment.NewLine+ "For your safety we recommend changing it after logging in!" +
                           Environment.NewLine + Environment.NewLine + " From: Mov4e Team";
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

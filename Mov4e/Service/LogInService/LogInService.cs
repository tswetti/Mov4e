using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Repository.LogInRepository;
using static Mov4e.Hash;
using Mov4e.Exceptions;
using static Mov4e.Validation.ValidateLogIn;

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.View.LogInView;
using Mov4e.Service.LogInService;

namespace Mov4e.Presenter.LogInPresenter
{
    public class LogInPresenter : ILogInPresenter
    {
        private ILogIn _login;
        private ILogInService _logInService;

        public LogInPresenter(ILogIn loginView)
        {
            _login = loginView;
            _logInService = new LogInService();
        }

        //For tests
        public LogInPresenter(ILogInService _loginServ,bool stay)
        {
            _logInService = _loginServ;
            _login = new mov4eLogin();
            _login.Stay = stay;
        }


        /// <summary>
        /// This method loggs user and sends it's id to the next form
        /// </summary>
        public void LogUser()
        {
            _logInService.SaveDataFromView(_login.UserName, _login.Password);

            try
            {

                if (_logInService.CorrectLogin() == true)
                {
                    if (_login.Stay == true)
                    {
                        Properties.Settings.Default.id = _logInService.GetIDLoggedUser();
                        Properties.Settings.Default.userPosition = _logInService.GetPosition();
                        Properties.Settings.Default.Logged = true;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.id = _logInService.GetIDLoggedUser();
                        Properties.Settings.Default.userPosition = _logInService.GetPosition();
                        Properties.Settings.Default.Logged = false;
                        Properties.Settings.Default.LoggedForOneTime = true;
                        Properties.Settings.Default.Save();
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _login.ErrorMassage(e.Message);
            }
        }
    }
}

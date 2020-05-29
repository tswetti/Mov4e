using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.View.RegisterView;
using Mov4e.Service.RegisterService;

namespace Mov4e.Presenter.RegisterPresenter
{
    public class RegisterPresenter : IRegisterPresenter
    {
        IRegister _register;
        IRegisterService _registerService;

        public RegisterPresenter(IRegister registerView)
        {
            _register = registerView;
            _registerService = new RegisterService();
        }

        //for Tests
        public RegisterPresenter(IRegister registerView, IRegisterService _regService)
        {
            _register = registerView;
            _registerService = _regService;
        }
        /// <summary>
        /// This method registers user
        /// </summary>
        /// <returns></returns>
        public bool RegisterUser()
        {
            try
            {
                _registerService.SaveUser(_register.UserName, _register.Password);
                _registerService.SaveUserInfo(_register.FirstName, _register.LastName, _register.Email, _register.Gender, _register.Age);
                _registerService.SaveDataInDB();
                return true;

            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _register.ErrorMessage("In the application sprang up an error! Please, check errors.txt file for more information!\n"+e.Message);
                return false;
            }
        }

    }
}

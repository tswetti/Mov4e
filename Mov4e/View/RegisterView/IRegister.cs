using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4e.View.RegisterView
{
    public interface IRegister
    {
        string UserName { get; set; }

        string Password { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string Email { get; set; }

        string Gender { get; set; }

        int Age { get; set; }

        /// <summary>
        /// This method displays MessageBox with the error
        /// </summary>
        /// <param name="msg"></param>
        void ErrorMassage(string msg);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4e.View.LogInView
{
    public interface ILogIn
    {
        string UserName { get; set; }

        string Password { get; set; }

        bool Stay { get; set; }

        void HideScreen();

        void ErrorMassage(string msg);
    }
}

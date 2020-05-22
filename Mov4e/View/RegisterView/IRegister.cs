using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4e.View.RegisterView
{
    public interface IRegister:IScreenView
    {
        string UserName { get; set; }

        string Password { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string Email { get; set; }

        string Gender { get; set; }

        int Age { get; set; }


    }
}

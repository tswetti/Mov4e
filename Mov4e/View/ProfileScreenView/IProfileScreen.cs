using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4e.View.ProfileScreenView
{
     public interface IProfileScreen: IScreenView
    {   
        int id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string Email { get; set; }

        string Gender { get; set; }

        int Age { get; set; }

        byte[] Picture { get; set; }

        string UserName { get; set; }

        Dictionary<int, byte[]> watchList { get; set; }

        void ErrorMassage(string msg);

        void UpdateEmail();

        void UpdateBirthYear();

        void UpdateGender();

        void UpdateUserName();

        void UpdateFirstNmae();

        void UpdateLastNmae();

    }
}

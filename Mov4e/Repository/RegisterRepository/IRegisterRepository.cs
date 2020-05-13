using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Model;

namespace Mov4e.Repository.RegisterRepository
{
    public interface IRegisterRepository
    {
        /// <summary>
        /// This method saves user and it's info in DB
        /// </summary>
        /// <param name="newUser"></param>
        /// <param name="newUserInfo"></param>
        void SaveUser(User newUser, UserInfo newUserInfo);

        /// <summary>
        /// This method returns list of UserNames. It is commonly used in validation
        /// </summary>
        /// <returns></returns>
        ICollection<string> GetListOfUserNames();

        /// <summary>
        /// This method returns list of E-mails. It is commonly used in validation
        /// </summary>
        /// <returns></returns>
        ICollection<string> GetListOfEMails();
    }
}

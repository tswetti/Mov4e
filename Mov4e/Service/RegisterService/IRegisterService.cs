using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4e.Service.RegisterService
{
    public interface IRegisterService
    {
       /// <summary>
       /// This method saves user(password and username) in model(which is in the service) of type User
       /// </summary>
       /// <param name="UserName"></param>
       /// <param name="Password"></param>
       void SaveUser(string UserName, string Password);

       /// <summary>
       /// This method saves information for user in model(which is in the service) of type UseerInfo
       /// </summary>
       /// <param name="FirstName"></param>
       /// <param name="LastName"></param>
       /// <param name="Email"></param>
       /// <param name="Gender"></param>
       /// <param name="Age"></param>
       void SaveUserInfo(string FirstName, string LastName, string Email, string Gender, int Age);

       /// <summary>
       /// This method sends user and it's userinfo(the models) to the method from repository(which saves them in DB)
       /// </summary>
       void SaveDataInDB();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Model;

namespace Mov4e.Repository.LogInRepository
{
    class LogInRepository:ILogInRepository
    {
        public string GetPasswordForUser(string username)
        {
            using (var r = new mov4eEntities())
            {
                string password = r.Users.Where(c => c.userName == username).FirstOrDefault().password;

                return password;                                            
            }
        }

        public bool checkIfUserIsInDB(string username)
        {
            using (var r = new mov4eEntities())
            {
                return r.Users.Any(u => u.userName == username);
            }
        }

        public int GetCurrentUserID(string username)
        {
            using (var r = new mov4eEntities())
            {
                int ID = r.Users.Where(c => c.userName == username).FirstOrDefault().id;

                return ID;
            }
        }
        public string GetCurrentUserPosition(string username)
        {
            using (var r = new mov4eEntities())
            {
                string position = r.Users.Where(c => c.userName == username).FirstOrDefault().user_info.position;

                return position;
            }
        }
    }
}

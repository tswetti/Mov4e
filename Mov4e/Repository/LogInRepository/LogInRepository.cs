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
            using (mov4eEntities context = new mov4eEntities())
            {
                string password = context.Users.Where(c => c.userName == username).FirstOrDefault().password;

                return password;                                            
            }
        }

        public bool checkIfUserIsInDB(string username)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                return context.Users.Any(u => u.userName == username);
            }
        }

        public int GetCurrentUserID(string username)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                int ID = context.Users.Where(c => c.userName == username).FirstOrDefault().id;

                return ID;
            }
        }
        public string GetCurrentUserPosition(string username)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                string position = context.Users.Where(c => c.userName == username).FirstOrDefault().user_info.position;

                return position;
            }
        }

        public string GetEmailForUser(string userName)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                string email = context.Users.Where(c => c.userName == userName).Single().user_info.email.ToString();

                return email;
            }
        }

        public void UpdatePass(string userName,string newPass)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                context.Users.Where(u => u.userName == userName).Single().password = newPass;
                context.SaveChanges();
            }
        }

        public string GetUserFullName(string username)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                string name = context.Users.Where(u => u.userName == username).Single().user_info.firstName.ToString() + " " +
                              context.Users.Where(u => u.userName == username).Single().user_info.lastName.ToString();

                return name;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Model;

namespace Mov4e.Repository.RegisterRepository
{
    class RegisterRepository:IRegisterRepository
    {
       
        public void SaveUser(User newUser, UserInfo newUserInfo)
        {
            using (var context = new mov4eEntities())
            {
                context.Users.Add(newUser);
                context.UserInfoes.Add(newUserInfo);
                context.SaveChanges();
            }
        }
        
        public ICollection<string> GetListOfUserNames()
        {
            using (var context = new mov4eEntities())
            {
                var usernames= from us in context.Users
                             select us.userName;

                return usernames.ToList();
            }
        }

        public ICollection<string> GetListOfEMails()
        {
            using (var context = new mov4eEntities())
            {
                var emails = from us_i in context.UserInfoes
                                select us_i.email;

                return emails.ToList();
            }
        }
    }
}

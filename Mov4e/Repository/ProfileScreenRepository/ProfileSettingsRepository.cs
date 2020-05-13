using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Model;

namespace Mov4e.Repository.ProfileScreenRepository
{
    public class ProfileSettingsRepository:IProfileSettingsRepository
    {
        public User GetUserFromDB(int id)
        {
            using (var context = new mov4eEntities())
            {
                var query = from us in context.Users
                            where us.id == id
                            select us;

                return query.First<User>();
            }
        }

        public UserInfo GetDataForThisUser(int id)
        {
            using (var context = new mov4eEntities())
            {
                var query = from us_info in context.UserInfoes
                            where us_info.id == id
                            select us_info;

                return query.First<UserInfo>();
            }
        }

        public void ChangeMail(int id, string Mail)
        {
            using (var context = new mov4eEntities())
            {
                UserInfo CurrentUserInfo = context.UserInfoes.First(uf => uf.id.Equals(id));
                CurrentUserInfo.email = Mail;
                context.SaveChanges();
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

        public void ChangeAge(int id, int age)
        {
            using (var context = new mov4eEntities())
            {
                UserInfo CurrentUserInfo = context.UserInfoes.First(uf => uf.id.Equals(id));
                CurrentUserInfo.age = age;
                context.SaveChanges();
            }
        }

        public void ChangeGender(int id, string gender)
        {
            using (var context = new mov4eEntities())
            {
                UserInfo CurrentUserInfo = context.UserInfoes.First(uf => uf.id.Equals(id));
                CurrentUserInfo.gender = gender;
                context.SaveChanges();
            }
        }

        public void ChangePassword(int id, string newPass)
        {
            using (var context = new mov4eEntities())
            {
                User CurrentUser = context.Users.First(u => u.id.Equals(id));
                CurrentUser.password = newPass;
                context.SaveChanges();
            }
        }

        public ICollection<string> GetListOfUserNames()
        {
            using (var context = new mov4eEntities())
            {
                var usernames = from us in context.Users
                                select us.userName;

                return usernames.ToList();
            }
        }

        public void ChangeUserName(int id, string userName)
        {
            using (var context = new mov4eEntities())
            {
                User CurrentUser = context.Users.First(u => u.id.Equals(id));
                CurrentUser.userName = userName;
                context.SaveChanges();
            }

        }

        public void ChangeFirstName(int id, string firstName)
        {
            using (var context = new mov4eEntities())
            {
                UserInfo CurrentUserInfo = context.UserInfoes.First(uf => uf.id.Equals(id));
                CurrentUserInfo.firstName = firstName;
                context.SaveChanges();
            }
        }

        public void ChangeLastName(int id, string lastName)
        {
            using (var context = new mov4eEntities())
            {
                UserInfo CurrentUserInfo = context.UserInfoes.First(uf => uf.id.Equals(id));
                CurrentUserInfo.lastName = lastName; ;
                context.SaveChanges();
            }
        }
    }
}

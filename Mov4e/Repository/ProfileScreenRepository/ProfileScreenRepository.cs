using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4e.Repository.ProfileScreenRepository
{
    class ProfileScreenRepository:IProfileScreenRepository
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

        

        public void ChangeProfilePicture(int id, byte[] profilePic)
        {
            using (var context = new mov4eEntities())
            {
                UserInfo CurrentUser = context.UserInfoes.First(cU => cU.id.Equals(id));
                CurrentUser.picture = profilePic;
                context.SaveChanges();
            }
        }

        //This Method Returns WatchList For curren User(movie id and picture)
        public Dictionary<int, byte[]> GetUserWatchlist(int id)
        {
            Dictionary < int, byte[] > watchList = new Dictionary<int, byte[]>();
            using (var context=new mov4eEntities())
            {
                User us = context.Users.Find(id);

                foreach (var el in us.movies)
                {
                    watchList.Add(el.id, el.picture);
                }
                return watchList;
            }
        }

        //Returns Movie title for Wtchlist
        public string GetMovieTitle(int movieId)
        {
            using (var context = new mov4eEntities())
            {
                Movie mv= context.Movies.Find(movieId);

                return mv.title;
            }

        }
        //This method removes movie from watchlist
        public void RemoveFromWatchList(int userId, int movieId)
        {
            using (var context = new mov4eEntities())
            {
                User us = context.Users.Find(userId);
                Movie mv = context.Movies.Find(movieId);
                us.movies.Remove(mv);
                context.SaveChanges();
            }
        }
    }
}

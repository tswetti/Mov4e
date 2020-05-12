using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4e.Repository.ProfileScreenRepository
{
    public interface IProfileScreenRepository
    {
        /// <summary>
        /// Returns User by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUserFromDB(int id);

        /// <summary>
        /// Returns Info about the user by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserInfo GetDataForThisUser(int id);

        
        /// <summary>
        /// This method changes the profile picture of current logged user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="profilePic"></param>
        void ChangeProfilePicture(int id, byte[] profilePic);

        /// <summary>
        /// This method returs WatchList for the current logged user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Dictionary<int, byte[]> GetUserWatchlist(int id);

        /// <summary>
        /// This method removes movie from user's WatchList.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="movieId"></param>
        void RemoveFromWatchList(int userId, int movieId);

        /// <summary>
        /// This method gets titles for the movies in WatchList.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        string GetMovieTitle(int movieId);
    }
}

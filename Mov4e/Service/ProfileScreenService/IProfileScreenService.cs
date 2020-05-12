using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4e.Service.ProfileScreenService
{
    public interface IProfileScreenService
    {
        /// <summary>
        /// This method stores User in UserInfo in models(Which are in service).
        /// </summary>
        /// <param name="id"></param>
        void UserAndUserInfoFromDBAndStoreitInModels(int id);

        /// <summary>
        /// This method returns full info about the user.
        /// </summary>
        /// <returns></returns>
      (string username, string firstname, string lastname, string email, string gender, int age, byte[] picture) GiveUserInformation();
        

        /// <summary>
        /// This method Returns the WatchList of curren user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Dictionary<int, byte[]> GiveWatchList(int id);

        /// <summary>
        /// This method removes movie from WatchList.
        /// </summary>
        /// <param name="movieId"></param>
        void MovieRemover(int movieId);

        /// <summary>
        /// This method returns the titles of the movies in the WatchList.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        string SetMovieTitleForMoviesInWatchList(int movieId);

        /// <summary>
        /// This method updates proffile picture of current user but furst validates it.
        /// </summary>
        /// <param name="profilePic"></param>
        void UpdateProfilePicture(byte[] profilePic);

    }
}

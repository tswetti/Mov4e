using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Model;

namespace Mov4e.Repository.SpecificMovieInfoRepository
{
    public interface ISpecificMovieInfoRepository
    {
        /// <summary>
        /// This method gets movie by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Movie GetMovieById(int id);

        /// <summary>
        /// This method gets the genere of the movie. Because the genere is in other table in DB. Actually joins the tables.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetGenreById(int id);

        /// <summary>
        /// This method inserts new rate for movie in DB.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="userId"></param>
        /// <param name="rate"></param>
        void InserNewRate(int movieId,int userId,int rate);

        /// <summary>
        /// This method returns the rate for movie.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        double? GetRateByMovieId(int movieId);

        /// <summary>
        /// This method checks if the current user has rated the movie that he is watching info for.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="movieId"></param>
        /// <returns></returns>
        bool isRateInDB(int userId,int movieId);

        /// <summary>
        /// This method checks if the current user has rated the movie that he is watching info for.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="movieId"></param>
        /// <returns></returns>
        bool isMovieInWatchList(int userId,int movieId);

        /// <summary>
        /// This method removes movie from watchlist of the current user.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="userId"></param>
        void RemoveFromWatchList(int movieId, int userId);

        /// <summary>
        /// This method Adds movie in WatchList of the current user.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="userId"></param>
        void AddToWatchList(int movieId,int userId);

        /// <summary>
        /// This method returns list of all comments for the current movie.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        List<(int commentId, string name, byte[] picture, string comment)> GetMovieComments(int movieId);

        /// <summary>
        /// This method saves comment in DB.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="movieId"></param>
        /// <param name="comment"></param>
        void SaveComment(int userId, int movieId, string comment);

        /// <summary>
        /// This method returns ifo for the last comment in DB.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        (int commentId,string userName, byte[] profilePic) GetInfoForUserAndCommentIdFromDB(int userId);

        /// <summary>
        /// This method deletes comment/s from DB.
        /// </summary>
        /// <param name="commentsIds"></param>
        void DeleteCommentFromDB(List<int> commentsIds);

        /// <summary>
        /// This method gets username for the current user in DB. It is used in commentbox.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string GetUserNameForCurrentUserFromDB(int userId);

        /// <summary>
        /// This method gets user position from DB;
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string UserPosition(int userId);

        /// <summary>
        /// Deletes as many coments as are set in counter.
        /// </summary>
        /// <param name="count"></param>
        void DeleteComentsCounter(int count);

        /// <summary>
        /// This method returns the last comment for the user.
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        (int commentId, string name, byte[] picture, string comment) GetLastCommentForTheUser(int movieId, int userId);
    }
}

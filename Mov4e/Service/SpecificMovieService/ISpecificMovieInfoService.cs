using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4e.Service.SpecificMovieService
{
    public interface ISpecificMovieInfoService
    {
        /// <summary>
        /// This method finds the movie by ID and saves it in model in service.
        /// </summary>
        /// <param name="movieId"></param>
        void GetMovieFromDBAndSetItInModel(int movieId);

        /// <summary>
        /// This method returns full information about movie.
        /// </summary>
        /// <returns></returns>
        (string title, byte[] pic, string genere, Nullable<int> pg, string date, string summary, double? avgRating,int duration) SetMovieInfo();

        /// <summary>
        /// This method adds rate in DB.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rate"></param>
        void AddRate(int userId, int rate);

        /// <summary>
        /// This method sets updates the rate in model when user rate the movie.
        /// </summary>
        void SetUpdatedRateInModel();

        /// <summary>
        /// This method checks if the current user has rated the movie.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool CheckIfUserRated(int userId);

        /// <summary>
        /// This method checks if the user has the movie that he is watching info for in watchlist.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool CheckIfUserHasMovieInWatchList(int userId);

        /// <summary>
        /// This method removes movie from DB.
        /// </summary>
        /// <param name="userId"></param>
        void MovieRemover(int userId);

        /// <summary>
        /// This method adds movie in DB.
        /// </summary>
        /// <param name="userId"></param>
        void MovieAdder(int userId);

        /// <summary>
        /// This method receives comments on the current movie whose information is being watched.
        /// </summary>
        /// <returns></returns>
        List<(int commentId,string name, byte[] picture, string comment)> GetCommentsFromDB();

        /// <summary>
        /// This method saves comment in DB
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="commet"></param>
        void SaveComentInDB(int userId, string commet);

        /// <summary>
        /// This method deletes comment from DB.
        /// </summary>
        /// <param name="commentIds"></param>
        void DeleteComment(List<int> commentIds);

        /// <summary>
        /// This method gets current user's username by ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string GetCurrentUserUserName(int userId);

        /// <summary>
        /// Returns possition of the current user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string UserPositon(int userId);


        /// <summary>
        /// This method returns last comment in DB.
        /// </summary>
        /// <returns></returns>
        (int commentId, string name, byte[] picture, string comment) GetLastComment(int userId);
    }
}

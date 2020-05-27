using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.View.SpecificMovieInfoView;
using Mov4e.Service.SpecificMovieService;

namespace Mov4e.Presenter.SpecificMovieInfoPresenter
{
    public class SpecificMovieInfoPresenter : ISpecificMovieInfoPresenter
    {
        ISpecificMovieView _specificMovieView;
        ISpecificMovieInfoService _specificMovieService = new SpecificMovieInfoService();

        public SpecificMovieInfoPresenter(ISpecificMovieView _specMovView)
        {
            this._specificMovieView = _specMovView;
        }

        //for tests
        public SpecificMovieInfoPresenter(ISpecificMovieView _specMovView,ISpecificMovieInfoService _specificMovieInfoService)
        {
            _specificMovieView = _specMovView;
            _specificMovieService = _specificMovieInfoService;
        }

        /// <summary>
        /// This method sets info for the movie in View.
        /// </summary>
        /// <param name="movieId"></param>
        public void GetInfoForMovie(int movieId)
        {
            try
            {
                _specificMovieService.GetMovieFromDBAndSetItInModel(movieId);
                _specificMovieView.movieTitle = _specificMovieService.SetMovieInfo().title;
                _specificMovieView.moviePicture = _specificMovieService.SetMovieInfo().pic;
                _specificMovieView.movieGenre = _specificMovieService.SetMovieInfo().genere;
                _specificMovieView.moviePG = _specificMovieService.SetMovieInfo().pg;
                _specificMovieView.moviePrimeDate = _specificMovieService.SetMovieInfo().date;
                _specificMovieView.movieSummary = _specificMovieService.SetMovieInfo().summary;
                _specificMovieView.movieAVGRate = _specificMovieService.SetMovieInfo().avgRating;
                _specificMovieView.duration = _specificMovieService.SetMovieInfo().duration;                
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _specificMovieView.ErrorMassage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);
            }
        }

        /// <summary>
        /// This method rates movie.
        /// </summary>
        /// <param name="rate"></param>
        public void RateMovie(int rate)
        {
            try
            {
                _specificMovieService.AddRate(_specificMovieView.userId, rate);
                this.UpdateRate();
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _specificMovieView.ErrorMassage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);
            }
        }

        /// <summary>
        /// This method updates move AVGrate after Rate.
        /// </summary>
        private void UpdateRate()
        {
            try
            {
                _specificMovieService.SetUpdatedRateInModel();
                _specificMovieView.movieAVGRate = _specificMovieService.SetMovieInfo().avgRating;
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _specificMovieView.ErrorMassage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);
            }
        }

        /// <summary>
        /// This method checks if the user has rated the movie.
        /// </summary>
        /// <returns></returns>
        public bool UserAlreadyRated()
        {
            try
            {
                return _specificMovieService.CheckIfUserRated(_specificMovieView.userId);
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _specificMovieView.ErrorMassage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);
                return false;
            }
        }

        /// <summary>
        /// This method checks if the current user has movie in his watchlist.
        /// </summary>
        /// <returns></returns>
        public bool UserHasMovieInWatchList()
        {
            try
            {
                return _specificMovieService.CheckIfUserHasMovieInWatchList(_specificMovieView.userId);
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _specificMovieView.ErrorMassage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);
                return false;
            }
        }

        /// <summary>
        /// This method deletes movie from current user's watchlist.
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteMovieFromWatchList()
        {
            try
            {
                _specificMovieService.MovieRemover(_specificMovieView.userId);
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _specificMovieView.ErrorMassage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);
            }
        }

        /// <summary>
        /// this method adds movie to current user's watchlis.
        /// </summary>
        /// <param name="userId"></param>
        public void AddMovieINWatchList()
        {
            try
            {
                _specificMovieService.MovieAdder(_specificMovieView.userId);
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _specificMovieView.ErrorMassage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);
      
            }
        }

        /// <summary>
        /// This method gets the comments for the movie whose info is being watched.
        /// </summary>
        public void SetCommentsForTheMovie()
        {
            try
            {
                _specificMovieView.comments = _specificMovieService.GetCommentsFromDB();
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _specificMovieView.ErrorMassage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);

            }
        }

        /// <summary>
        /// This method add comment for the current movie.
        /// </summary>
        /// <param name="comment"></param>
        public void AddCommentInDB(string comment)
        {
            try
            {
                 _specificMovieService.SaveComentInDB(_specificMovieView.userId, comment);
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _specificMovieView.ErrorMassage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);
            }
        }

        /// <summary>
        /// This method returns the last comment in DB.
        /// </summary>
        /// <returns></returns>
        public (int commentId, string name, byte[] picture, string comment) GetLastComment()
        {
            try
            {
                return _specificMovieService.GetLastComment(_specificMovieView.userId);
            }
            catch (Exception e)
            {
                
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _specificMovieView.ErrorMassage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);
                return ((1, "ERROR", new byte[0], "ERROR"));
            }
        }
        /// <summary>
        /// This method deete comment/s for the current movie whose info is being watched.
        /// </summary>
        /// <param name="commentsIds"></param>
        public void DeleteComments(List<int> commentsIds)
        {
            try
            {
                _specificMovieService.DeleteComment(commentsIds);
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _specificMovieView.ErrorMassage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);

            }
        }

        /// <summary>
        /// This method gets current user's username who watches info for the current movie.
        /// </summary>
        /// <returns></returns>
        public string GetUserName()
        {
            try
            {
                return _specificMovieService.GetCurrentUserUserName(_specificMovieView.userId);
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _specificMovieView.ErrorMassage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);
                return null;
            }
        }

        /// <summary>
        /// This method gets user position. It uses method from service that returns position from DB.
        /// </summary>
        /// <returns></returns>
        public void GetUserPosition()
        {
            try
            {
               _specificMovieView.userPosition= _specificMovieService.UserPositon(_specificMovieView.userId);
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _specificMovieView.ErrorMassage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);
            }
        }

        /// <summary>
        /// This method gets the rate of current user.
        /// </summary>
        /// <returns></returns>
        public void SetUserRate()
        {
            try
            {
                _specificMovieView.userRate = _specificMovieService.GetUserRate(_specificMovieView.userId);
            }
            catch (Exception e)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                         + "\n" + e.ToString());
                _specificMovieView.ErrorMassage("In the application sprang up an error! Please, check errors.txt file for more information!\n" + e.Message);
            }
        }

 
    }
}

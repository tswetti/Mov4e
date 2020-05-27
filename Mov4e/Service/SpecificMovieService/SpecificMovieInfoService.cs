using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Repository.SpecificMovieInfoRepository;
using Mov4e.Validation;
using Mov4e.Exceptions;
using Mov4e.Model;

namespace Mov4e.Service.SpecificMovieService
{
    public class SpecificMovieInfoService : ISpecificMovieInfoService
    {
        private ISpecificMovieInfoRepository _specificMovieRepo;
        private Movie currentMovie = new Movie();

        public SpecificMovieInfoService()
        {
            _specificMovieRepo = new SpecificMovieInfoRepository();
        }

        //for tests
        public SpecificMovieInfoService(ISpecificMovieInfoRepository _specificMovieReository)
        {
            _specificMovieRepo = _specificMovieReository ;
        }

        public void GetMovieFromDBAndSetItInModel(int movieId)
        {
            try
            {
                ValidateSpecificMovie.isThereMovie(movieId);
                currentMovie = _specificMovieRepo.GetMovieById(movieId);
            }
            catch(SpecificMovieException)
            {
                throw;
            }
        }

        public (string title, byte[] pic, string genere, Nullable<int> pg, string date, string summary,double? avgRating,int duration) SetMovieInfo()
        {
            try
            {
                if (currentMovie.AVGRating==null)
                {
                    currentMovie.AVGRating = 0;
                    
                }
                return (currentMovie.title, currentMovie.picture,
                        _specificMovieRepo.GetGenreById(this.currentMovie.genre),
                        currentMovie.pg, currentMovie.year.Value.Day+"."+ currentMovie.year.Value.Month+"."+ currentMovie.year.Value.Year,
                        currentMovie.summary, currentMovie.AVGRating,currentMovie.duration);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddRate(int userId, int rate)
        {
            try
            {
                ValidateSpecificMovie.isThereAnUser(userId);
                ValidateSpecificMovie.isRateOk(rate);
                _specificMovieRepo.InserNewRate(currentMovie.id, userId, rate);
            }
            catch (SpecificMovieException)
            {
                throw;
            }
        }

        public void SetUpdatedRateInModel()
        {
            try
            {
                ValidateSpecificMovie.isThereMovie(currentMovie.id);
                currentMovie.AVGRating = _specificMovieRepo.GetRateByMovieId(currentMovie.id);
            }
            catch (SpecificMovieException)
            {
                throw;
            }
        }
        //user validate
        public bool CheckIfUserRated(int userId)
        {
            try
            {
                ValidateSpecificMovie.isThereAnUser(userId);
                return _specificMovieRepo.isRateInDB(userId, currentMovie.id);
            }
            catch (SpecificMovieException)
            {
                throw;
            }
        }

        public bool CheckIfUserHasMovieInWatchList(int userId)
        {
            try
            {
                ValidateSpecificMovie.isThereAnUser(userId);
                return _specificMovieRepo.isMovieInWatchList(userId, currentMovie.id);
            }
            catch (SpecificMovieException)
            {
                throw;
            }
        }

        public void MovieRemover(int userId)
        {
            try
            {
                ValidateSpecificMovie.isThereAnUser(userId);
                ValidateSpecificMovie.isThereAnythingToRemoveOrAddFromWatchList(currentMovie.id);
                _specificMovieRepo.RemoveFromWatchList(currentMovie.id, userId);
            }
            catch (SpecificMovieException)
            {
                throw;
            }
        }


        public void MovieAdder(int userId)
        {
            try
            {
                ValidateSpecificMovie.isThereAnUser(userId);
                ValidateSpecificMovie.isThereAnythingToRemoveOrAddFromWatchList(currentMovie.id);
                _specificMovieRepo.AddToWatchList(currentMovie.id, userId);
            }
            catch (SpecificMovieException)
            {
                throw;
            }
        }

        public List<(int commentId, string name, byte[] picture, string comment)> GetCommentsFromDB()
        {
            return _specificMovieRepo.GetMovieComments(currentMovie.id);
        }



        public void SaveComentInDB(int userId, string commet)
        {
            try
            {
                ValidateSpecificMovie.isThereAnUser(userId);
                ValidateSpecificMovie.isCommentOK(commet);
                _specificMovieRepo.SaveComment(userId, currentMovie.id, commet);
            }
            catch (SpecificMovieException)
            {
                throw;
            }
        }


        public void DeleteComment(List<int> commentsIds)
        {
            try
            {
                ValidateSpecificMovie.isThereCommentToRemove(commentsIds);
                _specificMovieRepo.DeleteCommentFromDB(commentsIds);
            }
            catch (SpecificMovieException)
            {
                throw;
            }
        }

        public string GetCurrentUserUserName(int userId)
        {
            try
            {
                ValidateSpecificMovie.isThereAnUser(userId);
                return _specificMovieRepo.GetUserNameForCurrentUserFromDB(userId);
            }
            catch (SpecificMovieException)
            {
                throw;
            }
        }

        public string UserPositon(int userId)
        {
            try
            {
                ValidateSpecificMovie.isThereAnUser(userId);
                return _specificMovieRepo.UserPosition(userId);
            }
            catch (SpecificMovieException)
            {
                throw;
            }
        }


        public (int commentId, string name, byte[] picture, string comment) GetLastComment(int userId)
        {
            try
            {
                ValidateSpecificMovie.isThereAnUser(userId);
                return _specificMovieRepo.GetLastCommentForTheUser(currentMovie.id, userId);
            }
            catch (SpecificMovieException)
            {
                throw;
            }
           
        }

        public int GetUserRate(int id)
        {
            try
            {
                ValidateSpecificMovie.isThereAnUser(id);
                return _specificMovieRepo.GetUserRateFromDB(id,this.currentMovie.id);
            }
            catch (SpecificMovieException)
            {
                throw;
            }
        }

        public void DeleteUserRate(int userId)
        {
            try
            {
                ValidateSpecificMovie.isThereAnUser(userId);
                ValidateSpecificMovie.isThereMovie(currentMovie.id);
                _specificMovieRepo.RemoveUserRateFromDB(userId, currentMovie.id);
            }
            catch (SpecificMovieException)
            {
                throw;
            }
        }
    }
}

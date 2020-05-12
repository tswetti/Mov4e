using System.Collections.Generic;

namespace Mov4e.Presenter.SpecificMovieInfoPresenter
{
    public interface ISpecificMovieInfoPresenter
    {
        void AddCommentInDB(string comment);
        void AddMovieINWatchList(int userId);
        void DeleteComments(List<int> commentsIds);
        void DeleteMovieFromWatchList(int userId);
        void GetInfoForMovie(int movieId);
        (int commentId, string name, byte[] picture, string comment) GetLastComment();
        string GetUserName();
        void GetUserPosition();
        void RateMovie(int rate);
        void SetCommentsForTheMovie();
        bool UserAlreadyRated();
        bool UserHasMovieInWatchList();
    }
}
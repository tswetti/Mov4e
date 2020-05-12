namespace Mov4e.Presenter.ProfileScreenPresenter
{
    public interface IProfileScreenPresenter
    {       
        void ChangeProfilePicture(byte[] profilePic);
        void DeleteMovieFromwatchList(int movieId);
        string SetMovieTitelInView(int movieId);
        void SetUserInformation(int id);
        void UpdateWatchListWhenMovieAdded(int id);
    }
}
using System;

namespace Mov4e.Presenter.NewMoviePresenter
{
    /// <summary>
    /// The <c>INewMoviePresenter</c> is a public interface.
    /// </summary>
    public interface INewMoviePresenter
    {
        void AddMovie(string title, int genre, Nullable<int> pg, 
        Nullable<System.DateTime> date, string summary, byte[] pic, int dur);

        int LastMovieId();
    }
}
using System;
using System.Collections.Generic;
using Mov4e.Model;

namespace Mov4e.Presenter.AllMoviesPresenter
{
    /// <summary>
    /// The <c>IAllMoviesPresenter</c> is a public interface.
    /// </summary>
    public interface IAllMoviesPresenter
    {
        Tuple<Movie,string> GetMovie(int id);
        void EditMovie(int id, string title, int genre, int pg, 
        Nullable<DateTime> date, string summary, byte[] picture, int dur);
        void DeleteMovie(int id);
        Dictionary<int, byte[]> SortMoviesByTitle();
        Dictionary<int, byte[]> SortByDate();
        Dictionary<int, byte[]> FilterMovies(int g, int d, int pg);
        Dictionary<int, byte[]> FilterMoviesByGenresAndDuration(int g, int d);
        Dictionary<int, byte[]> FilterMoviesByGenresAndPG(int g, int pg);
        Dictionary<int, byte[]> FilterMoviesByDurationAndPG(int d, int pg);
        Dictionary<int, byte[]> FilterMoviesByGenres(int g);
        Dictionary<int, byte[]> FilterMoviesByDuration(int d);
        Dictionary<int, byte[]> FilterMoviesByPG(int pg);
        Dictionary<int, byte[]> GetMoviesByTitle(List<string> titles);
        string SetMovieTitle(int key);
        Dictionary<int, byte[]> SetMovieInformation();
        List<string> GetMovieTitles();
        Tuple<int, string> GetUserInfo(string unm, string pass);
        int GetMovieGenre(string gen);
    }
}

using System.Collections.Generic;


namespace Mov4e.View.AllMoviesView
{
    /// <summary>
    /// The <c>IAllMovies</c> class is a public interface.
    /// </summary>
    public interface IAllMovies
    {
        string Search { get; set; }
        void GetMovie();
        void EditMovie();
        void DeleteMovie();
        void SortByTitle();
        void SortByDate();
        void FilterMovies(int g, int d, int pg);
        void FilterMoviesByGenresAndDuration(int g, int d);
        void FilterMoviesByGenresAndPG(int g, int pg);
        void FilterMoviesByDurationAndPG(int d, int pg);
        void FilterMoviesByGenres(int g);
        void FilterMoviesByDuration(int d);
        void FilterMoviesByPG(int pg);
        void InitializeMoviesList(Dictionary<int, byte[]> movs);
        void SearchMovie();
        void UpdateMovies(int movieId, byte[] moviePic);
    }
}
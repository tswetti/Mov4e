using Mov4e.Service.AllMoviesService;
using System;
using System.Collections.Generic;

namespace Mov4e.Presenter.AllMoviesPresenter
{
    /// <summary>
    /// The <c>AllMoviesPresenter</c> is a presenter class that communicates with the <c>AllMoviesService</c> class.
    /// </summary>
    /// <inheridoc cref="IAllMoviesPresenter"/>
    public class AllMoviesPresenter : IAllMoviesPresenter
    {
        // A private variable that keeps a reference to AllMoviesService class via an interface variable.
        private IAllMoviesService ms = new AllMoviesService();

        /// <summary>
        /// A no arguments constructor for the <c>AllMoviesPresenter</c> class.
        /// </summary>
        public AllMoviesPresenter()
        {

        }

        /// <summary>
        /// The <c>GetMovie()</c> method receives as a parameter the id of a certain movie from the form and executes 
        /// the service's method which is responsible for getting a certain movie from the database by its id.
        /// </summary>
        /// <param name="id">This is the id of the movie.</param>
        /// <returns>This method returns a tuple of a movie object and its genre as a string.</returns>
        public Tuple<Movie, string> GetMovie(int id)
        {
            return ms.GetMovie(id);
        }

        /// <summary>
        /// The <c>EditMovie()</c> method receives as parameters the id, title, genre, parental guidance, prime date, summary
        /// and wrapper of a certain movie from the form and executes the service's method which is responsible for editting 
        /// this movie in the database.
        /// </summary>
        /// <param name="id">This is the id of the movie.</param>
        /// <param name="title">This is the title of the movie.</param>
        /// <param name="genre">This is the genre of the movie.</param>
        /// <param name="pg">This is the parental guidance of the movie.</param>
        /// <param name="date">This is the prime date of the movie.</param>
        /// <param name="summary">This is the summary of the movie.</param>
        /// <param name="picture">This is the wrapper of the movie.</param>
        public void EditMovie
        (int id, string title, int genre, int pg, Nullable<DateTime> date, string summary, byte[] picture, int dur)
        {
            try
            {
                ms.EditMovie(id, title, genre, pg, date, summary, picture, dur);
            }
            catch(Exception ex)
            {
                Logger.Logger.WriteToLogFile(ex.ToString());
            }
        }

        /// <summary>
        /// The <c>DeleteMovie()</c> methods receives as a parameter the id of a certain movie from the form 
        /// and executes the service's method which is responsible of deleteing this movie from the database.
        /// </summary>
        /// <param name="id">This is the id of the movie.</param>
        public void DeleteMovie(int id)
        {
            try
            {
                ms.DeleteMovie(id);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteToLogFile(ex.ToString());
            }
        }

        /// <summary>
        /// The <c>SortMoviesByTitle()</c> method executes the service's method which is responsible of filtering the
        /// movies' titles alphabetically. 
        /// </summary>
        /// <returns>This method returns a dictionary from the filtered movies' ids (int) 
        /// and the filtered movies' wrappers (byte[]) from the service class.</returns>
        public Dictionary<int, byte[]> SortMoviesByTitle()
        {
            try
            {
                return ms.SortMoviesByTitle();
            }
            catch(Exception ex)
            {
                Logger.Logger.WriteToLogFile(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// The <c>SortByDate()</c> method executes the service method which is responsible of sorting the
        /// movies from the database by date.
        /// </summary>
        /// <returns>This method returns a dictionary from the filtered movies' ids (int) 
        /// and the filtered movies' wrappers (byte[]) from the service class.</returns>
        public Dictionary<int, byte[]> SortByDate()
        {
            return ms.SortByDate();
        }

        /// <summary>
        /// The <c>FilterMovies()</c> method filters 
        /// the movies from the database by genre, duration and parental guidance at the same time.
        /// </summary>
        /// <param name="g">This is the genre - one of the filtering params.</param>
        /// <param name="d">This is the duration - one of the filtering params.</param>
        /// <param name="pg">This is the parental guidance - on of the filtering params.</param>
        /// <returns>This method returns a dictionary from the filtered movies' ids (int) 
        /// and the filtered movies' wrappers (byte[]) from the service class.</returns>
        public Dictionary<int, byte[]> FilterMovies(int g, int d, int pg)
        {
            return ms.FilterMovies(g, d, pg);
        }

        /// <summary>
        /// The <c>FilterMoviesByGenresAndDuration()</c> method filters 
        /// the movies from the database by genre and duration at the same time.
        /// </summary>
        /// <param name="g">This is the genre - one of the filtering params.</param>
        /// <param name="d">This is the duration - one of the filtering params.</param>
        /// <returns>This method returns a dictionary from the filtered movies' ids (int) 
        /// and the filtered movies' wrappers (byte[]) from the service class.</returns>
        public Dictionary<int, byte[]> FilterMoviesByGenresAndDuration(int g, int d)
        {
            return ms.FilterMoviesByGenresAndDuration(g, d);
        }

        /// <summary>
        /// The <c>FilterMoviesByDurationAndPG()</c> method filters 
        /// the movies from the database by genre and parental guidance at the same time.
        /// </summary>
        /// <param name="g">This is the genre - one of the filtering params.</param>
        /// <param name="pg">This is the parental guidance - one of the filtering params.</param>
        /// <returns>This method returns a dictionary from the filtered movies' ids (int) 
        /// and the filtered movies' wrappers (byte[]) from the service class.</returns>
        public Dictionary<int, byte[]> FilterMoviesByGenresAndPG(int g, int pg)
        {
            return ms.FilterMoviesByGenresAndPG(g, pg);
        }

        /// <summary>
        /// The <c>FilterMoviesByDurationAndPG()</c> method filters 
        /// the movies from the database by duration and parental guidance at the same time.
        /// </summary>
        /// <param name="d">This is the duration - one of the filtering params.</param>
        /// <param name="pg">This is the parental guidance - one of the filtering params.</param>
        /// <returns>This method returns a dictionary from the filtered movies' ids (int) 
        /// and the filtered movies' wrappers (byte[]) from the service class.</returns>
        public Dictionary<int, byte[]> FilterMoviesByDurationAndPG(int d, int pg)
        {
            return ms.FilterMoviesByDurationAndPG(d, pg);
        }

        /// <summary>
        /// The <c>FilterMoviesByGenres()</c> method filters 
        /// the movies from the database by genre.
        /// </summary>
        /// <param name="g">This is the genre - one of the filtering params.</param>
        /// <returns>This method returns a dictionary from the filtered movies' ids (int) 
        /// and the filtered movies' wrappers (byte[]) from the service class.</returns>
        public Dictionary<int, byte[]> FilterMoviesByGenres(int g)
        {
            return ms.FilterMoviesByGenres(g);
        }

        /// <summary>
        /// The <c>FilterMoviesByDuration()</c> method filters 
        /// the movies from the database by duration.
        /// </summary>
        /// <param name="d">This is the duration - one of the filtering params.</param>
        /// <returns>This method returns a dictionary from the filtered movies' ids (int) 
        /// and the filtered movies' wrappers (byte[]) from the service class.</returns>
        public Dictionary<int, byte[]> FilterMoviesByDuration(int d)
        {
            return ms.FilterMoviesByDuration(d);
        }

        /// <summary>
        /// The <c>FilterMoviesByPG()</c> method filters 
        /// the movies from the database by genre.
        /// </summary>
        /// <param name="pg">This is the parental guidance - one of the filtering params.</param>
        /// <returns>This method returns a dictionary from the filtered movies' ids (int) 
        /// and the filtered movies' wrappers (byte[]) from the service class.</returns>
        public Dictionary<int, byte[]> FilterMoviesByPG(int pg)
        {
            return ms.FilterMoviesByPG(pg);
        }

        /// <summary>
        /// The <c>GetMoviesByTitle()</c> method receives as a parameter a list of movies' titles from the form and
        /// executes the service's method which is responsible of getting movies' titles from the database.
        /// </summary>
        /// <param name="titles">This is a list of movies' titles.</param>
        /// <returns>This method returns a dictionary from the gotten movies' ids (int) 
        /// and the gotten movies' wrappers (byte[]) from the service's method.</returns>
        public Dictionary<int, byte[]> GetMoviesByTitle(List<string> titles)
        {
            return ms.GetMoviesByTitles(titles);
        }

        /// <summary>
        /// The <c>SetMovieTitle()</c> method receives as a parameter the id of a certain movie and executes the service's
        /// method which is responsible of getting from the database and setting a title for this movie in the form's listview.
        /// </summary>
        /// <param name="movieId">This is the id of the movie.</param>
        /// <returns>This method returns a string from the service's method execution.</returns>
        public string SetMovieTitle(int movieId)
        {
            return ms.SetMovieTitle(movieId);
        }

        /// <summary>
        /// The <c>SetMovieInformation()</c> method executes the service's method which is responsible of getting from
        /// the database and setting a certain's movie information (id and wrapper) in the form's listview. 
        /// </summary>
        /// <returns>This method returns a dictionary from the movie's id (int) 
        /// and wrapper (byte[]) from the service's method.</returns>
        public Dictionary<int,byte[]> SetMovieInformation()
        {
            return ms.SetMoviesList();
        }

        /// <summary>
        /// The <c>GetMovieTitles()</c> method executes the service's method which is responsible of getting 
        /// all movies' titles fro the database as a list.
        /// </summary>
        /// <returns>This method returns a list of movies' titles from the service's method.</returns>
        public List<string> GetMovieTitles()
        {
            return ms.GetMovieTitles();
        }

        /// <summary>
        /// The <c>GetUserInfo()</c> method receives as parameters a certain user's crentials and executes the srvice's 
        /// method which is responsible of getting the id and the position of a certain user via this method parameters.
        /// </summary>
        /// <param name="unm">This is the username of the user.</param>
        /// <param name="pass">This is the password of the user.</param>
        /// <returns>This method returns a tuple of the user's id (int) and the user's position (string).</returns>
        public Tuple<int, string> GetUserInfo(string unm, string pass)
        {
            return ms.GetUserInfo(unm, pass);
        }

        /// <summary>
        /// The<c>GetMovieGenre()</c> method gets the id of a certain genre by its name.
        /// </summary>
        /// <param name="gen">This is the genre - the param of this method.</param>
        /// <returns>This method returns the id of a certain genre.</returns>
        public int GetMovieGenre(string gen)
        {
            return ms.GetMovieGenre(gen);
        }
    }
}
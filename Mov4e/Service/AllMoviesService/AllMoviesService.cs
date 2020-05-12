using Mov4e.Repository.AllMoviesRepository;
using System;
using System.Collections.Generic;
using Mov4e.Exceptions;

namespace Mov4e.Service.AllMoviesService
{
    /// <summary>
    /// The <c>AllMoviesService</c> class is a service class that communicates with the <c>IAllMoviesRepository</c> class.
    /// </summary>
    /// <inheritdoc cref=""/>
    public class AllMoviesService: IAllMoviesService
    {
        // A private variable that keeps a reference to a AllMoviesRepository via an interface variable.
        private IAllMoviesRepository mr = new AllMoviesRepository();

        /// <summary>
        /// A no arguments constructor for the <c>AllMoviesService</c> class.
        /// </summary>
        public AllMoviesService()
        {

        }
        
        /// <summary>
        /// The <c>GetMovie()</c> method receives a certain movie's id as a parameter from the presenter and executes the 
        /// repository's method which is responsible of getting a certain movie from the database by its id.
        /// </summary>
        /// <param name="id">This is the id of the movie.</param>
        /// <returns>This method returns a tuple from a movie object and its genre in words (string).</returns>
        public Tuple<Movie, string> GetMovie(int id)
        {
            return mr.GetMovie(id);
        }

        /// <summary>
        /// The <c>EditMovie()</c> method receives a certain movie's id, title, genre, parental guidance, prime date,
        /// summary and wrapper from the presenter as parameters and executes the repository's method which is responsible
        /// of editting a certain movie in the database.
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
                mr.EditMovie(id, title, genre, pg, date, summary, picture, dur);
            }
            catch(ImpossibleDataBaseRecordUpdateException ex)
            {
                Logger.Logger.WriteToLogFile(ex.ToString());
            }
            catch(NotFoundSuchItemException ex)
            {
                Logger.Logger.WriteToLogFile(ex.ToString());
            }
        }
        
        /// <summary>
        /// The <c>DeleteMovie()</c> method receives a certain movie's id from the presenter as a parameter and executes 
        /// the repository's method which is responsible of deleting a certain movie from the database by its id.
        /// </summary>
        /// <param name="id">This is the id of the movie.</param>
        public void DeleteMovie(int id)
        {
            try
            {
                mr.DeleteMovie(id);
            }
            catch(NotFoundSuchItemException ex)
            {
                Logger.Logger.WriteToLogFile(ex.ToString());
            }
        }

        /// <summary>
        /// The <c>SortMoviesByTitle()</c> method executes the repository's method which is responsible of filtering
        /// the movies alphabetically.
        /// </summary>
        /// <returns>This method returns a dictionary of the filtered movies' ids (int) 
        /// and the filtered movies' wrapers (byte[]).</returns>
        public Dictionary<int, byte[]> SortMoviesByTitle()
        {
            try
            {
                return mr.SortMoviesByTitle();
            }
            catch(NoDataBaseTableRecordsException ex)
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
            return mr.SortByDate();
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
            return mr.FilterMovies(g, d, pg);
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
            return mr.FilterMoviesByGenresAndDuration(g, d);
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
            return mr.FilterMoviesByGenresAndPG(g, pg);
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
            return mr.FilterMoviesByDurationAndPG(d, pg);
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
            return mr.FilterMoviesByGenres(g);
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
            return mr.FilterMoviesByDuration(d);
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
            return mr.FilterMoviesByPG(pg);
        }

        /// <summary>
        /// The <c>GetMoviesByTitles()</c> method receives a list of titles from the presenter as a parameter and executes 
        /// the repository's method which is responsible of getting all movies from the database by their titles.
        /// </summary>
        /// <param name="titles">This is the list of movies' titles.</param>
        /// <returns>This method returns a dictionaty from movies' ids (int) and movies' wrappers (byte[]).</returns>
        public Dictionary<int, byte[]> GetMoviesByTitles(List<string> titles)
        {
            return mr.GetMoviesByTitles(titles);
        }

        /// <summary>
        /// The <c>SetMovieTitle()</c> method receives a certain movie's id from the presenter and
        /// executes the repository's method which is responsible of getting from the database and setting 
        /// a certain movie's title into the form's listview. 
        /// </summary>
        /// <param name="movieId">This is the id of the movie.</param>
        /// <returns>This method returns the title of a certain movie from the database (string). </returns>
        public string SetMovieTitle(int movieId)
        {
            return mr.GetMovieTitle(movieId);
        }

        /// <summary>
        /// The <c>SetMoviesList()</c> method executes the repository's method  which is responsible of getting all movies
        /// from the database and setting their ids and wrappers in the form's listview. 
        /// </summary>
        /// <returns>This method returns a dictionaty of the movies' ids (int) and wrappers (byte[]).</returns>
        public Dictionary<int, byte[]> SetMoviesList()
        {
            return mr.GetMovies();
        }

        /// <summary>
        /// The <c>GetMovieTitles()</c> method executes the repository's method which is responsible of getting all movies' 
        /// titles from the database and keeping them in a list.
        /// </summary>
        /// <returns>This method returns a list of all movies' titles.</returns>
        public List<string> GetMovieTitles()
        {
            return mr.GetMoviesTitles();
        }

        /// <summary>
        /// The <c>GetUserInfo()</c> method receives the user's credentials as parameters and executes the repository's
        /// method which is responsible of getting the user's id and the user's position from the database.
        /// </summary>
        /// <param name="unm">This is the username of the user.</param>
        /// <param name="pass">This is the password of the user.</param>
        /// <returns>This method returns a tuple of the user's id (int) and the user's position (string).</returns>
        public Tuple<int, string> GetUserInfo(string unm, string pass)
        {
            return mr.GetUserInfo(unm, pass);
        }

        /// <summary>
        /// The<c>GetMovieGenre()</c> method gets the id of a certain genre by its name.
        /// </summary>
        /// <param name="gen">This is the genre - the param of this method.</param>
        /// <returns>This method returns the id of a certain genre.</returns>
        public int GetMovieGenre(string gen)
        {
            return mr.GetMovieGenre(gen);
        }
    }
}
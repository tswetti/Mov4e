using System;
using System.Collections.Generic;
using System.Linq;
using Mov4e.Exceptions;
using Mov4e.Model;

namespace Mov4e.Repository.AllMoviesRepository
{
    /// <summary>
    /// The <c>AllMoviesRepository</c> class is a repository class which communicates with the database.
    /// </summary>
    /// <inheritdoc cref="IAllMoviesRepository"/>
    public class AllMoviesRepository : IAllMoviesRepository
    {
        /// <summary>
        /// A no arguments constructor for the <c>AllMoviesRepository</c> class.
        /// </summary>
        public AllMoviesRepository()
        {

        }

        // This is a private method that edits the title of a certain Movie.
        private void EditTitle(int id, string title)
        {
            using (mov4eEntities m = new mov4eEntities())
            {
                var updateQuery = (Movie)m.Movies.Find(id);
                updateQuery.title = title;
                m.SaveChanges();
            }
        }

        // This is a private method that edits the picture of a certain Movie.
        private void EditPicture(int id, byte[] pic)
        {
            using (mov4eEntities m = new mov4eEntities())
            {
                var updateQuery = (Movie)m.Movies.Find(id);
                updateQuery.picture = pic;
                m.SaveChanges();
            }
        }

        // This is a private method that edits the genre of a certain Movie.
        private void EditGenre(int id, int genre)
        {
            using (mov4eEntities m = new mov4eEntities())
            {
                var updateQuery = (Movie)m.Movies.Find(id);
                updateQuery.genre = genre;
                m.SaveChanges();
            }
        }

        // This is a private method that edits the parental guidance of a certain Movie.
        private void EditPg(int id, int pg)
        {
            using (mov4eEntities m = new mov4eEntities())
            {
                var updateQuery = (Movie)m.Movies.Find(id);
                updateQuery.pg = pg;
                m.SaveChanges();
            }
        }

        // This is a private method that edits the prime date of a certain Movie.
        private void EditYear(int id, Nullable<DateTime> year)
        {
            using (mov4eEntities m = new mov4eEntities())
            {
                var updateQuery = (Movie)m.Movies.Find(id);
                updateQuery.year = year;
                m.SaveChanges();
            }
        }

        // This is a private method that edits the summary of a certain Movie.
        private void EditSummary(int id, string summary)
        {
            using (mov4eEntities m = new mov4eEntities())
            {
                var updateQuery = (Movie)m.Movies.Find(id);
                updateQuery.summary = summary;
                m.SaveChanges();
            }
        }

        // This is a private method that edits the duration of a certain Movie.
        private void EditDuration(int id, int dur)
        {
            using (mov4eEntities m = new mov4eEntities())
            {
                var updateQuery = (Movie)m.Movies.Find(id);
                updateQuery.duration = dur;
                m.SaveChanges();
            }
        }

        // This is a private method that gets a list of all movies from the datebase.
        private List<Movie> GetMoviesList()
        {
            List<Movie> list = new List<Movie>();
            using (mov4eEntities mov = new mov4eEntities())
            {
                var movies = from m in mov.Movies select m;
                foreach (var item in movies)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        // This method filter the movies (with duration less than a hour) by a certain genre and pg.
        private Dictionary<int, byte[]> FilterLessThanHour(int g, int pg)
        {
            Dictionary<int, byte[]> movs = new Dictionary<int, byte[]>();
            using (mov4eEntities mov = new mov4eEntities())
            {


                var filt = from m in mov.Movies where m.genre == g && m.pg == pg && m.duration >= 0 && m.duration <= 60 select new { m.id, m.picture };
                foreach (var item in filt)
                {
                    movs.Add(item.id, item.picture);
                }

                return movs;
            }
        }

        // This method filter the movies (with duration between one and two hours) by a certain genre and pg.
        private Dictionary<int, byte[]> FilterBetweenOneAndTwoHours(int g, int pg)
        {
            Dictionary<int, byte[]> movs = new Dictionary<int, byte[]>();
            using (mov4eEntities mov = new mov4eEntities())
            {

                var filt = from m in mov.Movies where m.genre == g && m.pg == pg && m.duration > 60 && m.duration <= 120 select new { m.id, m.picture };
                foreach (var item in filt)
                {
                    movs.Add(item.id, item.picture);
                }

                return movs;
            }
        }

        // This method filter the movies (with duration between two and three hours) by a certain genre and pg.
        private Dictionary<int, byte[]> FilterBetweenTwoAndThreeHours(int g, int pg)
        {
            Dictionary<int, byte[]> movs = new Dictionary<int, byte[]>();
            using (mov4eEntities mov = new mov4eEntities())
            {

                var filt = from m in mov.Movies where m.genre == g && m.pg == pg && m.duration > 120 && m.duration <= 180 select new { m.id, m.picture };
                foreach (var item in filt)
                {
                    movs.Add(item.id, item.picture);
                }

                return movs;
            }
        }

        // This method filter the movies (with duration more than three hours) by a certain genre and pg.
        private Dictionary<int, byte[]> FilterMoreThanThreeHours(int g, int pg)
        {
            Dictionary<int, byte[]> movs = new Dictionary<int, byte[]>();
            using (mov4eEntities mov = new mov4eEntities())
            {

                var filt = from m in mov.Movies where m.genre == g && m.pg == pg && m.duration > 180 select new { m.id, m.picture };
                foreach (var item in filt)
                {
                    movs.Add(item.id, item.picture);
                }

                return movs;
            }
        }

        // This method gets the movies which are in a certain duration interval and with a certain genre.
        private Dictionary<int, byte[]> GetMoviesInACertainDurationGenreInterval(int g, int min, int max)
        {
            Dictionary<int, byte[]> moviesList = new Dictionary<int, byte[]>();
            using (mov4eEntities mov = new mov4eEntities())
            {
                var movies = from m in mov.Movies where m.duration >= min && m.duration < max && m.genre == g select new { m.id, m.picture };
                foreach (var item in movies)
                {
                    moviesList.Add(item.id, item.picture);
                }

                return moviesList;
            }
        }

        // This method gets the movies which are in a certain duration interval and with a certain parental guidance.
        private Dictionary<int, byte[]> GetMoviesInACertainDurationPGInterval(int pg, int min, int max)
        {
            Dictionary<int, byte[]> moviesList = new Dictionary<int, byte[]>();
            using (mov4eEntities context = new mov4eEntities())
            {
                var movies = from m in context.Movies where m.duration >= min && m.duration < max && m.pg == pg select new { m.id, m.picture };
                foreach (var item in movies)
                {
                    moviesList.Add(item.id, item.picture);
                }

                return moviesList;
            }
        }

        /// <summary>
        /// The <c>GetMovie()</c> method gets a Movie and its genre from the database by its id.
        /// </summary>
        /// <param name="id">This is the id of a certain Movie.</param>
        /// <returns>This method returns a Tuple from the type Movie(represents a full object from this type) 
        /// and string(represents the genre of the Movie with words).</returns>
        public Tuple<Movie, string> GetMovie(int id)
        {
            Movie returnMovie = new Movie();
            string returnGenre = "";
            using (mov4eEntities context = new mov4eEntities())
            {
                var Movie = context.Movies.Find(id);
                var genre = from g in context.Genres where Movie.genre == g.id select g.name;
                returnMovie = Movie;
                returnGenre = genre.ToList<string>()[0];
            }
            return new Tuple<Movie, string>(returnMovie, returnGenre);
        }

        /// <summary>
        /// The <c>GetMovies()</c> method gets all movies from the database as 
        /// a dictionary from the id of the Movie and the wrapper of the Movie.
        /// </summary>
        /// <returns>This method returns a dictionary from the movies' 
        /// ids(int) and the movies' genres in words(string).</returns>
        public Dictionary<int, byte[]> GetMovies()
        {
            Dictionary<int, byte[]> moviesWithPics = new Dictionary<int, byte[]>();
            using (mov4eEntities context = new mov4eEntities())
            {
                var movies = from mov in context.Movies
                             select new
                             {
                                 mov.id,
                                 mov.picture
                             };

                foreach (var el in movies)
                {
                    moviesWithPics.Add(el.id, el.picture);
                }
                return moviesWithPics;
            }
        }

        /// <summary>
        /// The <c>EditMovie()</c> method edits a certain Movie's fields using 
        /// the private methods for editing any of the fields. 
        /// </summary>
        /// <param name="id">This is the id of a certain Movie.</param>
        /// <param name="title">This is the title of a certain Movie.</param>
        /// <param name="genre">This is the genre of a certain Movie.</param>
        /// <param name="pg">This is the parental guidance of a certain Movie.</param>
        /// <param name="date">This is the prime date of a certain Movie.</param>
        /// <param name="summary">This is the summary of a certain Movie.</param>
        /// <param name="picture">This is the wrapper of a certain Movie.</param>
        /// <exception cref="Mov4e.Exceptions.ImpossibleDataBaseRecordUpdateException">Thrown when some 
        /// of the field's data is in incorrect format.</exception>
        /// <remarks>When the exception is thrown the method writes it in a log file called errors.txt</remarks>
        public void EditMovie(int id, string title, int genre, int pg,
            Nullable<DateTime> date, string summary, byte[] picture, int dur)
        {
            if (id > 0)
            {
                if (title != null && genre != 0 && pg != null && picture != null && date != null && summary != null && dur>=0)
                {
                    EditTitle(id, title);
                    EditPicture(id, picture);
                    EditGenre(id, genre);
                    EditPg(id, pg);
                    EditYear(id, date);
                    EditSummary(id, summary);
                    EditDuration(id, dur);
                }
                else
                {
                    Logger.Logger.WriteToLogFile(DateTime.Now.ToString() + " Maybe in some of the fields" +
                    " there is incorrect data! Please, check them and then try to update this Movie!" + "\n"
                        + new ImpossibleDataBaseRecordUpdateException().ToString() + "\n");
                    throw new ImpossibleDataBaseRecordUpdateException();
                }
            }
            else
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString() + " The Movie's id is incorrect!" + "\n"
                    + new NotFoundSuchItemException().ToString() + "\n");
                throw new NotFoundSuchItemException();
            }
        }

        /// <summary>
        /// The <c>DeleteMovie()</c> method deletes a certain Movie by its id.
        /// </summary>
        /// <param name="id">This is the id of a certain Movie.</param>
        /// <exception cref="Mov4e.Exceptions.NotFoundSuchItemException">Thrown when the id of the Movie
        /// that we want to delete is invalid.</exception>
        /// <remarks>When the exception is thrown the method writes it in a log file called errors.txt</remarks>
        public void DeleteMovie(int id)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                var deleteQuery = context.Movies.Find(id);
                if (deleteQuery != null)
                {
                    context.Movies.Remove(deleteQuery);
                    context.SaveChanges();
                }
                else
                {
                    Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                        + " The item which you want to delete is not found!" + "\n"
                        + new NotFoundSuchItemException().ToString());
                    throw new NotFoundSuchItemException();
                }
            }
        }

        /// <summary>
        /// The <c>FilterByTitle()</c> method filters the Movie alphabetically.
        /// </summary>
        /// <exception cref="Mov4e.Exceptions.NoDataBaseTableRecordsException">
        /// Thrown when the count of the list of movies is less or equal to zero.</exception>
        /// <remarks>When the exception is thrown the method writes it in a log file called errors.txt</remarks>
        /// <returns>The method rwturns a dictionary from the movies' 
        /// ids(int) and the movies' wrappers(byte[]).</returns>
        public Dictionary<int, byte[]> SortMoviesByTitle()
        {
            Dictionary<int, byte[]> movies = new Dictionary<int, byte[]>();
            using (mov4eEntities context = new mov4eEntities())
            {
                var sortedMovies = from m in context.Movies orderby m.title select m;
                foreach (var item in sortedMovies)
                {
                    movies.Add(item.id, item.picture);
                }
                return movies;
            }
        }

        /// <summary>
        /// The <c>SortByTitle()</c> method sorts all movies from the database alphabetically by their titles.
        /// </summary>
        /// <returns>The method rwturns a dictionary from the movies' 
        /// ids(int) and the movies' wrappers(byte[]).</returns>
        public Dictionary<int, byte[]> SortByDate()
        {
            Dictionary<int, byte[]> movies = new Dictionary<int, byte[]>();
            using (mov4eEntities context = new mov4eEntities())
            {
                var sortedMovies = from m in context.Movies orderby m.year select m;
                foreach (var item in sortedMovies)
                {
                    movies.Add(item.id, item.picture);
                }
                return movies;
            }
        }

        /// <summary>
        /// The <c>FilterMovies()</c> method filters all movies from the database 
        /// by genre, duration interval and parental guidance at he same time.
        /// </summary>
        /// <param name="g">This is the genre - one of the filtering params.</param>
        /// <param name="d">This is the duration - one of the filtering params.</param>
        /// <param name="pg">This is the parental guidance - one of the fltering params.</param>
        /// <returns>This method returns a dictionary from the filtered movies' ids (int) 
        /// and the filtered movies' wrappers (byte[]) from the database.</returns>
        public Dictionary<int, byte[]> FilterMovies(int g, int d, int pg)
        {
            if (d==1)
            {
                return FilterLessThanHour(g, pg);
            }
            else if (d == 2)
            {
                return FilterBetweenOneAndTwoHours(g, pg);
            }
            else if (d == 3)
            {
                return FilterBetweenTwoAndThreeHours(g, pg);
            }
            else if (d == 4)
            {
                return FilterMoreThanThreeHours(g, pg);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// The <c>FilterMoviesByGenresAndDuration()</c> method filters all 
        /// movies from the database by genre and duration at the same time.
        /// </summary>
        /// <param name="g">This is the genre - one of the filtering params.</param>
        /// <param name="d">This is the duration - one of the filtering params.</param>
        /// <returns>This method returns a dictionary from the filtered movies' ids (int) 
        /// and the filtered movies' wrappers (byte[]) from the database.</returns>
        public Dictionary<int, byte[]> FilterMoviesByGenresAndDuration(int g, int d)
        {
            if (d == 1)
            {
                return GetMoviesInACertainDurationGenreInterval(g, 0, 60);
            }
            else if (d == 2)
            {
                return GetMoviesInACertainDurationGenreInterval(g, 60, 120);
            }
            else if (d == 3)
            {
                return GetMoviesInACertainDurationGenreInterval(g, 120, 180);
            }
            else if (d == 4)
            {
                return GetMoviesInACertainDurationGenreInterval(g, 180, int.MaxValue);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// The <c>FilterM oviesByGenreAndPG()</c> method filters all movies 
        /// from the database by genre and pg at the same time.
        /// </summary>
        /// <param name="g">This is the genre - one of the filtering params.</param>
        /// <param name="pg">This is the pg - one of the filtering params.</param>
        /// <returns>This method returns a dictionary from the filtered movies' ids (int) 
        /// and the filtered movies' wrappers (byte[]) from the database.</returns>
        public Dictionary<int, byte[]> FilterMoviesByGenresAndPG(int g, int pg)
        {
            Dictionary<int, byte[]> moviesList = new Dictionary<int, byte[]>();
            using (mov4eEntities context = new mov4eEntities())
            {
                    var movies = from m in context.Movies where m.genre == g && m.pg == pg select new { m.id, m.picture };
                    foreach (var item in movies)
                    {
                        moviesList.Add(item.id, item.picture);
                    }
                
            }
            return moviesList;
        }

        /// <summary>
        /// The <c>FilterM oviesByDurationAndPG()</c> method filters all movies 
        /// from the database by duration and pg at the same time.
        /// </summary>
        /// <param name="d">This is the duration - one of the filtering params.</param>
        /// <param name="pg">This is the pg - one of the filtering params.</param>
        /// <returns>This method returns a dictionary from the filtered movies' ids (int) 
        /// and the filtered movies' wrappers (byte[]) from the database.</returns>
        public Dictionary<int, byte[]> FilterMoviesByDurationAndPG(int d, int pg)
        {
            if (d == 1)
            {
                return GetMoviesInACertainDurationPGInterval(pg, 0, 60);
            }
            else if (d == 2)
            {
                return GetMoviesInACertainDurationPGInterval(pg, 60, 120);
            }
            else if (d == 3)
            {
                return GetMoviesInACertainDurationPGInterval(pg, 120, 180);
            }
            else if (d == 4)
            {
                return GetMoviesInACertainDurationPGInterval(pg, 180, int.MaxValue);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// The <c>FilterM oviesByGenre()</c> method filters all movies 
        /// from the database by genre.
        /// </summary>
        /// <param name="g">This is the genre - one of the filtering params.</param>
        /// <returns>This method returns a dictionary from the filtered movies' ids (int) 
        /// and the filtered movies' wrappers (byte[]) from the database.</returns>
        public Dictionary<int, byte[]> FilterMoviesByGenres(int g)
        {
            Dictionary<int, byte[]> moviesList = new Dictionary<int, byte[]>();
            using (mov4eEntities context = new mov4eEntities())
            {
                    int genre = g; 

                    var movies = from m in context.Movies where m.genre == genre select new { m.id, m.picture };
                    foreach (var item in movies)
                    {
                        moviesList.Add(item.id, item.picture);
                    }
                
                return moviesList;
            }
        }

        /// <summary>
        /// The <c>FilterM oviesByDuration()</c> method filters all movies 
        /// from the database by duration.
        /// </summary>
        /// <param name="d">This is the duration - one of the filtering params.</param>
        /// <returns>This method returns a dictionary from the filtered movies' ids (int) 
        /// and the filtered movies' wrappers (byte[]) from the database.</returns>
        public Dictionary<int, byte[]> FilterMoviesByDuration(int d)
        {
            Dictionary<int, byte[]> moviesList = new Dictionary<int, byte[]>();
            using (mov4eEntities context = new mov4eEntities())
            {
                if (d == 1)
                {
                    var movies = from m in context.Movies where m.duration >= 0 && m.duration < 60 select new { m.id, m.picture };
                    foreach (var item in movies)
                    {
                        moviesList.Add(item.id, item.picture);
                    }
                }
                else if (d == 2)
                {
                    var movies = from m in context.Movies where m.duration >= 60 && m.duration < 120 select new { m.id, m.picture };
                    foreach (var item in movies)
                    {
                        moviesList.Add(item.id, item.picture);
                    }
                }
                else if (d == 3)
                {
                    var movies = from m in context.Movies where m.duration >= 120 && m.duration < 180 select new { m.id, m.picture };
                    foreach (var item in movies)
                    {
                        moviesList.Add(item.id, item.picture);
                    }
                }
                else if (d == 4)
                {
                    var movies = from m in context.Movies where m.duration >= 180 select new { m.id, m.picture };
                    foreach (var item in movies)
                    {
                        moviesList.Add(item.id, item.picture);
                    }
                }
            }
            return moviesList;
        }

        /// <summary>
        /// The <c>FilterM oviesByPG()</c> method filters all movies 
        /// from the database by pg.
        /// </summary>
        /// <param name="pg">This is the pg - one of the filtering params.</param>
        /// <returns>This method returns a dictionary from the filtered movies' ids (int) 
        /// and the filtered movies' wrappers (byte[]) from the database.</returns>
        public Dictionary<int, byte[]> FilterMoviesByPG(int pg)
        {
            Dictionary<int, byte[]> moviesList = new Dictionary<int, byte[]>();
            using (mov4eEntities context = new mov4eEntities())
            {
                var movies = from m in context.Movies where m.pg == pg select new { m.id, m.picture };
                foreach (var item in movies)
                {
                    moviesList.Add(item.id, item.picture);
                }
                return moviesList; 
            }
        }

        /// <summary>
        /// The <c>GetMoviesByTitles()</c> method gets a list of all movies' titles.
        /// </summary>
        /// <param name="titles">This is a list of movies' titles.</param>
        /// <returns>The method rwturns a dictionary from the movies' 
        /// ids(int) and the movies' genres in words(string).</returns>
        public Dictionary<int, byte[]> GetMoviesByTitles(List<string> titles)
        {
            Dictionary<int, byte[]> moviesWithPics = new Dictionary<int, byte[]>();
            using (mov4eEntities context = new mov4eEntities())
            {
                for (int i = 0; i < titles.Count; i++)
                {
                    string title = titles[i];
                    var titlesQuery = from m in context.Movies where m.title == title select m;
                    foreach (var m in titlesQuery)
                    {
                        moviesWithPics.Add(m.id, m.picture);
                    }
                }
            }
            return moviesWithPics;
        }

        /// <summary>
        /// The <c>GetMovieTitle()</c> gets a certain Movie's title by its id.
        /// </summary>
        /// <param name="movieId">This is the id of a certain Movie.</param>
        /// <returns>The method returns a certain's Movie title.</returns>
        public string GetMovieTitle(int movieId)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                var currentMovieTitle = (from mov in context.Movies
                                         where mov.id == movieId
                                         select mov.title)
                                                     .First();

                return currentMovieTitle;
            }
        }

        /// <summary>
        /// The <c>GetMoviesTitles()</c> method gets a list of all movies' titles.
        /// </summary>
        /// <returns>The method returns the all movies' titles.</returns>
        public List<string> GetMoviesTitles()
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                var titlesQuery = from m in context.Movies select m.title;
                return titlesQuery.ToList<string>();
            }
        }

        /// <summary>
        /// The <c>GetUserInfo()</c> method gets a tuple of a certain user's id and a certain user's position.
        /// </summary>
        /// <param name="unm">This is the username of the user.</param>
        /// <param name="pass">This is the password of the user.</param>
        /// <returns>The method returns both the user's id and the user's position by their credentials.</returns>
        public Tuple<int, string> GetUserInfo(string unm, string pass)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                int id = 0;
                string pos = "";

                var userId = from u in context.Users where u.userName == unm && u.password == pass select u.id;
                foreach (var item in userId)
                {
                    id = item;
                }

                var userPos = from u in context.UserInfoes where u.id == id select u.position;
                foreach (var item in userPos)
                {
                    pos = item;
                }
                return new Tuple<int, string>(id, pos);
            }
        }

        /// <summary>
        /// The <c>GetMovieGenre()</c> method gets a certain's Movie's genre as 
        /// a number(id from the database) by its name.
        /// </summary>
        /// <param name="gen">This is the genre's name.</param>
        /// <returns>This method returns the id of a certain genre.</returns>
        public int GetMovieGenre(string gen)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                var genre = (from genr in context.Genres where genr.name == gen select genr.id).First();
                return genre;
            }
        }
    }
}
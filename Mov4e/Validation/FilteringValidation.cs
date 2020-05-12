using Mov4e.Exceptions;
using Mov4e.Presenter.AllMoviesPresenter;
using System.Collections.Generic;

namespace Mov4e.Validation
{
    /// <summary>
    /// 
    /// </summary>
    public static class FilteringValidation
    {
        /// <summary>
        /// The <c>FilteringValidation</c> is a public static validation class.
        /// </summary>
        public static IAllMoviesPresenter rp = new AllMoviesPresenter();

        /// <summary>
        /// The <c>ValidateFilterMovies()</c> method validates the movies from the database by genre, duration 
        /// and parental guidance values for the method which filters the movies from the database by genre, 
        /// duration and parental guidance at the same time.
        /// </summary>
        /// <param name="g">This is the genre - one of the filtering params.</param>
        /// <param name="d">This is the duration - one of the filtering params.</param>
        /// <param name="pg">This is the parental guidance - one of the filtering params.</param>
        /// <exception cref="InvalidFilteringParamsException">thrown when the value 
        /// of any filtering param is in incorrect format.</exception>
        /// <returns>This method returns a dictionary from the 
        /// filtered movies' ids(int) and filtered movies' wrappers(byt[]).</returns>
        public static Dictionary<int, byte[]> ValidateFilterMovies(int g, int d, int pg)
        {
            if (g > 0 && d > 0 && pg > -1)
            {
                return rp.FilterMovies(g, d, pg);
            }
            else
            {
                throw new InvalidFilteringParamsException();
            }
        }

        /// <summary>
        /// The <c>ValidateFilterMoviesByGenresAndDuration()</c> method validates the movies from the database by 
        /// genre and duration values for the method which filters the movies from the database 
        /// by genre and duration at the same time.
        /// </summary>
        /// <param name="g">This is the genre - one of the filtering params.</param>
        /// <param name="d">This is the duration - one of the filtering params.</param>
        /// <exception cref="InvalidFilteringParamsException">thrown when the value 
        /// of any filtering param is in incorrect format.</exception>
        /// <returns>This method returns a dictionary from the 
        /// filtered movies' ids(int) and filtered movies' wrappers(byt[]).</returns>
        public static Dictionary<int, byte[]> ValidateFilterMoviesByGenreAndDuration(int g, int d)
        {
            if (g > 0 && d > 0)
            {
                return rp.FilterMoviesByGenresAndDuration(g, d);
            }
            else
            {
                throw new InvalidFilteringParamsException();
            }
        }

        /// <summary>
        /// The <c>ValidateFilterMoviesByGenresAndPG()</c> method validates the movies from the database by 
        /// genre and duration values for the method which filters the movies from the database 
        /// by genre and duration at the same time.
        /// </summary>
        /// <param name="g">This is the genre - one of the filtering params.</param>
        /// <param name="d">This is the duration - one of the filtering params.</param>
        /// <exception cref="InvalidFilteringParamsException">thrown when the value 
        /// of any filtering param is in incorrect format.</exception>
        /// <returns>This method returns a dictionary from the 
        /// filtered movies' ids(int) and filtered movies' wrappers(byt[]).</returns>
        public static Dictionary<int, byte[]> ValidateFilterMoviesByGenreAndPG(int g, int pg)
        {
            if (g > 0 && pg > -1)
            {
                return rp.FilterMoviesByGenresAndPG(g, pg);
            }
            else
            {
                throw new InvalidFilteringParamsException();
            }
        }

        /// <summary>
        /// The <c>ValidateFilterMoviesByDurationAndPG()</c> method validates the movies from the database by 
        /// duration and parental guidance values for the method which filters the movies from the database 
        /// by genre and parental guidance at the same time.
        /// </summary>
        /// <param name="d">This is the duration - one of the filtering params.</param>
        /// <param name="pg">This is the parental guidance - one of the filtering params.</param>
        /// <exception cref="InvalidFilteringParamsException">thrown when the value 
        /// of any filtering param is in incorrect format.</exception>
        /// <returns>This method returns a dictionary from the 
        /// filtered movies' ids(int) and filtered movies' wrappers(byt[]).</returns>
        public static Dictionary<int, byte[]> ValidateFilterMoviesByDurationAndPG(int d, int pg)
        {
            if (d > 0 && pg > -1)
            {
                return rp.FilterMoviesByDurationAndPG(d, pg);
            }
            else
            {
                throw new InvalidFilteringParamsException();
            }
        }

        /// <summary>
        /// The <c>ValidateFilterMoviesByGenres()</c> method validates the movies from the database by 
        /// genre value for the method which filters the movies from the database 
        /// by genre.
        /// </summary>
        /// <param name="g">This is the genre - one of the filtering params.</param>
        /// <exception cref="InvalidFilteringParamsException">thrown when the value 
        /// of any filtering param is in incorrect format.</exception>
        /// <returns>This method returns a dictionary from the 
        /// filtered movies' ids(int) and filtered movies' wrappers(byt[]).</returns>
        public static Dictionary<int, byte[]> ValidateFilterMoviesByGenre(int g)
        {
            if (g > 0)
            {
                return rp.FilterMoviesByGenres(g);
            }
            else
            {
                throw new InvalidFilteringParamsException();
            }
        }

        /// <summary>
        /// The <c>ValidateFilterMoviesByDuration()</c> method validates the movies from the database by 
        /// duration value for the method which filters the movies from the database 
        /// by duration.
        /// </summary>
        /// <param name="d">This is the duration - one of the filtering params.</param>
        /// <exception cref="InvalidFilteringParamsException">thrown when the value 
        /// of any filtering param is in incorrect format.</exception>
        /// <returns>This method returns a dictionary from the 
        /// filtered movies' ids(int) and filtered movies' wrappers(byt[]).</returns>
        public static Dictionary<int, byte[]> ValidateFilterMoviesByDuration(int d)
        {
            if (d > 0)
            {
                return rp.FilterMoviesByDuration(d);
            }
            else
            {
                throw new InvalidFilteringParamsException();
            }
        }

        /// <summary>
        /// The <c>ValidateFilterMoviesByPG()</c> method validates the movies from the database by 
        /// parental guidance value for the method which filters the movies from the database 
        /// by parental guidance.
        /// </summary>
        /// <param name="pg">This is the parental guidance - one of the filtering params.</param>
        /// <exception cref="InvalidFilteringParamsException">thrown when the value 
        /// of any filtering param is in incorrect format.</exception>
        /// <returns>This method returns a dictionary from the 
        /// filtered movies' ids(int) and filtered movies' wrappers(byt[]).</returns>
        public static Dictionary<int, byte[]> ValidateFilterMoviesByPG(int pg)
        {
            if (pg > -1)
            {
                return rp.FilterMoviesByPG(pg);
            }
            else
            {
                throw new InvalidFilteringParamsException();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using Mov4e.Exceptions;
using System.Linq;
using Mov4e.Model;

namespace Mov4e.Repository.NewMovieRepository
{
    /// <summary>
    /// The <c>NewMovieRepository</c> class is a repository class which communicates with the database.
    /// </summary>
    /// <inheritdoc cref="INewMovieRepository"/>
    public class NewMovieRepository: INewMovieRepository
    {
        // A private variable that keeps reference to a movie object.
        private Movie m = new Movie();
        
        /// <summary>
        /// A no arguments constructor for the <c>NewMovieRepository</c> class.
        /// </summary>
        public NewMovieRepository()
        {

        }

        /// <summary>
        /// The <c>CreateMovie()</c> method creates a new movie by received parameters and saves it into the database.
        /// </summary>
        /// <param name="tit">This is the title of the movie.</param>
        /// <param name="pG">This is the parental guidness of the movie.</param>
        /// <param name="gen">This is the genre of the movie.</param>
        /// <param name="y">This is the prime date of the movie.</param>
        /// <param name="sum">This is the summary of the movie.</param>
        /// <param name="pict">This is the wrapper of the movie.</param>
        /// <exception cref="Mov4e.Exceptions.ImpossibleDataBaseRecordCreateException">Thrown when
        /// some of the fields is in incorrect format.</exception>
        /// <remarks>When the exception is thrown the method writes it in a log file called errors.txt</remarks>
        public void CreateMovie(string tit, Nullable<int> pG, int gen, 
            Nullable<System.DateTime> y, string sum, byte[] pict, int dur)
        {
            try
            {
                if (tit != null && pG != null && gen != 0 && y != null && sum != null && pict != null)
                {
                    m.title = tit;
                    m.pg = pG;
                    m.genre = gen;
                    m.year = y;
                    m.summary = sum;
                    m.picture = pict;
                    m.duration = dur;
                    SaveMovie();
                }
                else
                {
                    throw new ImpossibleDataBaseRecordCreateException();
                }
            }
            catch (ImpossibleDataBaseRecordCreateException ex)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString() + " Maybe in some of the fields" +
                    " there is incorrect data! Please, check them, then try to save this movie!" + "\n"
                    + ex.ToString() + "\n");
            }
        }
        
        /// <summary>
        /// The <c>SaveMovie</c> method saves the movie in the database.
        /// </summary>
        public void SaveMovie()
        {
            List<Movie> movies = new List<Movie>();
            using (mov4eEntities context = new mov4eEntities())
            {
                movies.Add(m);
                context.Movies.Add(m);
                context.SaveChanges();
            }
        }

        public int LastMovieId()
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                return context.Movies.OrderByDescending(m => m.id).First().id;
            }
        }
    }
}
using Mov4e.Repository.NewMovieRepository;
using System;

namespace Mov4e.Service.NewMovieService
{
    /// <summary>
    /// The <c>NewMovieService</c> class is a service class that communicates with the <c>NewMovieRepository</c> class.
    /// </summary>
    /// <inheritdoc cref="INewMovieService"/>
    public class NewMovieService: INewMovieService
    {
        // A private variable that keeps reference to the NewMovieRepository via an interface variable.
        private INewMovieRepository mr = new NewMovieRepository();                          
        
        /// <summary>
        /// A no arguments constructor for <c>NewMovieService</c> class.
        /// </summary>
        public NewMovieService()
        {

        }

        /// <summary>
        /// The <c>CreateMovie()</c> method receives from the presenter as parameters - a certain movie's 
        /// title, parental guidness, genre, prime date, summary and wrapper and executes the repository's
        /// method which is responsible of creating a new movie and saving it in the database.
        /// </summary>
        /// <param name="t">This is the title of the movie.</param>
        /// <param name="pg">This is the parental guidness of the movie.</param>
        /// <param name="g">This is the genre of the movie.</param>
        /// <param name="p">This is the prime date of the movie.</param>
        /// <param name="s">This is the summary of the movie.</param>
        /// <param name="pic">This is the wrapper of the movie.</param>
        public void CreateMovie(string t, Nullable<int> pg, int g, 
        Nullable<System.DateTime> p, string s, byte[] pic, int dur)
        {
            mr.CreateMovie(t, pg, g, p, s, pic, dur);
        }

        public int IdOfTheLastMovie()
        {
            return mr.LastMovieId();
        }
    }
}
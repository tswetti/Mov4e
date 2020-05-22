using Mov4e.Service.NewMovieService;
using Mov4e.View.NewMovieView;
using System;

namespace Mov4e.Presenter.NewMoviePresenter
{
    /// <summary>
    /// The <c>NewMoviePresenter</c> class is a presenter class which communicates with the <c>NewMovieService</c> class.
    /// </summary>
    /// <inheritdoc cref="INewMoviePresenter"/>
    public class NewMoviePresenter: INewMoviePresenter
    {
        // A private varaible that keeps a referenece to NewMovieForm via an interface variable.
        private INewMovie mv=new mov4eAddMovie();

        // A private variable that keeps a reference to NewMovieService via an interface varaible.
        private INewMovieService ms = new NewMovieService();    

        /// <summary>
        /// This is a no arguments constructor for <c>NewMoviePresenter</c> class.
        /// </summary>
        public NewMoviePresenter()
        {
            
        }

        public NewMoviePresenter(INewMovieService _inewMovieService)
        {
            this.ms = _inewMovieService;
        }
        
        /// <summary>
        /// This is a constructor for <c>NewMoviePresenter</c> class with a parameter.
        /// </summary>
        /// <param name="m">This is a NewMovieForm as an interface variable.</param>
        public NewMoviePresenter(INewMovie m)
        {
            this.mv = m;
        }

        /// <summary>
        /// The <c>AddMovie()</c> method receives as parameters a certain movie's title, genre, parental guidness, 
        /// prime date, summary and wrapper and executes the servce's method which is responsible of adding a new movie 
        /// in the database.
        /// </summary>
        /// <param name="title">This is the title of the movie.</param>
        /// <param name="genre">This is the genre of the movie.</param>
        /// <param name="pg">This is the parental guidness of the movie.</param>
        /// <param name="date">This is the prime date of the movie.</param>
        /// <param name="summary">This is the summary of the movie.</param>
        /// <param name="pic">This is the wrapper of the movie.</param>
        public void AddMovie(string title, int genre, Nullable<int> pg, 
        Nullable<System.DateTime> date, string summary, byte[] pic, int dur)
        {
            ms.CreateMovie(title, pg, genre, date, summary, pic, dur);
        }

        public int LastMovieId()
        {
            return ms.IdOfTheLastMovie();
        }
    }
}
using Mov4e.Exceptions;
using Mov4e.Presenter.NewMoviePresenter;
using Mov4e.Presenter.AllMoviesPresenter;
using System;
using System.IO;
using System.Windows.Forms;

namespace Mov4e.Validation
{
    /// <summary>
    /// The <c>MovieValidation</c> class is a public static (validator) class for the movie's fields.
    /// </summary>
    public static class MovieValidation
    {
        public static bool ValidateId(int id)
        {
            if (id > 0)
                return true;
            else
                return false;
            
        }
        // This method validates the title of a movie with a certain id.
        public static bool ValidateTitle(string title)
        {
            if (title != null && title != "" && title.Length > 0)
                return true;
            else
                return false;
        }

        // This method validates the genre of a movie with a certain id.
        public static bool ValidateGenre(int genre)
        {
            if (genre > 0)
                return true;
            else
                return false;
        }

        // This method validates the parental guidness of a movie with a certain id.
        public static bool ValidatePG(Nullable<int> pg)
        {
            if (pg >= 0)
                return true;
            else
                return false;
        }

        // This method validates the prime date of a movie with a certain id.
        public static bool ValidateDate(Nullable<DateTime> date)
        {
            if (date != null)
                return true;
            else
                return false;
        }

        // This method validates the summary of a movie with a certain id.
        public static bool ValidateSummary(string summary)
        {
            if (summary != null && summary != "" && summary.Length > 0)
                return true;
            else
                return false;
        }

        // This method validates the wrapper of a movie with a certain id.
        public static bool ValidateWrapper(byte[] wrapper)
        {
            if (wrapper != null && wrapper.Length > 0)
                return true;
            else
                return false;
        }

        public static bool ValidateDuration(int dur)
        {
            if (dur >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// The <c>ValidateNewMovie()</c> method receives as parameters - a certain movie's
        /// title, genre, parental gidness, prime date, summary and wrapper and uses the private 
        /// methods for validation of this class in order to check whether all fields for 
        /// creating a new movie are correctly filled.
        /// </summary>
        /// <param name="title">This is the title of the movie.</param>
        /// <param name="genre">This is the genre of the movie.</param>
        /// <param name="pg">This is the parental guidness of the movie.</param>
        /// <param name="date">This is the prime date of the movie.</param>
        /// <param name="summary">This is the summary of the movie.</param>
        /// <param name="wrapper">This is the wrapper of the movie.</param>
        /// <exception cref="Mov4e.Exceptions.InvalidFieldInputException">Throw when
        /// any of the fields are incorectly filled.</exception>
        /// <remarks>When the exception is thrown this methods writes the error in the error.txt file.</remarks>
        public static void ValidateNewMovie(string title, int genre, Nullable<int> pg, 
            Nullable<DateTime> date, string summary, byte[] wrapper, int dur)
        {
                INewMoviePresenter movie_presenter = new NewMoviePresenter();
                if (ValidateTitle(title) && ValidateGenre(genre) && ValidatePG(pg) &&
                    ValidateDate(date) && ValidateSummary(summary) && ValidateWrapper(wrapper) && ValidateDuration(dur))
                {
                    movie_presenter.AddMovie(title, genre, pg, date, summary, wrapper, dur);
                    MessageBox.Show("You successfully added a new movie!", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("All fields are required! For more information about that " +
                        "check the errors.txt file, please!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    Logger.Logger.WriteToLogFile(DateTime.Now.ToString() + " You tried to add new movie but you didn't fill "
                        + "\n" + "all fields, so the application cannot create a movie with this data! "
                        + new InvalidFieldInputException().ToString() + "\n");
                    throw new InvalidFieldInputException();
                }
        }

        /// <summary>
        /// The <c>ValidateMovieUpdate()</c> method receives as parameters - a certain movie's
        /// title, genre, parental gidness, prime date, summary and wrapper and uses the private 
        /// methods for validation of this class in order to check whether all fields for 
        /// updating a certain movie are correctly filled.
        /// </summary>
        /// <param name="title">This is the title of the movie.</param>
        /// <param name="genre">This is the genre of the movie.</param>
        /// <param name="pg">This is the parental guidness of the movie.</param>
        /// <param name="date">This is the prime date of the movie.</param>
        /// <param name="summary">This is the summary of the movie.</param>
        /// <param name="wrapper">This is the wrapper of the movie.</param>
        /// <exception cref="Mov4e.Exceptions.InvalidFieldInputException">Throw when
        /// any of the fields are incorectly filled.</exception>
        /// <remarks>When the exception is thrown this methods writes the error in the error.txt file.</remarks>
        public static void ValidateMovieUpdate(int id, string title, int genre, Nullable<int> pg,
            Nullable<DateTime> date, string summary, byte[] wrapper, int dur)
        {
                if (ValidateId(id) && ValidateTitle(title) && ValidateGenre(genre) && ValidatePG(pg) &&
                    ValidateDate(date) && ValidateSummary(summary) && ValidateWrapper(wrapper) && ValidateDuration(dur))
                {
                    IAllMoviesPresenter all_movies_presenter = new AllMoviesPresenter();
                    all_movies_presenter.EditMovie(id, title, genre, (int)pg, date, summary, wrapper, dur);
                    MessageBox.Show("You successfully updated this movie!", "Movie's Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("All fields are required! For more information about that " +
                        "check the errors.txt file, please!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    Logger.Logger.WriteToLogFile(DateTime.Now.ToString() + " You tried to update a movie but you didn't fill "
                        + "\n" + "all fields, so the application cannot create a movie with this data! "
                        + new InvalidFieldInputException().ToString() + "\n");

                    throw new InvalidFieldInputException();
                }
        }
    }
}
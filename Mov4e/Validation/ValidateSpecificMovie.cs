using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Exceptions;

namespace Mov4e.Validation
{
    public static class ValidateSpecificMovie
    {
        public static void isCommentOK(string comment)
        {
            if (string.IsNullOrEmpty(comment) || string.IsNullOrWhiteSpace(comment))
            {
                throw new SpecificMovieException("Your comment cant be nothing!");
            }
        }

        public static void isRateOk(int rate)
        {
            if (rate<1 || rate> 5 && rate != null )
            {
                throw new SpecificMovieException("Your rate can only be between 1 and 5!");
            }
        }

        public static void isThereMovie(int movieId)
        {
            if (movieId <=0 && movieId != null)
            {
                throw new SpecificMovieException("There is no selected movie!");
            }
        }

        public static void isThereAnUser(int userId)
        {
            if (userId <=0 && userId != null)
            {
                throw new SpecificMovieException("There is no user!");
            }
        }

        public static void isThereAnythingToRemoveOrAddFromWatchList(int movieId)
        {
            if (movieId<0 && movieId!=null)
            {
                throw new SpecificMovieException("There is no selected movie to remove or add from watchlist!");
            }
        }

        public static void isThereCommentToRemove(List<int> comments)
        {
            if (comments.Count==0 || comments==null)
            {
                throw new SpecificMovieException("You must select comments to remove!");
            }
        }

        public static void areThereCommentsInCounter(int count)
        {
            if (count<=0)
            {
                throw new SpecificMovieException("No Comments added!");
            }
        }

    }
}

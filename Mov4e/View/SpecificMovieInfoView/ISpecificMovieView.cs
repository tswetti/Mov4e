using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4e.View.SpecificMovieInfoView
{
    public interface ISpecificMovieView
    {
        int userId { get; set; }

        int movieId { get; set; }

        string movieTitle { get; set; }

        byte[] moviePicture { get; set; }

        string movieGenre { get; set; }

        Nullable<int> moviePG { get; set; }

        string moviePrimeDate { get; set; }

        string movieSummary { get; set; }

        double? movieAVGRate { get; set; }

        int duration { get; set; }

        int userRate { get; set; }

        void Visible(bool isVisible);

        string userPosition { get; set; }

        event EventHandler<SpecificMovieEventArgs> MovieDeletedFromWatchList;

        event EventHandler<SpecificMovieEventArgs> MovieAddedToWatchList;

        List<(int commentId, string name, byte[] picture, string comment)> comments { get; set; }

        void ErrorMassage(string msg);



    }    
}

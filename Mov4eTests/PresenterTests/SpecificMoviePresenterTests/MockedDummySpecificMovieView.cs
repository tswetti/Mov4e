using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.View.SpecificMovieInfoView;

namespace Mov4eTests.PresenterTests.SpecificMoviePresenterTests
{
    class MockedDummySpecificMovieView : ISpecificMovieView
    {
        public int userId { get; set; }
        public int movieId { get; set; }
        public string movieTitle { get; set; }
        public byte[] moviePicture { get; set; }
        public string movieGenre { get; set; }
        public int? moviePG { get; set; }
        public string moviePrimeDate { get; set; }
        public string movieSummary { get; set; }
        public double? movieAVGRate { get; set; }
        public string userPosition { get; set; }
        public int userRate { get; set; }
        public int duration { get; set; }
        public List<(int commentId, string name, byte[] picture, string comment)> comments { get; set; }

        public event EventHandler<SpecificMovieEventArgs> MovieDeletedFromWatchList;
        public event EventHandler<SpecificMovieEventArgs> MovieAddedToWatchList;

        public void ErrorMassage(string msg)
        {
            //ok
        }

        public void ShowForm()
        {
            
        }

        public void Visible(bool isVisible)
        {
           //ok
        }
    }
}

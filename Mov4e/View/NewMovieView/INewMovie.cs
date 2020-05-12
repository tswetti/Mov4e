using System;

namespace Mov4e.View.NewMovieView
{
    /// <summary>
    /// The <c>INewMovie</c> class is a public interface.
    /// </summary>
    public interface INewMovie
    {
        string title { get; set; }
        Nullable<int> pg { get; set; }
        int genre { get; set; }
        Nullable<System.DateTime> date { get; set; }
        string summary { get; set; }
        byte[] picture { get; set; }
        int duration { get; set; }
        void addNewMovie();
        void updateMovie();
    }
}
using System;

namespace Mov4e.Service.NewMovieService
{
    /// <summary>
    /// The <c>INewMovieService</c> is a public interface.
    /// </summary>
    public interface INewMovieService
    {
        void CreateMovie(string t, Nullable<int> pg, int g, Nullable<System.DateTime> p, string s, byte[] pic, int dur);
        int IdOfTheLastMovie();
    }
}
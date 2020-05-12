using System;

namespace Mov4e.Repository.NewMovieRepository
{
    /// <summary>
    /// The <c>INewMovieRepository</c> is a public interface.
    /// </summary>
    public interface INewMovieRepository
    {
        void SaveMovie();
        void CreateMovie(string tit, Nullable<int> pG, int gen, 
        Nullable<System.DateTime> y, string sum, byte[] pict, int dur);
        int LastMovieId();
    }
}
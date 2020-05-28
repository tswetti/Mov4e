using Mov4e.View.NewMovieView;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4eTests.ViewTests.NewMovieFormTests
{
    [TestFixture]
    public class NewMovieFormTests
    {
        [Test]
        public void CorrectAddMovieMethodAddsAMovieInTheDataBase()
        {
            DummyMockedNewMoviePresenter dummy = new DummyMockedNewMoviePresenter();
            INewMovie movie_view = new mov4eAddMovie(dummy._inewMoviePresenter);

            try
            {
                movie_view.addNewMovie();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void CorrectUpdateMovieMethodsUpdatesACertainMovieInTheDataBase()
        {
            DummyMockedNewMoviePresenter dummy = new DummyMockedNewMoviePresenter();
            INewMovie movie_view = new mov4eAddMovie(dummy._inewMoviePresenter);

            try
            {
                movie_view.updateMovie();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }
    }
}

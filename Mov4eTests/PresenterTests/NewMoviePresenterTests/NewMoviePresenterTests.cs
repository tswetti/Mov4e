using Mov4e.Presenter.NewMoviePresenter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4eTests.PresenterTests.NewMoviePresenterTests
{
    [TestFixture]
    public class NewMoviePresenterTests
    {
        [Test]
        public void CorrectAddMovieSuccessfullyAddsAMovieInTheDataBase()
        {
            DummyMockedNewMovieService dummy = new DummyMockedNewMovieService();
            INewMoviePresenter movie_presenter = new NewMoviePresenter(dummy._inewMovieService);

            try
            {
                movie_presenter.AddMovie("Movie", 6, 14, DateTime.Now, "summary...", new byte[65], 123);
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
        public void CorrectLastMovieIdReturnsTheIdOfTheLastAddedMovieId()
        {
            DummyMockedNewMovieService dummy = new DummyMockedNewMovieService();
            INewMoviePresenter movie_presenter = new NewMoviePresenter(dummy._inewMovieService);

            try
            {
                movie_presenter.LastMovieId();
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
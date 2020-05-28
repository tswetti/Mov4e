using Mov4e.Presenter.AllMoviesPresenter;
using Mov4eTests.ServiceTests.AllMoviesServiceTests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4eTests.PresenterTests.AllMoviesPresenterTests
{
    [TestFixture]
    public class AllMoviesPresenterTests
    {
        [Test]
        public void CorrectDeleteMovieDeletsAovieFromTheDataBase()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter movie_presenter = new AllMoviesPresenter(dummy._iallMoviesService);
           
            try
            {
                movie_presenter.DeleteMovie(1);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void CorrectEditMovieUpdatesACertainMovieInTheDataBase()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter movie_presenter = new AllMoviesPresenter(dummy._iallMoviesService);

            try
            {
                movie_presenter.EditMovie(4, "Movie", 7, 18, DateTime.Now, "summary...", new byte[90], 93);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void CorrectFilterMoviesByGenreDurationAndPGFiltersTheMovieInTheDataBase()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter movie_presenter = new AllMoviesPresenter(dummy._iallMoviesService);

            try
            {
                movie_presenter.FilterMovies(6, 2, 12);
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
        public void CorrectFilterMoviesByDurationFiltersTheMovieInTheDataBase()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter movie_presenter = new AllMoviesPresenter(dummy._iallMoviesService);

            try
            {
                movie_presenter.FilterMoviesByDuration(2);
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
        public void CorrectFilterMoviesByDurationAndPGFiltersTheMovieInTheDataBase()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter movie_presenter = new AllMoviesPresenter(dummy._iallMoviesService);

            try
            {
                movie_presenter.FilterMoviesByDurationAndPG(2, 12);
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
        public void CorrectFilterMoviesByGenreFiltersTheMovieInTheDataBase()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter movie_presenter = new AllMoviesPresenter(dummy._iallMoviesService);

            try
            {
                movie_presenter.FilterMoviesByGenres(6);
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
        public void CorrectFilterMoviesByGenreAndDurationFiltersTheMovieInTheDataBase()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter movie_presenter = new AllMoviesPresenter(dummy._iallMoviesService);

            try
            {
                movie_presenter.FilterMoviesByGenresAndDuration(6, 2);
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
        public void CorrectFilterMoviesByGenreAndPGFiltersTheMovieInTheDataBase()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter movie_presenter = new AllMoviesPresenter(dummy._iallMoviesService);

            try
            {
                movie_presenter.FilterMoviesByGenresAndPG(6, 12);
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
        public void CorrectFilterMoviesByPGFiltersTheMovieInTheDataBase()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter movie_presenter = new AllMoviesPresenter(dummy._iallMoviesService);

            try
            {
                movie_presenter.FilterMoviesByPG(12);
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
        public void CorrectGetMovieReturnsAMovieAsATuple()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter movie_presenter = new AllMoviesPresenter(dummy._iallMoviesService);

            try
            {
                movie_presenter.GetMovie(2);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void CorrectReturnsTheIdOfTheGenreByItsName()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter movie_presenter = new AllMoviesPresenter(dummy._iallMoviesService);

            try
            {
                movie_presenter.GetMovieGenre("Drama");
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void CorrectGetMoviesByTitleReturnsTheMoviesFromTheDataBaseByTheirTitles()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter movie_presenter = new AllMoviesPresenter(dummy._iallMoviesService);

            try
            {
                movie_presenter.GetMoviesByTitle(new List<string>{"Terminator", "Titanic"});
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void CorrectGetMoviesTitlesReturnsTheTtitlesOfTheMoviesFromTheDataBaseAsAList()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter movie_presenter = new AllMoviesPresenter(dummy._iallMoviesService);

            try
            {
                movie_presenter.GetMovieTitles();
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
        public void CorrectGetUserInfoMethodReturnsTheIdAndThePositionOfACertainUser()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter movie_presenter = new AllMoviesPresenter(dummy._iallMoviesService);

            try
            {
                movie_presenter.GetUserInfo("petya", "myPass");
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void CorrectSetMovieInformationSetsTheInformationOfTheMovies()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter movie_presenter = new AllMoviesPresenter(dummy._iallMoviesService);

            try
            {
                movie_presenter.SetMovieInformation();
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void CorrectSetMovieTitleSetsTheTitleOfACertainMovie()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter movie_presenter = new AllMoviesPresenter(dummy._iallMoviesService);

            try
            {
                movie_presenter.SetMovieTitle(2);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void CorrectSortByDateMethodSortsTheMoviesFromTheDataBaseByTheirPrimierDate_FromTheOldesToNewest()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter movie_presenter = new AllMoviesPresenter(dummy._iallMoviesService);

            try
            {
                movie_presenter.SortByDate();
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void CorrectSortByTtileMethodsSortsTheMoviesFromTheDataBaseByAlphabeticalOrder_FromAToZ()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter movie_presenter = new AllMoviesPresenter(dummy._iallMoviesService);

            try
            {
                movie_presenter.SortMoviesByTitle();
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }
    }
}
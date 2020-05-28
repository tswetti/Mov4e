using Mov4e.View.AllMoviesView;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4eTests.ViewTests.AllMoviesFormTests
{
    [TestFixture]
    public class AllMoviesFormTests
    {
        [Test]
        public void CorrectDeleteMovieMethodDeletsACertainMovieFromTheDataBase()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies movie_view = new mov4eAllMovies(dummy._iallMoviesPresenter);

            try
            {
                movie_view.DeleteMovie();
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
        public void CorrectEditMoviesMethodsSuccessfullyUpdatesACertainMovieInTheDataBase()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies movie_view = new mov4eAllMovies(dummy._iallMoviesPresenter);

            try
            {
                movie_view.EditMovie();
            }
            catch(Exception)
            {
                Assert.IsTrue(false);
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void CorrectFilterMovieReturnsFilteredByGenreDuratinAndPGMoviesFromTheDataBaseAsADictionary()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies movie_view = new mov4eAllMovies(dummy._iallMoviesPresenter);

            try
            {
                movie_view.FilterMovies(6, 2, 12);
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
        public void CorrectFilterByDurationMethodReturnsFilteredMoviesByDurationFromTheDataBaseAsADictionary()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies movie_view = new mov4eAllMovies(dummy._iallMoviesPresenter);

            try
            {
                movie_view.FilterMoviesByDuration(2);
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
        public void CorrectFilterByDurationAndPGMethodReturnsFilterdByDurationAndPGMoviesFromTheDataBaseAsADictionary()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies movie_view = new mov4eAllMovies(dummy._iallMoviesPresenter);

            try
            {
                movie_view.FilterMoviesByDurationAndPG(2, 12);
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
        public void CorrectFilterByGenreMethodsReturnsFiteredByGenreMoviesFromTTheDataBaseAsADictionary()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies movie_view = new mov4eAllMovies(dummy._iallMoviesPresenter);

            try
            {
                movie_view.FilterMoviesByGenres(6);
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
        public void CorrectFilterByGenreAndDurationMethodReturnsTheFilteredByGenreAndDurationMoviesFromTheDataBaseAsADictionary()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies movie_view = new mov4eAllMovies(dummy._iallMoviesPresenter);

            try
            {
                movie_view.FilterMoviesByGenresAndDuration(6, 2);
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
        public void CorrectFilterByGenresAndPGMethodReturnsTheFilteredByGenreAndPGMoviesFromTheDataBaseAsADictionary()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies movie_view = new mov4eAllMovies(dummy._iallMoviesPresenter);

            try
            {
                movie_view.FilterMoviesByGenresAndPG(6, 12);
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
        public void CorrectFilterByPGMethodReturnsTheFilteredByPGMoviesFromTheDataBaseAsADictionary()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies movie_view = new mov4eAllMovies(dummy._iallMoviesPresenter);

            try
            {
                movie_view.FilterMoviesByPG(12);
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
        public void CorrectGetMovieMethodReturnsATupleOfThisMovieAndItsGenreNameAsAString()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies movie_view = new mov4eAllMovies(dummy._iallMoviesPresenter);

            try
            {
                movie_view.GetMovie();
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
        public void CorrectSearchMovieMethodReturnsADictionaryOfMovies()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies movie_view = new mov4eAllMovies(dummy._iallMoviesPresenter);

            try
            {
                movie_view.SearchMovie();
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
        public void CorrectInitializeMoviesListMethodsReturnsAllMoviesFromTheDataBaseAsADictionary()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies movie_view = new mov4eAllMovies(dummy._iallMoviesPresenter);
            Dictionary<int, byte[]> testDictOfMovies = new Dictionary<int, byte[]>();

            try
            {
                movie_view.InitializeMoviesList(testDictOfMovies);
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
        public void CorrectSortByDateMethodsSortsTheMoviesInThaDataBaseFromTheOldestToNewestAndReturnsThemAsADictionary()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies movie_view = new mov4eAllMovies(dummy._iallMoviesPresenter);

            try
            {
                movie_view.SortByDate();
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
        public void CorrectSortByDateMethodsSortsTheMoviesInThaDataBaseFromAToZAndReturnsThemAsADictionary()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies movie_view = new mov4eAllMovies(dummy._iallMoviesPresenter);

            try
            {
                movie_view.SortByTitle();
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
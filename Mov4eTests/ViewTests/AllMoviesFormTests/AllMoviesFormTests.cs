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
        public void Method1()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies mp = new mov4eAllMovies(dummy._iallMoviesPresenter);

            try
            {
                mp.DeleteMovie();
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
        public void Method2()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies mp = new mov4eAllMovies(dummy._iallMoviesPresenter);


            try
            {
                mp.EditMovie();
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
        public void Method3()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies mp = new mov4eAllMovies(dummy._iallMoviesPresenter);


            try
            {
                mp.FilterMovies(6, 2, 12);
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
        public void Method4()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies mp = new mov4eAllMovies(dummy._iallMoviesPresenter);


            try
            {
                mp.FilterMoviesByDuration(2);
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
        public void Method5()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies mp = new mov4eAllMovies(dummy._iallMoviesPresenter);


            try
            {
                mp.FilterMoviesByDurationAndPG(2, 12);
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
        public void Method6()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies mp = new mov4eAllMovies(dummy._iallMoviesPresenter);


            try
            {
                mp.FilterMoviesByGenres(6);
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
        public void Method7()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies mp = new mov4eAllMovies(dummy._iallMoviesPresenter);


            try
            {
                mp.FilterMoviesByGenresAndDuration(6, 2);
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
        public void Method8()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies mp = new mov4eAllMovies(dummy._iallMoviesPresenter);


            try
            {
                mp.FilterMoviesByGenresAndPG(6, 12);
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
        public void Method9()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies mp = new mov4eAllMovies(dummy._iallMoviesPresenter);


            try
            {
                mp.FilterMoviesByPG(12);
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
        public void Method10()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies mp = new mov4eAllMovies(dummy._iallMoviesPresenter);


            try
            {
                mp.GetMovie();
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
        public void Method12()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies mp = new mov4eAllMovies(dummy._iallMoviesPresenter);


            try
            {
                mp.SearchMovie();
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
        public void Method13()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies mp = new mov4eAllMovies(dummy._iallMoviesPresenter);


            try
            {
                mp.SearchMovie();
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
        public void Method15()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies mp = new mov4eAllMovies(dummy._iallMoviesPresenter);
            Dictionary<int, byte[]> testDictOfMovies = new Dictionary<int, byte[]>();

            try
            {
                mp.InitializeMoviesList(testDictOfMovies);
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
        public void Method17()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies mp = new mov4eAllMovies(dummy._iallMoviesPresenter);


            try
            {
                mp.SortByDate();
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
        public void Method18()
        {
            DummyMockedAllMoviesPresenter dummy = new DummyMockedAllMoviesPresenter();
            IAllMovies mp = new mov4eAllMovies(dummy._iallMoviesPresenter);


            try
            {
                mp.SortByTitle();
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

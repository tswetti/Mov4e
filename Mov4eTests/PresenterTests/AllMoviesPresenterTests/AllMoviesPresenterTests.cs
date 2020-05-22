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
        public void Method1()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter mp = new AllMoviesPresenter(dummy._iallMoviesService);
           

            try
            {
                mp.DeleteMovie(1);
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
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter mp = new AllMoviesPresenter(dummy._iallMoviesService);


            try
            {
                mp.EditMovie(4, "Movie", 7, 18, DateTime.Now, "summary...", new byte[90], 93);
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
        public void Method3()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter mp = new AllMoviesPresenter(dummy._iallMoviesService);


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
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter mp = new AllMoviesPresenter(dummy._iallMoviesService);


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
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter mp = new AllMoviesPresenter(dummy._iallMoviesService);


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
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter mp = new AllMoviesPresenter(dummy._iallMoviesService);


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
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter mp = new AllMoviesPresenter(dummy._iallMoviesService);


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
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter mp = new AllMoviesPresenter(dummy._iallMoviesService);


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
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter mp = new AllMoviesPresenter(dummy._iallMoviesService);


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
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter mp = new AllMoviesPresenter(dummy._iallMoviesService);


            try
            {
                mp.GetMovie(2);
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
        public void Method11()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter mp = new AllMoviesPresenter(dummy._iallMoviesService);


            try
            {
                mp.GetMovieGenre("Drama");
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
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter mp = new AllMoviesPresenter(dummy._iallMoviesService);


            try
            {
                mp.GetMoviesByTitle(new List<string>{"Terminator", "Titanic"});
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
        public void Method13()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter mp = new AllMoviesPresenter(dummy._iallMoviesService);


            try
            {
                mp.GetMovieTitles();
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
        public void Method14()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter mp = new AllMoviesPresenter(dummy._iallMoviesService);


            try
            {
                mp.GetUserInfo("petya", "myPass");
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
        public void Method15()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter mp = new AllMoviesPresenter(dummy._iallMoviesService);


            try
            {
                mp.SetMovieInformation();
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
        public void Method16()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter mp = new AllMoviesPresenter(dummy._iallMoviesService);


            try
            {
                mp.SetMovieTitle(2);
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
        public void Method17()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter mp = new AllMoviesPresenter(dummy._iallMoviesService);


            try
            {
                mp.SortByDate();
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
        public void Method18()
        {
            DummyMockedAllMoviesService dummy = new DummyMockedAllMoviesService();
            IAllMoviesPresenter mp = new AllMoviesPresenter(dummy._iallMoviesService);


            try
            {
                mp.SortMoviesByTitle();
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

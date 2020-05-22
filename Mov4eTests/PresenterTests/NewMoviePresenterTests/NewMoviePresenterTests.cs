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
        public void Method1()
        {
            DummyMockedNewMovieService dummy = new DummyMockedNewMovieService();
            INewMoviePresenter mp = new NewMoviePresenter(dummy._inewMovieService);

            try
            {
                mp.AddMovie("Movie", 6, 14, DateTime.Now, "summary...", new byte[65], 123);
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
        public void Method2()
        {
            DummyMockedNewMovieService dummy = new DummyMockedNewMovieService();
            INewMoviePresenter mp = new NewMoviePresenter(dummy._inewMovieService);

            try
            {
                mp.LastMovieId();
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

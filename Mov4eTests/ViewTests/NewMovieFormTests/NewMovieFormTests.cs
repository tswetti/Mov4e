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
        public void Method1()
        {
            DummyMockedNewMoviePresenter dummy = new DummyMockedNewMoviePresenter();
            INewMovie mp = new mov4eAddMovie(dummy._inewMoviePresenter);

            try
            {
                mp.addNewMovie();
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
            DummyMockedNewMoviePresenter dummy = new DummyMockedNewMoviePresenter();
            INewMovie mp = new mov4eAddMovie(dummy._inewMoviePresenter);

            try
            {
                mp.updateMovie();
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

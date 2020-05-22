using Mov4e.Service.NewMovieService;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4eTests.ServiceTests.NewMovieServiceTests
{
    [TestFixture]
    public class TestsNewMovieService
    {
        [Test]
        public void CorrectCreateMovieSetsValuesToTheMoviesFields()
        {
            DummyMockedNewMovieRepository _dummyMockedNewMovieRepo = new DummyMockedNewMovieRepository();
            INewMovieService _inewMovieService = new NewMovieService(_dummyMockedNewMovieRepo._inewmRepo);

            try
            {
                _inewMovieService.CreateMovie("Movie", 14, 3, new DateTime(1990, 10, 20), "Description", new byte[75], 135);
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
        public void CorrectLastAddedMovieIdReturnsTheMoviesID()
        {
            DummyMockedNewMovieRepository _dummyMockedNewMovieRepo = new DummyMockedNewMovieRepository();
            INewMovieService _inewMovieService = new NewMovieService(_dummyMockedNewMovieRepo._inewmRepo);

            
            Assert.AreEqual(_inewMovieService.IdOfTheLastMovie(), 3);
            Assert.AreNotEqual(_inewMovieService.IdOfTheLastMovie(), null);
        }
    }
}

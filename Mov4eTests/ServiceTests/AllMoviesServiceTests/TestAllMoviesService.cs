using Mov4e.Exceptions;
using Mov4e.Logger;
using Mov4e.Model;
using Mov4e.Service.AllMoviesService;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4eTests.ServiceTests.AllMoviesServiceTests
{
    [TestFixture]
    class TestAllMoviesService
    {
        [Test]
        public void CorrectGetMovieReturnsATuple()
        {
            DummyMockedAllMoviesRepository _dummyMockedAllMoviesRepo = new DummyMockedAllMoviesRepository();
            IAllMoviesService _iallMoviesService = new AllMoviesService(_dummyMockedAllMoviesRepo._allMoviesRepo);
            Tuple<Movie, string> expectedMovie = new Tuple<Movie, string>(new Movie { id = 1, title = "Titanic", genre = 1, pg = 0, duration = 210, summary = "This is the description of the Titanic movie.", year = new DateTime(1997, 11, 1), picture = new byte[100] }, "Drama");
            Tuple<Movie, string> movie = _iallMoviesService.GetMovie(1);

            Assert.AreNotEqual(_iallMoviesService.GetMovie(1), null);
            Assert.AreEqual(expectedMovie.Item1.id, movie.Item1.id);
            Assert.AreEqual(expectedMovie.Item1.AVGRating, movie.Item1.AVGRating);
            Assert.AreEqual(expectedMovie.Item1.comments, movie.Item1.comments);
            Assert.AreEqual(expectedMovie.Item1.duration, movie.Item1.duration);
            Assert.AreEqual(expectedMovie.Item1.genre, movie.Item1.genre);
            Assert.AreEqual(expectedMovie.Item1.genre1, movie.Item1.genre1);
            Assert.AreEqual(expectedMovie.Item1.pg, movie.Item1.pg);
            Assert.AreEqual(expectedMovie.Item1.picture, movie.Item1.picture);
            Assert.AreEqual(expectedMovie.Item1.ratings, movie.Item1.ratings);
            Assert.AreEqual(expectedMovie.Item1.summary, movie.Item1.summary);
            Assert.AreEqual(expectedMovie.Item1.title, movie.Item1.title);
            Assert.AreEqual(expectedMovie.Item1.users, movie.Item1.users);
            Assert.AreEqual(expectedMovie.Item1.year, movie.Item1.year);
            Assert.AreEqual(expectedMovie.Item2, movie.Item2);
        }

        [Test]
        public void CorrectEditMovieEditsACertainMovie()
        {
            DummyMockedAllMoviesRepository _dummyMockedAllMoviesRepo = new DummyMockedAllMoviesRepository();
            IAllMoviesService _iallMoviesService = new AllMoviesService(_dummyMockedAllMoviesRepo._allMoviesRepo);

            try
            {
                _iallMoviesService.EditMovie(2, "The Hunger Games: Catching Fire", 7, 14, new DateTime(2013, 11, 22), "This is the description of The Hunger Games: Catching Fire movie.", new byte[110], 180);
                _iallMoviesService.EditMovie(-2, "The Hunger Games: Catching Fire", 7, 14, new DateTime(2013, 11, 22), "This is the description of The Hunger Games: Catching Fire movie.", new byte[110], 180);
                _iallMoviesService.EditMovie(2, "The Hunger Games: Catching Fire", 7, 14, new DateTime(2013, 11, 22), "This is the description of The Hunger Games: Catching Fire movie.", null, 180);
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
        public void CorrectDeleteMovie()
        {
            DummyMockedAllMoviesRepository _dummyMockedAllMoviesRepo = new DummyMockedAllMoviesRepository();
            IAllMoviesService _iallMoviesService = new AllMoviesService(_dummyMockedAllMoviesRepo._allMoviesRepo);

            try
            {
                _iallMoviesService.DeleteMovie(3);
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

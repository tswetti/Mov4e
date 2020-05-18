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
        public void CorrectGetMovieReturnsTheMovieAsATupleFromItsIdAndGenre()
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
        public void CorrectEditMovieEditsACertainMovieInTheDB()
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
        public void CorrectDeleteMovieDeletesAMovieFromDB()
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

        [Test]
        public void CorrectSortMovieByAToZSortsMoviesAlphabeticallyAndReturnsTheirIdsAndWrapperAsADictionary()
        {
            DummyMockedAllMoviesRepository _dummyMockedAllMoviesRepo = new DummyMockedAllMoviesRepository();
            IAllMoviesService _iallMoviesService = new AllMoviesService(_dummyMockedAllMoviesRepo._allMoviesRepo);
            Dictionary<int, byte[]> expected = new Dictionary<int, byte[]>();
            expected.Add(3, new byte[80]);
            expected.Add(2, new byte[120]);
            expected.Add(1, new byte[100]);

            try
            {
                Assert.AreNotEqual(_iallMoviesService.SortMoviesByTitle(), null);
                Assert.AreEqual(_iallMoviesService.SortMoviesByTitle(), expected);
            }
            catch (NoDataBaseTableRecordsException ex)
            {
                Logger.WriteToLogFile(ex.ToString());
                Assert.IsTrue(false);
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void CorrectSortMoviesByOldestMoviesSortsTheMoviesAndReturnsThemAsADictionary()
        {
            DummyMockedAllMoviesRepository _dummyMockedAllMoviesRepo = new DummyMockedAllMoviesRepository();
            IAllMoviesService _iallMoviesService = new AllMoviesService(_dummyMockedAllMoviesRepo._allMoviesRepo);
            Dictionary<int, byte[]> expected = new Dictionary<int, byte[]>();
            expected.Add(3, new byte[80]);
            expected.Add(2, new byte[120]);
            expected.Add(1, new byte[100]);

            Assert.AreNotEqual(_iallMoviesService.SortByDate(), null);
            Assert.AreEqual(_iallMoviesService.SortByDate(), expected);
        }

        [Test]
        public void CorrectFilterMoviesReturnsFilteredMoviesAsADictionaryOfItsIdsAndItsWrappers()
        {
            DummyMockedAllMoviesRepository _dummyMockedAllMoviesRepo = new DummyMockedAllMoviesRepository();
            IAllMoviesService _iallMoviesService = new AllMoviesService(_dummyMockedAllMoviesRepo._allMoviesRepo);
            Movie expectedMovie = new Movie { id = 2, title = "Terminator", genre = 6, pg = 12, duration = 120, summary = "This is the description of the Terminator movie.", year = new DateTime(1984, 10, 26), picture = new byte[120] };
            Dictionary<int, byte[]> expected = new Dictionary<int, byte[]>();
            expected.Add(expectedMovie.id, expectedMovie.picture);
            Dictionary<int, byte[]> actual = _iallMoviesService.FilterMovies(6, 2, 12);

            Assert.AreNotEqual(_iallMoviesService.FilterMovies(6, 2, 12), null);
            foreach (var item in actual)
            {
                Assert.AreEqual(item.Key, expectedMovie.id);
                Assert.AreEqual(item.Value, expectedMovie.picture);
            }
        }

        [Test]
        public void CorrectFilterMoviesByGenresAndDurationReturnsFilteredMoviesAsADictionaryOfItsIdsAndItsWrappers()
        {
            DummyMockedAllMoviesRepository _dummyMockedAllMoviesRepo = new DummyMockedAllMoviesRepository();
            IAllMoviesService _iallMoviesService = new AllMoviesService(_dummyMockedAllMoviesRepo._allMoviesRepo);
            Movie expectedMovie = new Movie { id = 2, title = "Terminator", genre = 6, pg = 12, duration = 120, summary = "This is the description of the Terminator movie.", year = new DateTime(1984, 10, 26), picture = new byte[120] };
            Dictionary<int, byte[]> expected = new Dictionary<int, byte[]>();
            expected.Add(expectedMovie.id, expectedMovie.picture);
            Dictionary<int, byte[]> actual = _iallMoviesService.FilterMoviesByGenresAndDuration(6, 2);

            Assert.AreNotEqual(_iallMoviesService.FilterMoviesByGenresAndDuration(6, 2), null);
            foreach (var item in actual)
            {
                Assert.AreEqual(item.Key, expectedMovie.id);
                Assert.AreEqual(item.Value, expectedMovie.picture);
            }
        }

        [Test]
        public void CorrectFilterMoviesByGenresAndPGReturnsFilteredMoviesAsADictionaryOfItsIdsAndItsWrappers()
        {
            DummyMockedAllMoviesRepository _dummyMockedAllMoviesRepo = new DummyMockedAllMoviesRepository();
            IAllMoviesService _iallMoviesService = new AllMoviesService(_dummyMockedAllMoviesRepo._allMoviesRepo);
            Movie expectedMovie = new Movie { id = 2, title = "Terminator", genre = 6, pg = 12, duration = 120, summary = "This is the description of the Terminator movie.", year = new DateTime(1984, 10, 26), picture = new byte[120] };
            Dictionary<int, byte[]> expected = new Dictionary<int, byte[]>();
            expected.Add(expectedMovie.id, expectedMovie.picture);
            Dictionary<int, byte[]> actual = _iallMoviesService.FilterMoviesByGenresAndPG(6, 12);

            Assert.AreNotEqual(_iallMoviesService.FilterMoviesByGenresAndPG(6, 12), null);
            foreach (var item in actual)
            {
                Assert.AreEqual(item.Key, expectedMovie.id);
                Assert.AreEqual(item.Value, expectedMovie.picture);
            }
        }

        [Test]
        public void CorrectFilterMoviesByDurationAndPGReturnsFilteredMoviesAsADictionaryOfItsIdsAndItsWrappers()
        {
            DummyMockedAllMoviesRepository _dummyMockedAllMoviesRepo = new DummyMockedAllMoviesRepository();
            IAllMoviesService _iallMoviesService = new AllMoviesService(_dummyMockedAllMoviesRepo._allMoviesRepo);
            Movie expectedMovie = new Movie { id = 2, title = "Terminator", genre = 6, pg = 12, duration = 120, summary = "This is the description of the Terminator movie.", year = new DateTime(1984, 10, 26), picture = new byte[120] };
            Dictionary<int, byte[]> expected = new Dictionary<int, byte[]>();
            expected.Add(expectedMovie.id, expectedMovie.picture);
            Dictionary<int, byte[]> actual = _iallMoviesService.FilterMoviesByDurationAndPG(2, 12);

            Assert.AreNotEqual(_iallMoviesService.FilterMoviesByDurationAndPG(2, 12), null);
            foreach (var item in actual)
            {
                Assert.AreEqual(item.Key, expectedMovie.id);
                Assert.AreEqual(item.Value, expectedMovie.picture);
            }
        }

        [Test]
        public void CorrectFilterMoviesByGenresReturnsFilteredMoviesAsADictionaryOfItsIdsAndItsWrappers()
        {
            DummyMockedAllMoviesRepository _dummyMockedAllMoviesRepo = new DummyMockedAllMoviesRepository();
            IAllMoviesService _iallMoviesService = new AllMoviesService(_dummyMockedAllMoviesRepo._allMoviesRepo);
            Movie expectedMovie = new Movie { id = 2, title = "Terminator", genre = 6, pg = 12, duration = 120, summary = "This is the description of the Terminator movie.", year = new DateTime(1984, 10, 26), picture = new byte[120] };
            Dictionary<int, byte[]> expected = new Dictionary<int, byte[]>();
            expected.Add(expectedMovie.id, expectedMovie.picture);
            Dictionary<int, byte[]> actual = _iallMoviesService.FilterMoviesByGenres(6);

            Assert.AreNotEqual(_iallMoviesService.FilterMoviesByGenres(6), null);
            foreach (var item in actual)
            {
                Assert.AreEqual(item.Key, expectedMovie.id);
                Assert.AreEqual(item.Value, expectedMovie.picture);
            }
        }

        [Test]
        public void CorrectFilterMoviesByDurationReturnsFilteredMoviesAsADictionaryOfItsIdsAndItsWrappers()
        {
            DummyMockedAllMoviesRepository _dummyMockedAllMoviesRepo = new DummyMockedAllMoviesRepository();
            IAllMoviesService _iallMoviesService = new AllMoviesService(_dummyMockedAllMoviesRepo._allMoviesRepo);
            Movie expectedMovie = new Movie { id = 2, title = "Terminator", genre = 6, pg = 12, duration = 120, summary = "This is the description of the Terminator movie.", year = new DateTime(1984, 10, 26), picture = new byte[120] };
            Dictionary<int, byte[]> expected = new Dictionary<int, byte[]>();
            expected.Add(expectedMovie.id, expectedMovie.picture);
            Dictionary<int, byte[]> actual = _iallMoviesService.FilterMoviesByDuration(2);

            Assert.AreNotEqual(_iallMoviesService.FilterMoviesByDuration(2), null);
            foreach (var item in actual)
            {
                Assert.AreEqual(item.Key, expectedMovie.id);
                Assert.AreEqual(item.Value, expectedMovie.picture);
            }
        }

        [Test]
        public void CorrectFilterMoviesByPGReturnsFilteredMoviesAsADictionaryOfItsIdsAndItsWrappers()
        {
            DummyMockedAllMoviesRepository _dummyMockedAllMoviesRepo = new DummyMockedAllMoviesRepository();
            IAllMoviesService _iallMoviesService = new AllMoviesService(_dummyMockedAllMoviesRepo._allMoviesRepo);
            Movie expectedMovie = new Movie { id = 2, title = "Terminator", genre = 6, pg = 12, duration = 120, summary = "This is the description of the Terminator movie.", year = new DateTime(1984, 10, 26), picture = new byte[120] };
            Dictionary<int, byte[]> expected = new Dictionary<int, byte[]>();
            expected.Add(expectedMovie.id, expectedMovie.picture);
            Dictionary<int, byte[]> actual = _iallMoviesService.FilterMoviesByPG(12);

            Assert.AreNotEqual(_iallMoviesService.FilterMoviesByPG(12), null);
            foreach (var item in actual)
            {
                Assert.AreEqual(item.Key, expectedMovie.id);
                Assert.AreEqual(item.Value, expectedMovie.picture);
            }
        }

        [Test]
        public void CorrectGetMoviesByTitlesReturnsADictionaryOfMoviesIdsAndWrappers()
        {
            DummyMockedAllMoviesRepository _dummyMockedAllMoviesRepo = new DummyMockedAllMoviesRepository();
            IAllMoviesService _iallMoviesService = new AllMoviesService(_dummyMockedAllMoviesRepo._allMoviesRepo);
            Movie expectedMovie = new Movie { id = 1, title = "Titanic", genre = 1, pg = 0, duration = 210, summary = "This is the description of the Titanic movie.", year = new DateTime(1997, 11, 1), picture = new byte[100] };
            Dictionary<int, byte[]> expected = new Dictionary<int, byte[]>();
            expected.Add(expectedMovie.id, expectedMovie.picture);
            Dictionary<int, byte[]> actual = _iallMoviesService.GetMoviesByTitles(new List<string> { expectedMovie.title });

            Assert.AreNotEqual(_iallMoviesService.GetMoviesByTitles(new List<string> { expectedMovie.title }), null);
            foreach (var item in expected)
            {
                Assert.AreEqual(item.Key, 1);
                Assert.AreEqual(item.Value, new byte[100]);
            }
        }

        [Test]
        public void CorrectGetMoviesTitleReturnsTheTitleOfTheMovieByItsId()
        {
            DummyMockedAllMoviesRepository _dummyMockedAllMoviesRepo = new DummyMockedAllMoviesRepository();
            IAllMoviesService _iallMoviesService = new AllMoviesService(_dummyMockedAllMoviesRepo._allMoviesRepo);
            Movie expectedMovie = new Movie { id = 1, title = "Titanic", genre = 1, pg = 0, duration = 210, summary = "This is the description of the Titanic movie.", year = new DateTime(1997, 11, 1), picture = new byte[100] };

            Assert.AreNotEqual(_iallMoviesService.SetMovieTitle(1), null);
            Assert.AreEqual(_iallMoviesService.SetMovieTitle(1), "Titanic");
        }

        [Test]
        public void CorrectGetMoviesReturnsADictionaryOfItsIdsAndWrappers()
        {
            DummyMockedAllMoviesRepository _dummyMockedAllMoviesRepo = new DummyMockedAllMoviesRepository();
            IAllMoviesService _iallMoviesService = new AllMoviesService(_dummyMockedAllMoviesRepo._allMoviesRepo);
            Movie expectedMovie1 = new Movie { id = 1, title = "Titanic", genre = 1, pg = 0, duration = 210, summary = "This is the description of the Titanic movie.", year = new DateTime(1997, 11, 1), picture = new byte[100] };
            Movie expectedMovie2 = new Movie { id = 2, title = "Terminator", genre = 6, pg = 12, duration = 120, summary = "This is the description of the Terminator movie.", year = new DateTime(1984, 10, 26), picture = new byte[120] };
            Movie expectedMovie3 = new Movie { id = 3, title = "Star Wars 5", genre = 7, pg = 0, duration = 150, summary = "This is the description of the Star Wars 5 movie.", year = new DateTime(1984, 4, 23), picture = new byte[80] };
            Dictionary<int, byte[]> dict = new Dictionary<int, byte[]>();
            dict.Add(expectedMovie1.id, expectedMovie1.picture);
            dict.Add(expectedMovie2.id, expectedMovie2.picture);
            dict.Add(expectedMovie3.id, expectedMovie3.picture);

            Assert.AreNotEqual(_iallMoviesService.SetMoviesList(), null);
            foreach(var item in dict)
            {
                foreach(var el in _iallMoviesService.SetMoviesList())
                {
                    Assert.AreEqual(item.Key, el.Key);
                    Assert.AreEqual(item.Value, el.Value);
                }
            } 
        }

        [Test]
        public void CorrectGetMoviesTitlesReturnsAListOfMoviesTitlesFromDB()
        {
            DummyMockedAllMoviesRepository _dummyMockedAllMoviesRepo = new DummyMockedAllMoviesRepository();
            IAllMoviesService _iallMoviesService = new AllMoviesService(_dummyMockedAllMoviesRepo._allMoviesRepo);
            List<string> expected = new List<string> {"Titanic", "Terminator", "Star Wars 5"};

            Assert.AreNotEqual(_iallMoviesService.GetMovieTitles(), null);
            for (int i=0; i<expected.Count; i++)
            {
                Assert.AreEqual(_iallMoviesService.GetMovieTitles()[i], expected[i]);
            }
        }

        [Test]
        public void CorrectGetUserInfoReturnsATupleFromUsersIdAndPosition()
        {
            DummyMockedAllMoviesRepository _dummyMockedAllMoviesRepo = new DummyMockedAllMoviesRepository();
            IAllMoviesService _iallMoviesService = new AllMoviesService(_dummyMockedAllMoviesRepo._allMoviesRepo);

            Assert.AreNotEqual(_iallMoviesService.GetUserInfo("petya", "myPass"), null);
            Assert.AreEqual(_iallMoviesService.GetUserInfo("petya", "myPass"), new Tuple<int, string>(1, "admin"));
        }

        [Test]
        public void CorrectGetMovieGenreReturnsTheMovieGenreAsIntNumber()
        {
            DummyMockedAllMoviesRepository _dummyMockedAllMoviesRepo = new DummyMockedAllMoviesRepository();
            IAllMoviesService _iallMoviesService = new AllMoviesService(_dummyMockedAllMoviesRepo._allMoviesRepo);

            Assert.AreNotEqual(_iallMoviesService.GetMovieGenre("Drama"), null);
            Assert.AreEqual(_iallMoviesService.GetMovieGenre("Drama"), 1);
        }
    }
}

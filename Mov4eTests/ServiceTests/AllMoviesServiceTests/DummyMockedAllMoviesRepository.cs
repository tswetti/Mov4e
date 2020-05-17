using Autofac.Extras.Moq;
using Moq;
using Mov4e.Exceptions;
using Mov4e.Logger;
using Mov4e.Model;
using Mov4e.Repository.AllMoviesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4eTests.ServiceTests.AllMoviesServiceTests
{
    class DummyMockedAllMoviesRepository
    {
        private List<Movie> movies = new List<Movie>
        {
            new Movie{id=1,title="Titanic",genre=1,pg=0,duration=210,summary="This is the description of the Titanic movie.",year=new DateTime(1997,11,1),picture=new byte[100]},
            new Movie{id=2,title="Terminator",genre=6,pg=12,duration=120,summary="This is the description of the Terminator movie.",year=new DateTime(1984,10,26),picture=new byte[120]},
            new Movie{id=3,title="Star Wars 5",genre=7,pg=0,duration=150,summary="This is the description of the Star Wars 5 movie.",year=new DateTime(1984,4,23),picture=new byte[80]}
        };

        private Movie movie = new Movie{id=2, title = "The Hunger Games: Catching Fire", genre = 7, pg = 14, duration = 180, summary = "This is the description of The Hunger Games: Catching Fire movie.", year = new DateTime(2013, 11, 22), picture = new byte[110] };

        public IAllMoviesRepository _allMoviesRepo;

        private Dictionary<int, byte[]> getSortedByAToZMovies()
        {
            Dictionary<int, byte[]> sortedMovies = new Dictionary<int, byte[]>();
            var sortQuery = from m in movies orderby m.title select m;
            foreach(var item in sortQuery)
            {
                sortedMovies.Add(item.id, item.picture);
            }
            return sortedMovies;
        }

        private Dictionary<int, byte[]> getSortedByOldestMovies()
        {
            Dictionary<int, byte[]> sortedMovies = new Dictionary<int, byte[]>();
            var sortQuery = from m in movies orderby m.year select m;
            foreach (var item in sortQuery)
            {
                sortedMovies.Add(item.id, item.picture);
            }
            return sortedMovies;
        }

        public DummyMockedAllMoviesRepository()
        {
            using (var mock = AutoMock.GetStrict())
            {
                mock.Mock<IAllMoviesRepository>().Setup(iall_m_repo => iall_m_repo.GetMovie(It.IsAny<int>()))
                    .Returns((int id) => new Tuple<Movie, string>(movies.Where(m => m.id == id).Single(), "Drama"));

                mock.Mock<IAllMoviesRepository>().Setup(iall_m_repo => iall_m_repo.EditMovie(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Nullable<DateTime>>(),
                     It.IsAny<string>(), It.IsAny<byte[]>(), It.IsAny<int>())).Callback((int id, string title, int genre, int pg, Nullable<DateTime> date, string summary, byte[] picture, int dur)
                     => {
                         try
                         {
                             movies[1].title = title; movies[1].genre = genre; movies[1].pg = pg; movies[1].year = date; movies[1].summary = summary;
                             movies[1].picture = picture; movies[1].duration = dur;
                         }
                         catch (ImpossibleDataBaseRecordUpdateException ex)
                         {
                             Logger.WriteToLogFile(ex.ToString());
                         }
                         catch (NotFoundSuchItemException ex)
                         {
                             Logger.WriteToLogFile(ex.ToString());
                         }
                         catch (Exception ex)
                         {
                             Logger.WriteToLogFile(ex.ToString());
                         }
                     });

                mock.Mock<IAllMoviesRepository>().Setup(_allMoviesRepo => _allMoviesRepo.DeleteMovie(It.IsAny<int>())).Callback((int id) =>
                {
                    try
                    {
                        movies.Remove(movies.Where(m => m.id == id).Single());
                    }
                    catch (NotFoundSuchItemException ex)
                    {
                        Logger.WriteToLogFile(ex.ToString());
                    }
                });

                mock.Mock<IAllMoviesRepository>().Setup(_allMoviesRepo=>_allMoviesRepo.SortMoviesByTitle()).Returns(getSortedByAToZMovies());
                
                mock.Mock<IAllMoviesRepository>().Setup(_allMoviesRepo => _allMoviesRepo.SortByDate()).Returns(getSortedByOldestMovies());

                _allMoviesRepo = mock.Create<IAllMoviesRepository>();
            }
        }
    }
}
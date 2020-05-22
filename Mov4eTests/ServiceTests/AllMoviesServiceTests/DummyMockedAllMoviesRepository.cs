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
    public class DummyMockedAllMoviesRepository
    {
        private List<Movie> movies = new List<Movie>
        {
            new Movie{id=1,title="Titanic",genre=1,pg=0,duration=210,summary="This is the description of the Titanic movie.",year=new DateTime(1997,11,1),picture=new byte[100]},
            new Movie{id=2,title="Terminator",genre=6,pg=12,duration=120,summary="This is the description of the Terminator movie.",year=new DateTime(1984,10,26),picture=new byte[120]},
            new Movie{id=3,title="Star Wars 5",genre=7,pg=0,duration=150,summary="This is the description of the Star Wars 5 movie.",year=new DateTime(1984,4,23),picture=new byte[80]}
        };

        private List<Genre> genres = new List<Genre>
        {
            new Genre{id=1, name="Drama"}
        };

        private List<User> users = new List<User>
        {
            new User{id=1, userName="petya", password="myPass"}
        };

        private List<UserInfo> usersInfo = new List<UserInfo>
        {
            new UserInfo{id=1, position="admin"}
        };

        private Movie movie = new Movie{id=2, title = "The Hunger Games: Catching Fire", genre = 7, pg = 14, duration = 180, summary = "This is the description of The Hunger Games: Catching Fire movie.", year = new DateTime(2013, 11, 22), picture = new byte[110] };

        public IAllMoviesRepository _allMoviesRepo;

        private Dictionary<int, byte[]> GetSortedByAToZMovies()
        {
            Dictionary<int, byte[]> sortedMovies = new Dictionary<int, byte[]>();
            var sortQuery = from m in movies orderby m.title select m;
            foreach(var item in sortQuery)
            {
                sortedMovies.Add(item.id, item.picture);
            }
            return sortedMovies;
        }

        private Dictionary<int, byte[]> GetSortedByOldestMovies()
        {
            Dictionary<int, byte[]> sortedMovies = new Dictionary<int, byte[]>();
            var sortQuery = from m in movies orderby m.year select m;
            foreach (var item in sortQuery)
            {
                sortedMovies.Add(item.id, item.picture);
            }
            return sortedMovies;
        }

        private Dictionary<int, byte[]> GetFilteredByGenreDurationAndPGMovies(int g, int d, int pg)
        {
            Dictionary<int, byte[]> filteredMovies = new Dictionary<int, byte[]>();
            if (d == 1)
            {
                var filterQuery = from m in movies where m.genre == g && m.duration >= 0 && m.duration < 60 && m.pg == pg select new { m.id, m.picture };
                foreach (var item in filterQuery)
                {
                    filteredMovies.Add(item.id, item.picture);
                }
            }
            else if (d==2)
            {
                var filterQuery = from m in movies where m.genre == g && m.duration >= 60 && m.duration < 120 && m.pg == pg select new { m.id, m.picture };
                foreach (var item in filterQuery)
                {
                    filteredMovies.Add(item.id, item.picture);
                }
            }
            else if (d==3)
            {
                var filterQuery = from m in movies where m.genre == g && m.duration >= 120 && m.duration < 180 && m.pg == pg select new { m.id, m.picture };
                foreach (var item in filterQuery)
                {
                    filteredMovies.Add(item.id, item.picture);
                }
            }
            else if(d==4)
            {
                var filterQuery = from m in movies where m.genre == g && m.duration >= 180 && m.pg == pg select new { m.id, m.picture };
                foreach (var item in filterQuery)
                {
                    filteredMovies.Add(item.id, item.picture);
                }
            }
            else
            {

            }
            return filteredMovies;
        }

        private Dictionary<int, byte[]> GetFilteredByGenreAndDurationMovies(int g, int d)
        {
            Dictionary<int, byte[]> filteredMovies = new Dictionary<int, byte[]>();

            if (d == 1)
            {
                var filterQuery = from m in movies where m.genre == g && m.duration >= 0 && m.duration < 60 && m.genre == g select new { m.id, m.picture };
                foreach (var item in filterQuery)
                {
                    filteredMovies.Add(item.id, item.picture);
                }
            }
            else if (d == 2)
            {
                var filterQuery = from m in movies where m.genre == g && m.duration >= 60 && m.duration < 120 && m.genre == g select new { m.id, m.picture };
                foreach (var item in filterQuery)
                {
                    filteredMovies.Add(item.id, item.picture);
                }
            }
            else if (d == 3)
            {
                var filterQuery = from m in movies where m.genre == g && m.duration >= 120 && m.duration < 180 && m.genre == g select new { m.id, m.picture };
                foreach (var item in filterQuery)
                {
                    filteredMovies.Add(item.id, item.picture);
                }
            }
            else if (d == 4)
            {
                var filterQuery = from m in movies where m.genre == g && m.duration >= 180 && m.genre == g select new { m.id, m.picture };
                foreach (var item in filterQuery)
                {
                    filteredMovies.Add(item.id, item.picture);
                }
            }
            else
            {

            }

            return filteredMovies;
        }

        private Dictionary<int, byte[]> GetFilteredByGenreAndPGMovies(int g, int pg)
        {
            Dictionary<int, byte[]> filteredMovies = new Dictionary<int, byte[]>();
            var filterQuery = from m in movies where m.genre == g && m.pg == pg select new { m.id, m.picture };
            foreach (var item in filterQuery)
            {
                filteredMovies.Add(item.id, item.picture);
            }
            return filteredMovies;
        }

        private Dictionary<int, byte[]> GetFilteredByDurationAndPGMovies(int d, int pg)
        {
            Dictionary<int, byte[]> filteredMovies = new Dictionary<int, byte[]>();

            if (d == 1)
            {
                var filterQuery = from m in movies where m.duration >= 0 && m.duration < 60 && m.pg == pg select new { m.id, m.picture };
                foreach (var item in filterQuery)
                {
                    filteredMovies.Add(item.id, item.picture);
                }
            }
            else if (d == 2)
            {
                var filterQuery = from m in movies where m.duration >= 60 && m.duration < 120 && m.pg == pg select new { m.id, m.picture };
                foreach (var item in filterQuery)
                {
                    filteredMovies.Add(item.id, item.picture);
                }
            }
            else if (d == 3)
            {
                var filterQuery = from m in movies where m.duration >= 120 && m.duration < 180 && m.pg == pg select new { m.id, m.picture };
                foreach (var item in filterQuery)
                {
                    filteredMovies.Add(item.id, item.picture);
                }
            }
            else if (d == 4)
            {
                var filterQuery = from m in movies where m.duration >= 180 && m.pg == pg select new { m.id, m.picture };
                foreach (var item in filterQuery)
                {
                    filteredMovies.Add(item.id, item.picture);
                }
            }
            else
            {

            }

            return filteredMovies;
        }

        private Dictionary<int, byte[]> GetFilteredByGenreMovies(int g)
        {
            Dictionary<int, byte[]> filteredMovies = new Dictionary<int, byte[]>();
            var filterQuery = from m in movies where m.genre == g select new { m.id, m.picture };
            foreach (var item in filterQuery)
            {
                filteredMovies.Add(item.id, item.picture);
            }
            return filteredMovies;
        }

        private Dictionary<int, byte[]> GetFilteredByDurationMovies(int d)
        {
            Dictionary<int, byte[]> filteredMovies = new Dictionary<int, byte[]>();

            if (d == 1)
            {
                var filterQuery = from m in movies where m.duration >= 0 && m.duration < 60 select new { m.id, m.picture };
                foreach (var item in filterQuery)
                {
                    filteredMovies.Add(item.id, item.picture);
                }
            }
            else if (d == 2)
            {
                var filterQuery = from m in movies where m.duration >= 60 && m.duration < 120 select new { m.id, m.picture };
                foreach (var item in filterQuery)
                {
                    filteredMovies.Add(item.id, item.picture);
                }
            }
            else if (d == 3)
            {
                var filterQuery = from m in movies where m.duration >= 120 && m.duration < 180 select new { m.id, m.picture };
                foreach (var item in filterQuery)
                {
                    filteredMovies.Add(item.id, item.picture);
                }
            }
            else if (d == 4)
            {
                var filterQuery = from m in movies where m.duration >= 180 select new { m.id, m.picture };
                foreach (var item in filterQuery)
                {
                    filteredMovies.Add(item.id, item.picture);
                }
            }
            else
            {

            }

            return filteredMovies;
        }

        private Dictionary<int, byte[]> GetFilteredByPGMovies(int pg)
        {
            Dictionary<int, byte[]> filteredMovies = new Dictionary<int, byte[]>();
            var filterQuery = from m in movies where m.pg == pg select new { m.id, m.picture };
            foreach (var item in filterQuery)
            {
                filteredMovies.Add(item.id, item.picture);
            }
            return filteredMovies;
        }

        private Dictionary<int, byte[]> GetMoviesByTitles(List<string> titles)
        {
            Dictionary<int, byte[]> moviesDict = new Dictionary<int, byte[]>();
            for (int i = 0; i < titles.Count; i++)
            {
                var filterQuery = from m in movies where m.title == titles[i] select new { m.id, m.picture };
                foreach (var item in filterQuery)
                {
                    moviesDict.Add(item.id, item.picture);
                }
            }

            return moviesDict;
        }

        private Dictionary<int, byte[]> GetAllMovies()
        {
            Dictionary<int, byte[]> allMovies = new Dictionary<int, byte[]>();
            var filterQuery = from m in movies select new { m.id, m.picture };
            foreach (var item in filterQuery)
            {
                allMovies.Add(item.id, item.picture);
            }
            return allMovies;
        }

        private List<string> GetMoviesTitles()
        {
            List<string> allMovies = new List<string>();
            var filterQuery = from m in movies select m.title;
            foreach (var item in filterQuery)
            {
                allMovies.Add(item);
            }
            return allMovies;
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

                mock.Mock<IAllMoviesRepository>().Setup(_allMoviesRepo => _allMoviesRepo.SortMoviesByTitle()).Returns(GetSortedByAToZMovies());
                
                mock.Mock<IAllMoviesRepository>().Setup(_allMoviesRepo => _allMoviesRepo.SortByDate()).Returns(GetSortedByOldestMovies());

                mock.Mock<IAllMoviesRepository>().Setup(_allMoviesRepo => _allMoviesRepo.FilterMovies(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                    .Returns((int g, int d, int pg) => GetFilteredByGenreDurationAndPGMovies(g, d, pg));

                mock.Mock<IAllMoviesRepository>().Setup(_allMoviesRepo => _allMoviesRepo.FilterMoviesByGenresAndDuration(It.IsAny<int>(), It.IsAny<int>()))
                    .Returns((int g, int d) => GetFilteredByGenreAndDurationMovies(g, d));

                mock.Mock<IAllMoviesRepository>().Setup(_allMoviesRepo => _allMoviesRepo.FilterMoviesByGenresAndPG(It.IsAny<int>(), It.IsAny<int>()))
                    .Returns((int g, int pg) => GetFilteredByGenreAndPGMovies(g, pg));

                mock.Mock<IAllMoviesRepository>().Setup(_allMoviesRepo => _allMoviesRepo.FilterMoviesByDurationAndPG(It.IsAny<int>(), It.IsAny<int>()))
                   .Returns((int d, int pg) => GetFilteredByDurationAndPGMovies(d, pg));
                
                mock.Mock<IAllMoviesRepository>().Setup(_allMoviesRepo => _allMoviesRepo.FilterMoviesByGenres(It.IsAny<int>()))
                   .Returns((int g) => GetFilteredByGenreMovies(g));

                mock.Mock<IAllMoviesRepository>().Setup(_allMoviesRepo => _allMoviesRepo.FilterMoviesByDuration(It.IsAny<int>()))
                    .Returns((int d) => GetFilteredByGenreMovies(d));

                mock.Mock<IAllMoviesRepository>().Setup(_allMoviesRepo => _allMoviesRepo.FilterMoviesByPG(It.IsAny<int>()))
                   .Returns((int pg) => GetFilteredByGenreMovies(pg));
                
                mock.Mock<IAllMoviesRepository>().Setup(_allMoviesRepo => _allMoviesRepo.GetMoviesByTitles(It.IsAny<List<string>>()))
                    .Returns((List<string> titles) => GetMoviesByTitles(titles));

                mock.Mock<IAllMoviesRepository>().Setup(_allMoviesRepo => _allMoviesRepo.GetMovieTitle(It.IsAny<int>()))
                    .Returns((int id) => movies.Where(m => m.id == id).Single().title);

                mock.Mock<IAllMoviesRepository>().Setup(_allMoviesRepo => _allMoviesRepo.GetMovies())
                    .Returns(GetAllMovies());

                mock.Mock<IAllMoviesRepository>().Setup(_allMoviesRepo => _allMoviesRepo.GetMoviesTitles())
                    .Returns(GetMoviesTitles());

                mock.Mock<IAllMoviesRepository>().Setup(_allMoviesRepo => _allMoviesRepo.GetUserInfo(It.IsAny<string>(), It.IsAny<string>()))
                    .Returns((string unm, string pass) => new Tuple<int, string>(users.Where(u => u.userName == unm && u.password == pass).Single().id, 
                    usersInfo.Where(u => u.id == users.Where(us => us.userName == unm && us.password == pass).Single().id).Single().position));

                mock.Mock<IAllMoviesRepository>().Setup(_allMoviesRepo => _allMoviesRepo.GetMovieGenre(It.IsAny<string>()))
                    .Returns((string gen) => movies.Where(m => m.genre == genres.Where(g => g.name == gen).Single().id).Single().genre);

                _allMoviesRepo = mock.Create<IAllMoviesRepository>();
            }
        }
    }
}
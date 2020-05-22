using Autofac.Extras.Moq;
using Moq;
using Mov4e.Model;
using Mov4e.Repository.NewMovieRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4eTests.ServiceTests.NewMovieServiceTests
{
    public class DummyMockedNewMovieRepository
    {
        private List<Movie> movies = new List<Movie>
        {
            new Movie { id = 1, title = "Titanic", genre = 1, pg = 0, duration = 210, summary = "This is the description of the Titanic movie.", year = new DateTime(1997, 11, 1), picture = new byte[100] },
            new Movie { id = 2, title = "Terminator", genre = 6, pg = 12, duration = 120, summary = "This is the description of the Terminator movie.", year = new DateTime(1984, 10, 26), picture = new byte[120] },
            new Movie { id = 3, title = "Star Wars 5", genre = 7, pg = 0, duration = 150, summary = "This is the description of the Star Wars 5 movie.", year = new DateTime(1984, 4, 23), picture = new byte[80] }
        };

        private Movie mov = new Movie();

        public INewMovieRepository _inewmRepo; 

        public DummyMockedNewMovieRepository()
        {
            using (var mock = AutoMock.GetStrict())
            {
                mock.Mock<INewMovieRepository>().Setup(_inewmRepo => _inewmRepo.CreateMovie(It.IsAny<string>(), It.IsAny<Nullable<int>>(), It.IsAny<int>(),
                    It.IsAny<Nullable<DateTime>>(), It.IsAny<string>(), It.IsAny<byte[]>(), It.IsAny<int>()))
                    .Callback((string tit, Nullable<int> pg, int gen, Nullable<DateTime> date, string sum, byte[] pict, int dur) => 
                    {
                         mov = new Movie { id = 10, title = tit, pg = pg, genre = gen, year = date, summary = sum, picture = pict, duration = dur };
                        movies.Add(mov);
                    });

                mock.Mock<INewMovieRepository>().Setup(_inewmRepo => _inewmRepo.SaveMovie()).Callback(() => 
                {
                    movies.Add(mov);
                });

                mock.Mock<INewMovieRepository>().Setup(_inewmRepo => _inewmRepo.LastMovieId()).Returns(movies.Last().id);

                _inewmRepo = mock.Create<INewMovieRepository>();
            }
        } 
    }
}

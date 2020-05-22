using Autofac.Extras.Moq;
using Moq;
using Mov4e.Model;
using Mov4e.Service.AllMoviesService;
using Mov4eTests.ServiceTests.AllMoviesServiceTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4eTests.PresenterTests.AllMoviesPresenterTests
{
    public class DummyMockedAllMoviesService
    {
        public IAllMoviesService _iallMoviesService;
        private DummyMockedAllMoviesRepository repo = new DummyMockedAllMoviesRepository();
       
        public DummyMockedAllMoviesService()
        {
            using (var mock = AutoMock.GetStrict())
            {
                mock.Mock<IAllMoviesService>().Setup(_iallmService => _iallmService.DeleteMovie(It.IsAny<int>()))
                    .Callback((int m_id) => {
                        repo._allMoviesRepo.DeleteMovie(m_id);
                    });

                mock.Mock<IAllMoviesService>().Setup(_iallMoviesService => _iallMoviesService.EditMovie(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>(),
                    It.IsAny<int>(), It.IsAny<Nullable<DateTime>>(), It.IsAny<string>(), It.IsAny<byte[]>(), It.IsAny<int>()))
                    .Callback((int id, string title, int genre, int pg, Nullable<DateTime> date, string summary, byte[] picture, int duration) => 
                    {
                        repo._allMoviesRepo.EditMovie(id, title, genre, pg, date, summary, picture, duration);
                    });

                mock.Mock<IAllMoviesService>().Setup(_iallMoviesService => _iallMoviesService.FilterMovies(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                    .Callback((int g, int d, int pg) =>
                    {
                        repo._allMoviesRepo.FilterMovies(g, d, pg);
                    });

                mock.Mock<IAllMoviesService>().Setup(_iallMoviesService => _iallMoviesService.FilterMoviesByDuration(It.IsAny<int>()))
                    .Callback((int d) =>
                    {
                        repo._allMoviesRepo.FilterMoviesByDuration(d);
                    });

                mock.Mock<IAllMoviesService>().Setup(_iallMoviesService => _iallMoviesService.FilterMoviesByGenres(It.IsAny<int>()))
                    .Callback((int g) =>
                    {
                        repo._allMoviesRepo.FilterMoviesByGenres(g);
                    });

                mock.Mock<IAllMoviesService>().Setup(_iallMoviesService => _iallMoviesService.FilterMoviesByPG(It.IsAny<int>()))
                    .Callback((int pg) =>
                    {
                        repo._allMoviesRepo.FilterMoviesByPG(pg);
                    });

                mock.Mock<IAllMoviesService>().Setup(_iallMoviesService => _iallMoviesService.FilterMoviesByDurationAndPG(It.IsAny<int>(), It.IsAny<int>()))
                    .Callback((int d, int pg) =>
                    {
                        repo._allMoviesRepo.FilterMoviesByDurationAndPG(d, pg);
                    });

                mock.Mock<IAllMoviesService>().Setup(_iallMoviesService => _iallMoviesService.FilterMoviesByGenresAndDuration(It.IsAny<int>(), It.IsAny<int>()))
                    .Callback((int g, int d) =>
                    {
                        repo._allMoviesRepo.FilterMoviesByGenresAndDuration(g, d);
                    });

                mock.Mock<IAllMoviesService>().Setup(_iallMoviesService => _iallMoviesService.FilterMoviesByGenresAndPG(It.IsAny<int>(), It.IsAny<int>()))
                    .Callback((int g, int pg) =>
                    {
                        repo._allMoviesRepo.FilterMoviesByGenresAndPG(g, pg);
                    });

                mock.Mock<IAllMoviesService>().Setup(_iallMoviesService => _iallMoviesService.GetMovie(It.IsAny<int>()))
                    .Returns((int id) => repo._allMoviesRepo.GetMovie(id));

                mock.Mock<IAllMoviesService>().Setup(_iallMoviesService => _iallMoviesService.GetMovieGenre(It.IsAny<string>()))
                    .Returns((string gen) => repo._allMoviesRepo.GetMovieGenre(gen));

                mock.Mock<IAllMoviesService>().Setup(_iallMoviesService => _iallMoviesService.GetMoviesByTitles(It.IsAny<List<string>>()))
                    .Returns((List<string> titles) => repo._allMoviesRepo.GetMoviesByTitles(titles));

                mock.Mock<IAllMoviesService>().Setup(_iallMoviesService => _iallMoviesService.GetUserInfo(It.IsAny<string>(), It.IsAny<string>()))
                    .Returns((string unm, string pass) => repo._allMoviesRepo.GetUserInfo(unm, pass));

                mock.Mock<IAllMoviesService>().Setup(_iallMoviesService => _iallMoviesService.SetMoviesList())
                    .Returns(() => repo._allMoviesRepo.GetMovies());

                mock.Mock<IAllMoviesService>().Setup(_iallMoviesService => _iallMoviesService.SetMovieTitle(It.IsAny<int>()))
                    .Returns((int id) => repo._allMoviesRepo.GetMovieTitle(id));

                mock.Mock<IAllMoviesService>().Setup(_iallMoviesService => _iallMoviesService.SortByDate())
                    .Returns(() => repo._allMoviesRepo.SortByDate());

                mock.Mock<IAllMoviesService>().Setup(_iallMoviesService => _iallMoviesService.SortMoviesByTitle())
                    .Returns(() => repo._allMoviesRepo.SortMoviesByTitle());

                _iallMoviesService = mock.Create<IAllMoviesService>();
            }
        }
    }
}

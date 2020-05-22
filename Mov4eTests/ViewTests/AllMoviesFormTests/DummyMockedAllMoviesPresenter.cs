using Autofac.Extras.Moq;
using Moq;
using Mov4e.Presenter.AllMoviesPresenter;
using Mov4eTests.PresenterTests.AllMoviesPresenterTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4eTests.ViewTests.AllMoviesFormTests
{
    public class DummyMockedAllMoviesPresenter
    {
        public IAllMoviesPresenter _iallMoviesPresenter;
        private DummyMockedAllMoviesService service = new DummyMockedAllMoviesService();

        public DummyMockedAllMoviesPresenter()
        {
            using (var mock = AutoMock.GetStrict())
            {
                mock.Mock<IAllMoviesPresenter>().Setup(_iallmPresenter => _iallmPresenter.DeleteMovie(It.IsAny<int>()))
                    .Callback((int m_id) => service._iallMoviesService.DeleteMovie(m_id));

                mock.Mock<IAllMoviesPresenter>().Setup(_iallmPresenter => _iallmPresenter.EditMovie(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>(),
                    It.IsAny<int>(), It.IsAny<Nullable<DateTime>>(), It.IsAny<string>(), It.IsAny<byte[]>(), It.IsAny<int>()))
                    .Callback((int id, string title, int genre, int pg, Nullable<DateTime> date, string summary, byte[] picture, int duration) =>
                     {
                         service._iallMoviesService.EditMovie(id, title, genre, pg, date, summary, picture, duration);
                     });

                mock.Mock<IAllMoviesPresenter>().Setup(_iallmPresenter => _iallmPresenter.FilterMovies(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                    .Callback((int g, int d, int pg) =>
                    {
                        service._iallMoviesService.FilterMovies(g, d, pg);
                    });

                mock.Mock<IAllMoviesPresenter>().Setup(_iallmPresenter => _iallmPresenter.FilterMoviesByDuration(It.IsAny<int>()))
                   .Callback((int d) =>
                   {
                       service._iallMoviesService.FilterMoviesByDuration(d);
                   });

                mock.Mock<IAllMoviesPresenter>().Setup(_iallmPresenter => _iallmPresenter.FilterMoviesByGenres(It.IsAny<int>()))
                    .Callback((int g) =>
                    {
                        service._iallMoviesService.FilterMoviesByGenres(g);
                    });

                mock.Mock<IAllMoviesPresenter>().Setup(_iallmPresenter => _iallmPresenter.FilterMoviesByPG(It.IsAny<int>()))
                    .Callback((int pg) =>
                    {
                        service._iallMoviesService.FilterMoviesByPG(pg);
                    });

                mock.Mock<IAllMoviesPresenter>().Setup(_iallmPresenter => _iallmPresenter.FilterMoviesByDurationAndPG(It.IsAny<int>(), It.IsAny<int>()))
                    .Callback((int d, int pg) =>
                    {
                        service._iallMoviesService.FilterMoviesByDurationAndPG(d, pg);
                    });

                mock.Mock<IAllMoviesPresenter>().Setup(_iallmPresenter => _iallmPresenter.FilterMoviesByGenresAndDuration(It.IsAny<int>(), It.IsAny<int>()))
                    .Callback((int g, int d) =>
                    {
                        service._iallMoviesService.FilterMoviesByGenresAndDuration(g, d);
                    });

                mock.Mock<IAllMoviesPresenter>().Setup(_iallmPresenter => _iallmPresenter.FilterMoviesByGenresAndPG(It.IsAny<int>(), It.IsAny<int>()))
                    .Callback((int g, int pg) =>
                    {
                        service._iallMoviesService.FilterMoviesByGenresAndPG(g, pg);
                    });

                mock.Mock<IAllMoviesPresenter>().Setup(_iallmPresenter => _iallmPresenter.GetMovie(It.IsAny<int>()))
                    .Returns((int id) => service._iallMoviesService.GetMovie(id));

                mock.Mock<IAllMoviesPresenter>().Setup(_iallmPresenter => _iallmPresenter.GetMovieGenre(It.IsAny<string>()))
                    .Returns((string gen) => service._iallMoviesService.GetMovieGenre(gen));

                mock.Mock<IAllMoviesPresenter>().Setup(_iallmPresenter => _iallmPresenter.GetMoviesByTitle(It.IsAny<List<string>>()))
                    .Returns((List<string> titles) => service._iallMoviesService.GetMoviesByTitles(titles));

                mock.Mock<IAllMoviesPresenter>().Setup(_iallmPresenter => _iallmPresenter.GetUserInfo(It.IsAny<string>(), It.IsAny<string>()))
                    .Returns((string unm, string pass) => service._iallMoviesService.GetUserInfo(unm, pass));

                mock.Mock<IAllMoviesPresenter>().Setup(_iallmPresenter => _iallmPresenter.SetMovieInformation())
                    .Returns(() => service._iallMoviesService.SetMoviesList());

                mock.Mock<IAllMoviesPresenter>().Setup(_iallmPresenter => _iallmPresenter.SetMovieTitle(It.IsAny<int>()))
                    .Returns((int id) => service._iallMoviesService.SetMovieTitle(id));

                mock.Mock<IAllMoviesPresenter>().Setup(_iallmPresenter => _iallmPresenter.SortByDate())
                    .Returns(() => service._iallMoviesService.SortByDate());

                mock.Mock<IAllMoviesPresenter>().Setup(_iallmPresenter => _iallmPresenter.SortMoviesByTitle())
                    .Returns(() => service._iallMoviesService.SortMoviesByTitle());

                _iallMoviesPresenter = mock.Create<IAllMoviesPresenter>();
            }
        }
    }
}

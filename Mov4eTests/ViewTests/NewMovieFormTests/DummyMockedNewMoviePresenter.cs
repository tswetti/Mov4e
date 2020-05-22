using Autofac.Extras.Moq;
using Moq;
using Mov4e.Presenter.NewMoviePresenter;
using Mov4eTests.PresenterTests.NewMoviePresenterTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4eTests.ViewTests.NewMovieFormTests
{
    public class DummyMockedNewMoviePresenter
    {
        public INewMoviePresenter _inewMoviePresenter;
        private DummyMockedNewMovieService service = new DummyMockedNewMovieService();

        public DummyMockedNewMoviePresenter()
        {
            using (var mock = AutoMock.GetStrict())
            {
                mock.Mock<INewMoviePresenter>().Setup(_inewmPresenter => _inewmPresenter.AddMovie(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<Nullable<int>>(),
                    It.IsAny<Nullable<DateTime>>(), It.IsAny<string>(), It.IsAny<byte[]>(), It.IsAny<int>()))
                    .Callback((string t, int g, Nullable<int> pg, Nullable<DateTime> d, string s, byte[] p, int dur) =>
                    {
                        service._inewMovieService.CreateMovie(t, pg, g, d, s, p, dur);
                    });

                mock.Mock<INewMoviePresenter>().Setup(_inewmPresenter => _inewmPresenter.LastMovieId())
                    .Returns(() => service._inewMovieService.IdOfTheLastMovie());

                _inewMoviePresenter = mock.Create<INewMoviePresenter>();
            }
        }
    }
}

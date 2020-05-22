using Autofac.Extras.Moq;
using Moq;
using Mov4e.Service.NewMovieService;
using Mov4e.Validation;
using Mov4eTests.ServiceTests.NewMovieServiceTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4eTests.PresenterTests.NewMoviePresenterTests
{
    public class DummyMockedNewMovieService
    {
        public INewMovieService _inewMovieService;
        private DummyMockedNewMovieRepository repo = new DummyMockedNewMovieRepository();

        public DummyMockedNewMovieService()
        {
            using (var mock = AutoMock.GetStrict())
            {
                mock.Mock<INewMovieService>().Setup(_inewMService => _inewMService.CreateMovie(It.IsAny<string>(), It.IsAny<Nullable<int>>(), It.IsAny<int>(),
                    It.IsAny<Nullable<DateTime>>(), It.IsAny<string>(), It.IsAny<byte[]>(), It.IsAny<int>()))
                    .Callback((string title, Nullable<int> pg, int genre, Nullable<DateTime> date, string sum, byte[] pict, int dur) =>
                    {
                        repo._inewmRepo.CreateMovie(title, pg, genre, date, sum, pict, dur);
                    });

                mock.Mock<INewMovieService>().Setup(_inewMService => _inewMService.IdOfTheLastMovie())
                    .Returns(() => repo._inewmRepo.LastMovieId());
            }
        }
    }
}

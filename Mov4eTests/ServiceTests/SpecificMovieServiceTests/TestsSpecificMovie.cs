using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Service.SpecificMovieService;
using NUnit.Framework;
using Mov4e.Exceptions;

namespace Mov4eTests.ServiceTests.SpecificMovieServiceTests
{
    [TestFixture]
    class TestsSpecificMovie
    {
        [Test]
        public void GetMovieFromDBAndSetItInModelPaseses()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);
            _specificMovieInfoService.GetMovieFromDBAndSetItInModel(1);
            Assert.AreEqual("Transformers", _specificMovieInfoService.SetMovieInfo().title);
        }

        [Test]
        public void GetMovieFromDBAndSetItInModelThrowsException()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);

            Assert.Throws<SpecificMovieException>(() => _specificMovieInfoService.GetMovieFromDBAndSetItInModel(0));
        }

        [Test]
        public void SetMovieInfolReturns()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);
            _specificMovieInfoService.GetMovieFromDBAndSetItInModel(1);
            Assert.AreEqual("Transformers", _specificMovieInfoService.SetMovieInfo().title);
            Assert.AreEqual(1, _specificMovieInfoService.SetMovieInfo().pg);
        }

        [Test]
        public void SetMovieInfoThrowsException()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);
            _mockedDummySpecificMovieRepository.error = true;
            Assert.Throws<Exception>(() => _specificMovieInfoService.SetMovieInfo());
        }

        [Test]
        public void AddRateAdds()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);
            _specificMovieInfoService.AddRate(1, 4);
            Assert.AreEqual(4, _mockedDummySpecificMovieRepository.currentMovie.AVGRating);

        }

        [Test]
        public void AddRateThrowsException()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);
            Assert.Throws<SpecificMovieException>(() => _specificMovieInfoService.AddRate(1, -1));
        }

        [Test]
        public void SetUpdatedRateInModelPaseses()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);
            _specificMovieInfoService.GetMovieFromDBAndSetItInModel(1);
            _specificMovieInfoService.SetUpdatedRateInModel();
            Assert.AreEqual(5, _specificMovieInfoService.SetMovieInfo().avgRating);
        }

        [Test]
        public void SetUpdatedRateInModelThrowsException()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);

            Assert.Throws<SpecificMovieException>(() => _specificMovieInfoService.SetUpdatedRateInModel());
        }

        [Test]
        public void CheckIfUserRatedPaseses()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);
            Assert.AreEqual(true, _specificMovieInfoService.CheckIfUserRated(1));
        }

        [Test]
        public void CheckIfUserRatedThrowsException()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);

            Assert.Throws<SpecificMovieException>(() => _specificMovieInfoService.CheckIfUserRated(0));
        }

        [Test]
        public void CheckIfUserHasMovieInWatchListPaseses()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);
            Assert.AreEqual(true, _specificMovieInfoService.CheckIfUserHasMovieInWatchList(1));
        }

        [Test]
        public void CheckIfUserHasMovieInWatchListThrowsException()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);

            Assert.Throws<SpecificMovieException>(() => _specificMovieInfoService.CheckIfUserHasMovieInWatchList(0));
        }

        [Test]
        public void MovieRemoverRemoves()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);
            _specificMovieInfoService.GetMovieFromDBAndSetItInModel(1);
            _specificMovieInfoService.MovieRemover(1);
            Assert.AreEqual(2, _mockedDummySpecificMovieRepository.watchlist.Count);
        }

        [Test]
        public void MovieRemoverThrowsException()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);

            Assert.Throws<SpecificMovieException>(() => _specificMovieInfoService.MovieRemover(0));
        }

        [Test]
        public void MovieAdderAdds()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);
            _specificMovieInfoService.MovieAdder(1);
            Assert.AreEqual(4, _mockedDummySpecificMovieRepository.watchlist.Count);
        }

        [Test]
        public void MovieAdderThrowsException()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);

            Assert.Throws<SpecificMovieException>(() => _specificMovieInfoService.MovieAdder(0));
        }

        [Test]
        public void GetCommentsFromDBGetsTheComments()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);

            Assert.AreEqual(_mockedDummySpecificMovieRepository.comments,_specificMovieInfoService.GetCommentsFromDB());
        }

        [Test]
        public void SaveComentInDBSavesTheComment()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);
            _specificMovieInfoService.SaveComentInDB(1, "12123");
            Assert.AreEqual(3,_mockedDummySpecificMovieRepository.comments.Count);
        }

        [Test]
        public void SaveComentInDBThrowsException()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);

            Assert.Throws<SpecificMovieException>(() => _specificMovieInfoService.SaveComentInDB(0, "12123"));
        }

        [Test]
        public void DeleteCommentDeletes()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);
            _specificMovieInfoService.DeleteComment(new List<int>() {1});
            Assert.AreEqual(1, _mockedDummySpecificMovieRepository.comments.Count);
        }

        [Test]
        public void DeleteCommentThrowsException()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);

            Assert.Throws<SpecificMovieException>(() => _specificMovieInfoService.DeleteComment(new List<int>()));
        }

        [Test]
        public void GetCurrentUserUserNameReturnsUserName()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);

            Assert.AreEqual("Peshko",_specificMovieInfoService.GetCurrentUserUserName(1));
        }

        [Test]
        public void GetCurrentUserUserNameThrowsException()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);

            Assert.Throws<SpecificMovieException>(() => _specificMovieInfoService.GetCurrentUserUserName(0));
        }


        [Test]
        public void UserPositonReturnsPosition()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);

            Assert.AreEqual("admin", _specificMovieInfoService.UserPositon(1));
        }

        [Test]
        public void UserPositonThrowsException()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);

            Assert.Throws<SpecificMovieException>(() => _specificMovieInfoService.UserPositon(0));
        }

        [Test]
        public void GetLastCommentGetsTheLastComment()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);

            Assert.AreEqual(_mockedDummySpecificMovieRepository.comments.Last(), _specificMovieInfoService.GetLastComment(1));
        }

        [Test]
        public void GetLastCommentGetsTheLastCommentThrowsException()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);

            Assert.Throws<SpecificMovieException>(() => _specificMovieInfoService.GetLastComment(0));
        }

        [Test]
        public void GetUserRateReturnsRate()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);

            Assert.AreEqual(5, _specificMovieInfoService.GetUserRate(1));
        }

        [Test]
        public void GetUserRateThrowsException()
        {
            MockedDummySpecificMovieRepository _mockedDummySpecificMovieRepository = new MockedDummySpecificMovieRepository();
            ISpecificMovieInfoService _specificMovieInfoService = new SpecificMovieInfoService(_mockedDummySpecificMovieRepository._specificMovieInfoRepository);

            Assert.Throws<SpecificMovieException>(() => _specificMovieInfoService.GetUserRate(0));
        }
    }
}


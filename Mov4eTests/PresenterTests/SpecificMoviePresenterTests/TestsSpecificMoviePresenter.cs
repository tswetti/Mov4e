using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Presenter.SpecificMovieInfoPresenter;
using NUnit.Framework;

namespace Mov4eTests.PresenterTests.SpecificMoviePresenterTests
{
    [TestFixture]
    class TestsSpecificMoviePresenter
    {
        [Test]
        public void GetInfoForMovieGetsMovie()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);

            _presenter.GetInfoForMovie(1);

            Assert.AreEqual(_mockedDummyService._movie.title, _mockedDummyView.movieTitle);
        }

        [Test]
        public void GetInfoForMovieThrowsException()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _mockedDummyService.error = true;
            _presenter.GetInfoForMovie(1);
            Assert.AreNotEqual(_mockedDummyService._movie.title, _mockedDummyView.movieTitle);
        }

        [Test]
        public void RateMovieRates()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);

            _presenter.RateMovie(1);

            Assert.AreEqual(4, _mockedDummyService.rates.Count);
        }

        [Test]
        public void RateMovieRatesThrowsException()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _mockedDummyService.error = true;
            _presenter.RateMovie(1);
            Assert.AreNotEqual(4, _mockedDummyService.rates.Count);
        }

        [Test]
        public void UserAlreadyRatedReturnsTrues()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);

            Assert.AreEqual(true, _presenter.UserAlreadyRated());
        }

        [Test]
        public void UserAlreadyRatedThrowsException()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _mockedDummyService.error = true;

            Assert.AreNotEqual(true, _presenter.UserAlreadyRated());
        }

        [Test]
        public void UserHasMovieInWatchListReturnsTrue()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);

            Assert.AreEqual(true, _presenter.UserHasMovieInWatchList());
        }

        [Test]
        public void UserHasMovieInWatchListThrowsException()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _mockedDummyService.error = true;

            Assert.AreNotEqual(true, _presenter.UserHasMovieInWatchList());
        }

        [Test]
        public void DeleteMovieFromWatchLisDeletes()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _presenter.DeleteMovieFromWatchList();
            Assert.AreEqual(2, _mockedDummyService.watchlist.Count);
        }

        [Test]
        public void DeleteMovieFromWatchListThrowsException()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _mockedDummyService.error = true;
            _presenter.DeleteMovieFromWatchList();
            Assert.AreEqual(3, _mockedDummyService.watchlist.Count);
        }

        [Test]
        public void AddMovieINWatchListAdds()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _presenter.DeleteMovieFromWatchList();
            Assert.AreEqual(2, _mockedDummyService.watchlist.Count);
        }

        [Test]
        public void AddMovieINWatchListThrowsException()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _mockedDummyService.error = true;
            _presenter.AddMovieINWatchList();
            Assert.AreNotEqual(4, _mockedDummyService.watchlist.Count);
        }

        [Test]
        public void SetCommentsForTheMovieSetsComments()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _presenter.SetCommentsForTheMovie();
            Assert.AreEqual(_mockedDummyService.comments, _mockedDummyView.comments);
        }

        [Test]
        public void SetCommentsForTheMovieThrowsException()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _mockedDummyService.error = true;
            _presenter.SetCommentsForTheMovie();
            Assert.AreNotEqual(_mockedDummyService.comments, _mockedDummyView.comments);
        }

        [Test]
        public void AddCommentInDBAdds()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _presenter.AddCommentInDB("123124");
            Assert.AreEqual(3,_mockedDummyService.comments.Count);
        }

        [Test]
        public void AddCommentInDBThrowsException()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _mockedDummyService.error = true;
            _presenter.AddCommentInDB("12345");
            Assert.AreNotEqual(3, _mockedDummyService.comments.Count);
        }

        [Test]
        public void GetLastCommentGets()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            Assert.AreEqual(_mockedDummyService.comments.Last(), _presenter.GetLastComment());
        }

        [Test]
        public void GetLastCommentThrowsException()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _mockedDummyService.error = true;
            Assert.AreNotEqual(_mockedDummyService.comments, _presenter.GetLastComment());
        }

        [Test]
        public void DeleteCommentsDeletes()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _presenter.DeleteComments(new List<int>() { 1, 2, 3 });
            Assert.AreEqual(1, _mockedDummyService.comments.Count);
        }

        [Test]
        public void DeleteCommentsThrowsException()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _mockedDummyService.error = true;
            _presenter.DeleteComments(new List<int>() { 1, 2, 3 });
            Assert.AreEqual(2, _mockedDummyService.comments.Count);
        }

        [Test]
        public void GetUserNameGets()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            Assert.AreEqual("Zak", _presenter.GetUserName());
        }

        [Test]
        public void GetUserNameThrowsException()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _mockedDummyService.error = true;
            Assert.AreNotEqual("Zak", _presenter.GetUserName());
        }

        [Test]
        public void GetUserPositionGets()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _presenter.GetUserPosition();
            Assert.AreEqual("admin", _mockedDummyView.userPosition);
        }

        [Test]
        public void GetUserPositionThrowsException()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _mockedDummyService.error = true;
            _presenter.GetUserPosition();
            Assert.AreNotEqual("admin", _mockedDummyView.userPosition);
        }

        [Test]
        public void SetUserRateReturnsRate()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _presenter.SetUserRate();
            Assert.AreEqual(3, _mockedDummyView.userRate);
        }

        [Test]
        public void SetUserRateThrowsException()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _mockedDummyService.error = true;
            _presenter.SetUserRate();
            Assert.AreNotEqual(3, _mockedDummyView.userRate);
        }


        [Test]
        public void DeleteRateDeletes()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _presenter.DeleteRate();
            Assert.AreEqual(_mockedDummyService._movie.AVGRating, _mockedDummyView.movieAVGRate);
        }

        [Test]
        public void DeleteRateThrowsException()
        {
            MockedDummySpecificMovieService _mockedDummyService = new MockedDummySpecificMovieService();
            MockedDummySpecificMovieView _mockedDummyView = new MockedDummySpecificMovieView();
            ISpecificMovieInfoPresenter _presenter = new SpecificMovieInfoPresenter(_mockedDummyView, _mockedDummyService._specificMovieService);
            _mockedDummyService.error = true;
            _presenter.DeleteRate();
            Assert.AreNotEqual(_mockedDummyService._movie.AVGRating, _mockedDummyView.movieAVGRate);
        }
    }
}

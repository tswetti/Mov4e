using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Presenter.ProfileScreenPresenter;
using NUnit.Framework;
using Mov4e.View.ProfileScreenView;

namespace Mov4eTests.PresenterTests.ProfileScreenPresenterTests
{
    [TestFixture]
    class ProfileScreenPresenterTests
    {
        [Test]
        public void SetUserInformationSetsInfo()
        {
            MockedDummyProfileScreenService _mockedDummy = new MockedDummyProfileScreenService();
            IProfileScreen _profileScreen = new ProfileScreenViewDummy();
            ProfileScreenPresenter _profileScreenPresenter = new ProfileScreenPresenter(_profileScreen, _mockedDummy._profileScreenService);
            _profileScreenPresenter.SetUserInformation(1);

            Assert.AreEqual("MasterPesho", _profileScreen.UserName);
            Assert.AreEqual("Peter", _profileScreen.FirstName);
            Assert.AreEqual("Peter", _profileScreen.LastName);
            Assert.AreEqual(15, _profileScreen.Age);
            Assert.AreEqual("M", _profileScreen.Gender);
            Assert.AreEqual("lucho22@abv.bg", _profileScreen.Email);
            Assert.AreEqual(_profileScreen.Picture.Count(), _mockedDummy._userInfo.picture.Count());
        }

        [Test]
        public void UpdateWatchListWhenMovieAddedUpdates()
        {
            MockedDummyProfileScreenService _mockedDummy = new MockedDummyProfileScreenService();
            IProfileScreen _profileScreen = new ProfileScreenViewDummy();
            ProfileScreenPresenter _profileScreenPresenter = new ProfileScreenPresenter(_profileScreen, _mockedDummy._profileScreenService);
            _profileScreenPresenter.UpdateWatchListWhenMovieAdded(1);

            Assert.AreEqual(_mockedDummy.watchlist, _profileScreen.watchList);
        }
             

        [Test]
        public void ChangeProfilePictureChanges()
        {
            MockedDummyProfileScreenService _mockedDummy = new MockedDummyProfileScreenService();
            IProfileScreen _profileScreen = new ProfileScreenViewDummy();
            ProfileScreenPresenter _profileScreenPresenter = new ProfileScreenPresenter(_profileScreen, _mockedDummy._profileScreenService);
            _profileScreenPresenter.ChangeProfilePicture(new byte[50]);

            Assert.AreEqual(_mockedDummy._userInfo.picture.Count(), _profileScreen.Picture.Count());
        }

        [Test]
        public void ChangeProfilePictureCatchesException()
        {
            MockedDummyProfileScreenService _mockedDummy = new MockedDummyProfileScreenService();
            IProfileScreen _profileScreen = new ProfileScreenViewDummy();
            ProfileScreenPresenter _profileScreenPresenter = new ProfileScreenPresenter(_profileScreen, _mockedDummy._profileScreenService);
            _profileScreenPresenter.SetUserInformation(1);
            _profileScreenPresenter.SetUserInformation(1);
            _mockedDummy.error = true;
            _profileScreenPresenter.ChangeProfilePicture(new byte[50]);
            Assert.AreNotEqual(50, _profileScreen.Picture.Count());
        }

        [Test]
        public void DeleteMovieFromwatchListChanges()
        {
            MockedDummyProfileScreenService _mockedDummy = new MockedDummyProfileScreenService();
            IProfileScreen _profileScreen = new ProfileScreenViewDummy();
            ProfileScreenPresenter _profileScreenPresenter = new ProfileScreenPresenter(_profileScreen, _mockedDummy._profileScreenService);
            _profileScreenPresenter.SetUserInformation(1);
            _profileScreenPresenter.SetUserInformation(1);
            _profileScreenPresenter.DeleteMovieFromwatchList(1);

            Assert.AreEqual(2, _profileScreen.watchList.Count());
        }

        [Test]
        public void DeleteMovieFromwatchListCatchesException()
        {
            MockedDummyProfileScreenService _mockedDummy = new MockedDummyProfileScreenService();
            IProfileScreen _profileScreen = new ProfileScreenViewDummy();
            ProfileScreenPresenter _profileScreenPresenter = new ProfileScreenPresenter(_profileScreen, _mockedDummy._profileScreenService);
            _mockedDummy.error = true;
            _profileScreenPresenter.SetUserInformation(1);
            _profileScreenPresenter.DeleteMovieFromwatchList(1);
            Assert.AreNotEqual(2, _profileScreen.watchList.Count());
        }

        [Test]
        public void SetMovieTitelInViewReturns()
        {
            MockedDummyProfileScreenService _mockedDummy = new MockedDummyProfileScreenService();
            IProfileScreen _profileScreen = new ProfileScreenViewDummy();
            ProfileScreenPresenter _profileScreenPresenter = new ProfileScreenPresenter(_profileScreen, _mockedDummy._profileScreenService);

            Assert.AreEqual("Terminator", _profileScreenPresenter.SetMovieTitelInView(1));
        }
    }
}

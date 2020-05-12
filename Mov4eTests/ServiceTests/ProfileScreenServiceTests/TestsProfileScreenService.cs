using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Exceptions;
using NUnit.Framework;
using Mov4e.Service.ProfileScreenService;

namespace Mov4eTests.ServiceTests.ProfileScreenServiceTests
{
    [TestFixture]
    class TestsProfileScreenService
    {
        [Test]
        public void UserAndUserInfoFromDBAndStoreitInModelsIsSaving()
        {
            MockedDummyProfileScreenRepository _mockedDummy = new MockedDummyProfileScreenRepository();
            IProfileScreenService _profileScreenService= new ProfileScreenService(_mockedDummy._profileScreenRepository);
            _profileScreenService.UserAndUserInfoFromDBAndStoreitInModels(1);

            Assert.AreEqual("PeterMast",_profileScreenService.GiveUserInformation().username);
            Assert.AreEqual("Peter", _profileScreenService.GiveUserInformation().firstname);
        }

        [Test]
        public void UpdateProfilePictureIsUpdating()
        {
            MockedDummyProfileScreenRepository _mockedDummy = new MockedDummyProfileScreenRepository();
            IProfileScreenService _profileScreenService = new ProfileScreenService(_mockedDummy._profileScreenRepository);
            _profileScreenService.UserAndUserInfoFromDBAndStoreitInModels(1);
            byte[] z = new byte[10];
            _profileScreenService.UpdateProfilePicture(z);

            Assert.AreEqual(z, _profileScreenService.GiveUserInformation().picture);
        }


        [Test]
        public void UpdateProfilePictureThrowsException()
        {
            MockedDummyProfileScreenRepository _mockedDummy = new MockedDummyProfileScreenRepository();
            IProfileScreenService _profileScreenService = new ProfileScreenService(_mockedDummy._profileScreenRepository);
            _profileScreenService.UserAndUserInfoFromDBAndStoreitInModels(1);
            byte[] z = new byte[0];

            Assert.Throws<IncorrectUserDataException>(() => _profileScreenService.UpdateProfilePicture(z));
        }

        [Test]
        public void GiveWatchListIsGiving()
        {
            MockedDummyProfileScreenRepository _mockedDummy = new MockedDummyProfileScreenRepository();
            IProfileScreenService _profileScreenService = new ProfileScreenService(_mockedDummy._profileScreenRepository);

            Assert.AreEqual(_mockedDummy._profileScreenRepository.GetUserWatchlist(1), _profileScreenService.GiveWatchList(1));
        }

        [Test]
        public void SetMovieTitleForMoviesInWatchListReturnsTitle()
        {
            MockedDummyProfileScreenRepository _mockedDummy = new MockedDummyProfileScreenRepository();
            IProfileScreenService _profileScreenService = new ProfileScreenService(_mockedDummy._profileScreenRepository);

            Assert.AreEqual("Terminator", _profileScreenService.SetMovieTitleForMoviesInWatchList(1));
        }

        [Test]
        public void MovieRemoverRemovesFromWatchList()
        {
            MockedDummyProfileScreenRepository _mockedDummy = new MockedDummyProfileScreenRepository();
            IProfileScreenService _profileScreenService = new ProfileScreenService(_mockedDummy._profileScreenRepository);
            _profileScreenService.MovieRemover(1);
            Assert.AreEqual(2,_mockedDummy._profileScreenRepository.GetUserWatchlist(1).Count());
        }

        [Test]
        public void MovieRemoverThrowsException()
        {
            MockedDummyProfileScreenRepository _mockedDummy = new MockedDummyProfileScreenRepository();
            IProfileScreenService _profileScreenService = new ProfileScreenService(_mockedDummy._profileScreenRepository);

            Assert.Throws<IncorrectUserDataException>(() => _profileScreenService.MovieRemover(0));
        }
    }

}

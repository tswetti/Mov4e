using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Exceptions;
using NUnit.Framework;
using Mov4e.Service.ProfileScreenService;

namespace Mov4eTests.ServiceTests.ProfileSettingsTests
{
    [TestFixture]
    class TestsProfileScreenSettings
    {
        [Test]
        public void UpdateMailIsUpdating()
        {
            MockedDummyProfileScreenSettingsRepo _mockedDummy = new MockedDummyProfileScreenSettingsRepo();
            IProfileScreenSettingsService _profileScreenService = new ProfileScreenSettingsService(_mockedDummy._profileScreenSettingsRepository);
            _profileScreenService.UpdateMail("lel@gmail.com");

            Assert.AreEqual("lel@gmail.com", _mockedDummy._userInfo.email);
        }

        [Test]
        public void UpdateMailThrowsException()
        {
            MockedDummyProfileScreenSettingsRepo _mockedDummy = new MockedDummyProfileScreenSettingsRepo();
            IProfileScreenSettingsService _profileScreenService = new ProfileScreenSettingsService(_mockedDummy._profileScreenSettingsRepository);

            Assert.Throws<IncorrectUserDataException>(() => _profileScreenService.UpdateMail("lel@gmai:.com"));
        }

        [Test]
        public void UpdateAgeIsUpdating()
        {
            MockedDummyProfileScreenSettingsRepo _mockedDummy = new MockedDummyProfileScreenSettingsRepo();
            IProfileScreenSettingsService _profileScreenService = new ProfileScreenSettingsService(_mockedDummy._profileScreenSettingsRepository);
            _profileScreenService.UpdateAge(10);

            Assert.AreEqual(10, _mockedDummy._userInfo.age);
        }

        [Test]
        public void UpdateAgeThrowsException()
        {
            MockedDummyProfileScreenSettingsRepo _mockedDummy = new MockedDummyProfileScreenSettingsRepo();
            IProfileScreenSettingsService _profileScreenService = new ProfileScreenSettingsService(_mockedDummy._profileScreenSettingsRepository);

            Assert.Throws<IncorrectUserDataException>(() => _profileScreenService.UpdateAge(-10));
        }

        [Test]
        public void UpdateGenderIsUpdating()
        {
            MockedDummyProfileScreenSettingsRepo _mockedDummy = new MockedDummyProfileScreenSettingsRepo();
            IProfileScreenSettingsService _profileScreenService = new ProfileScreenSettingsService(_mockedDummy._profileScreenSettingsRepository);
            _profileScreenService.UpdateGender("F");

            Assert.AreEqual("F", _mockedDummy._userInfo.gender);
        }

        [Test]
        public void UpdateGenderThrowsException()
        {
            MockedDummyProfileScreenSettingsRepo _mockedDummy = new MockedDummyProfileScreenSettingsRepo();
            IProfileScreenSettingsService _profileScreenService = new ProfileScreenSettingsService(_mockedDummy._profileScreenSettingsRepository);

            Assert.Throws<IncorrectUserDataException>(() => _profileScreenService.UpdateGender("Fasd"));
        }

        [Test]
        public void UpdatePasswordIsUpdating()
        {
            MockedDummyProfileScreenSettingsRepo _mockedDummy = new MockedDummyProfileScreenSettingsRepo();
            IProfileScreenSettingsService _profileScreenService = new ProfileScreenSettingsService(_mockedDummy._profileScreenSettingsRepository);
            _profileScreenService.UpdatePassword("1234", "1234Aa!sadas", "1234Aa!sadas");

            Assert.AreNotSame(_mockedDummy._user.password, "123");
        }

        [Test]
        public void UpdatePasswordThrowsException()
        {
            MockedDummyProfileScreenSettingsRepo _mockedDummy = new MockedDummyProfileScreenSettingsRepo();
            IProfileScreenSettingsService _profileScreenService = new ProfileScreenSettingsService(_mockedDummy._profileScreenSettingsRepository);

            Assert.Throws<IncorrectUserDataException>(() => _profileScreenService.UpdatePassword("1234", "1234","1234"));
        }

        [Test]
        public void UpdateUserNameIsUpdating()
        {
            MockedDummyProfileScreenSettingsRepo _mockedDummy = new MockedDummyProfileScreenSettingsRepo();
            IProfileScreenSettingsService _profileScreenService = new ProfileScreenSettingsService(_mockedDummy._profileScreenSettingsRepository);
            _profileScreenService.UpdateUserName("Fransis");

            Assert.AreEqual("Fransis", _mockedDummy._user.userName);
        }

        [Test]
        public void UpdateUserNameThrowsException()
        {
            MockedDummyProfileScreenSettingsRepo _mockedDummy = new MockedDummyProfileScreenSettingsRepo();
            IProfileScreenSettingsService _profileScreenService = new ProfileScreenSettingsService(_mockedDummy._profileScreenSettingsRepository);

            Assert.Throws<IncorrectUserDataException>(() => _profileScreenService.UpdateUserName("F"));
        }

        [Test]
        public void UpdateFirstNameIsUpdating()
        {
            MockedDummyProfileScreenSettingsRepo _mockedDummy = new MockedDummyProfileScreenSettingsRepo();
            IProfileScreenSettingsService _profileScreenService = new ProfileScreenSettingsService(_mockedDummy._profileScreenSettingsRepository);
            _profileScreenService.UpdateFirstName("Fransis");


            Assert.AreEqual("Fransis", _mockedDummy._userInfo.firstName);
        }

        [Test]
        public void UpdateFirstNameThrowsException()
        {
            MockedDummyProfileScreenSettingsRepo _mockedDummy = new MockedDummyProfileScreenSettingsRepo();
            IProfileScreenSettingsService _profileScreenService = new ProfileScreenSettingsService(_mockedDummy._profileScreenSettingsRepository);

            Assert.Throws<IncorrectUserDataException>(() => _profileScreenService.UpdateFirstName("1"));
        }

        [Test]
        public void UpdateLastNameIsUpdating()
        {
            MockedDummyProfileScreenSettingsRepo _mockedDummy = new MockedDummyProfileScreenSettingsRepo();
            IProfileScreenSettingsService _profileScreenService = new ProfileScreenSettingsService(_mockedDummy._profileScreenSettingsRepository);
            _profileScreenService.UpdateLastName("Petrow");


            Assert.AreEqual("Petrow", _mockedDummy._userInfo.lastName);
        }

        [Test]
        public void UpdateLastNameThrowsException()
        {
            MockedDummyProfileScreenSettingsRepo _mockedDummy = new MockedDummyProfileScreenSettingsRepo();
            IProfileScreenSettingsService _profileScreenService = new ProfileScreenSettingsService(_mockedDummy._profileScreenSettingsRepository);

            Assert.Throws<IncorrectUserDataException>(() => _profileScreenService.UpdateLastName("1"));
        }

       
    }
}

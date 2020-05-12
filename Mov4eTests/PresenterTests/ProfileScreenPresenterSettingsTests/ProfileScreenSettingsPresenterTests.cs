using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Presenter.ProfileScreenPresenter;
using NUnit.Framework;
using Mov4e.View.ProfileScreenView;

namespace Mov4eTests.PresenterTests.ProfileScreenPresenterSettingsTests
{
    [TestFixture]
    class ProfileScreenSettingsPresenterTests
    {
        [Test]
        public void ChangeEmailChanges()
        {
            MockedDummyProfileScreenSettingsService _mockedDummy = new MockedDummyProfileScreenSettingsService();
            IProfileScreen _profileScreen = new MockedDummyProfileScreenView();
            ISettingsPresenter _profileScreenPresenter = new SettingsPresenter(_profileScreen, _mockedDummy._profileScreenSettingsService);
            _profileScreenPresenter.ChangeEmail("Niki@abv.bg");

            Assert.AreEqual("Niki@abv.bg", _profileScreen.Email);
        }

        [Test]
        public void ChangeEmailCatchesException()
        {
            MockedDummyProfileScreenSettingsService _mockedDummy = new MockedDummyProfileScreenSettingsService();
            IProfileScreen _profileScreen = new MockedDummyProfileScreenView();
            ISettingsPresenter _profileScreenPresenter = new SettingsPresenter(_profileScreen, _mockedDummy._profileScreenSettingsService);
            _mockedDummy.error = true;
            _profileScreenPresenter.ChangeEmail("Niki@abv.bg");
            Assert.AreNotEqual("NIki@abv.bg", _profileScreen.Email);
        }

        [Test]
        public void ChangeAgeChanges()
        {
            MockedDummyProfileScreenSettingsService _mockedDummy = new MockedDummyProfileScreenSettingsService();
            IProfileScreen _profileScreen = new MockedDummyProfileScreenView();
            ISettingsPresenter _profileScreenPresenter = new SettingsPresenter(_profileScreen, _mockedDummy._profileScreenSettingsService);
            _profileScreenPresenter.ChangeAge(2);

            Assert.AreEqual(2, _profileScreen.Age);
        }

        [Test]
        public void ChangeAgeCatchesException()
        {
            MockedDummyProfileScreenSettingsService _mockedDummy = new MockedDummyProfileScreenSettingsService();
            IProfileScreen _profileScreen = new MockedDummyProfileScreenView();
            ISettingsPresenter _profileScreenPresenter = new SettingsPresenter(_profileScreen, _mockedDummy._profileScreenSettingsService);
            _mockedDummy.error = true;
            _profileScreenPresenter.ChangeAge(12);
            Assert.AreNotEqual(12, _profileScreen.Age);

        }

        [Test]
        public void ChangeGenderChanges()
        {
            MockedDummyProfileScreenSettingsService _mockedDummy = new MockedDummyProfileScreenSettingsService();
            IProfileScreen _profileScreen = new MockedDummyProfileScreenView();
            ISettingsPresenter _profileScreenPresenter = new SettingsPresenter(_profileScreen, _mockedDummy._profileScreenSettingsService);
            _profileScreenPresenter.ChangeGender("F");

            Assert.AreEqual("F", _profileScreen.Gender);
        }

        [Test]
        public void ChangeGenderCatchesException()
        {
            MockedDummyProfileScreenSettingsService _mockedDummy = new MockedDummyProfileScreenSettingsService();
            IProfileScreen _profileScreen = new MockedDummyProfileScreenView();
            ISettingsPresenter _profileScreenPresenter = new SettingsPresenter(_profileScreen, _mockedDummy._profileScreenSettingsService);
            _mockedDummy.error = true;
            _profileScreenPresenter.ChangeGender("F");
            Assert.AreNotEqual("F", _profileScreen.Gender);
        }

        [Test]
        public void ChangePasswordChanges()
        {
            MockedDummyProfileScreenSettingsService _mockedDummy = new MockedDummyProfileScreenSettingsService();
            IProfileScreen _profileScreen = new MockedDummyProfileScreenView();
            ISettingsPresenter _profileScreenPresenter = new SettingsPresenter(_profileScreen, _mockedDummy._profileScreenSettingsService);
            _profileScreenPresenter.ChangePassword("1234", "12234", "1234");

            Assert.AreEqual("12234", _mockedDummy._user.password);
        }

        [Test]
        public void ChangePasswordCatchesException()
        {
            MockedDummyProfileScreenSettingsService _mockedDummy = new MockedDummyProfileScreenSettingsService();
            IProfileScreen _profileScreen = new MockedDummyProfileScreenView();
            ISettingsPresenter _profileScreenPresenter = new SettingsPresenter(_profileScreen, _mockedDummy._profileScreenSettingsService);
            _mockedDummy.error = true;
            Assert.Throws<Exception>(()=>_profileScreenPresenter.ChangePassword("1234", "122343", "1234"));
 
        }

        [Test]
        public void ChangeUserNameChanges()
        {
            MockedDummyProfileScreenSettingsService _mockedDummy = new MockedDummyProfileScreenSettingsService();
            IProfileScreen _profileScreen = new MockedDummyProfileScreenView();
            ISettingsPresenter _profileScreenPresenter = new SettingsPresenter(_profileScreen, _mockedDummy._profileScreenSettingsService);
            _profileScreenPresenter.ChangeUserName("MasterGigo");

            Assert.AreEqual("MasterGigo", _profileScreen.UserName);
        }

        [Test]
        public void ChangeUserNameCatchesException()
        {
            MockedDummyProfileScreenSettingsService _mockedDummy = new MockedDummyProfileScreenSettingsService();
            IProfileScreen _profileScreen = new MockedDummyProfileScreenView();
            ISettingsPresenter _profileScreenPresenter = new SettingsPresenter(_profileScreen, _mockedDummy._profileScreenSettingsService);
            _mockedDummy.error = true;
            _profileScreenPresenter.ChangeUserName("MasterGigo");
            Assert.AreNotEqual("MasterGigo", _profileScreen.UserName);
        }

        [Test]
        public void ChangeFirstNameChanges()
        {
            MockedDummyProfileScreenSettingsService _mockedDummy = new MockedDummyProfileScreenSettingsService();
            IProfileScreen _profileScreen = new MockedDummyProfileScreenView();
            ISettingsPresenter _profileScreenPresenter = new SettingsPresenter(_profileScreen, _mockedDummy._profileScreenSettingsService);
            _profileScreenPresenter.ChangeFirstName("MasterGigo");

            Assert.AreEqual("MasterGigo", _profileScreen.FirstName);
        }

        [Test]
        public void ChangeFirstNameCatchesException()
        {
            MockedDummyProfileScreenSettingsService _mockedDummy = new MockedDummyProfileScreenSettingsService();
            IProfileScreen _profileScreen = new MockedDummyProfileScreenView();
            ISettingsPresenter _profileScreenPresenter = new SettingsPresenter(_profileScreen, _mockedDummy._profileScreenSettingsService);
            _mockedDummy.error = true;
            _profileScreenPresenter.ChangeFirstName("MasterGigo");
            Assert.AreNotEqual("MasterGigo", _profileScreen.FirstName);
        }

        [Test]
        public void ChangeLastNameChanges()
        {
            MockedDummyProfileScreenSettingsService _mockedDummy = new MockedDummyProfileScreenSettingsService();
            IProfileScreen _profileScreen = new MockedDummyProfileScreenView();
            ISettingsPresenter _profileScreenPresenter = new SettingsPresenter(_profileScreen, _mockedDummy._profileScreenSettingsService);
            _profileScreenPresenter.ChangeLastName("MasterGigo");

            Assert.AreEqual("MasterGigo", _profileScreen.LastName);
        }

        [Test]
        public void ChangeLastNameCatchesException()
        {
            MockedDummyProfileScreenSettingsService _mockedDummy = new MockedDummyProfileScreenSettingsService();
            IProfileScreen _profileScreen = new MockedDummyProfileScreenView();
            ISettingsPresenter _profileScreenPresenter = new SettingsPresenter(_profileScreen, _mockedDummy._profileScreenSettingsService);
            _mockedDummy.error = true;
            _profileScreenPresenter.ChangeLastName("MasterGigo");
            Assert.AreNotEqual("MasterGigo", _profileScreen.LastName);
        }
    }
}

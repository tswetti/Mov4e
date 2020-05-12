using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Autofac.Extras.Moq;
using Mov4e.Repository.ProfileScreenRepository;


namespace Mov4eTests.ServiceTests.ProfileSettingsTests
{
    class MockedDummyProfileScreenSettingsRepo
    {
        public List<string> usernames = new List<string>() { "WOLFER", "ZakMaster" };

        public List<string> emails = new List<string>() { "lucho22@abv.bg", "Pesho@abv.bg" };

        public User _user = new User
        {
            userName = "PeterMast",
            id = 2,
            password = "S4i4VgIP4Wg0Gn19QAEeo2jSgF6Aj2NQfiJN + KwcKGFcW7zj"
        };

        public UserInfo _userInfo = new UserInfo
        {
            firstName = "Peter",
            lastName = "Nikolow",
            email = "lucho22@abv.bg",
            age = 15,
            gender = "M",
            id = 2,
            picture = new byte[10]
        };

        public IProfileSettingsRepository _profileScreenSettingsRepository;
        public MockedDummyProfileScreenSettingsRepo()
        {
            using (var mock = AutoMock.GetStrict())
            {

                mock.Mock<IProfileSettingsRepository>().Setup(ip => ip.ChangeAge(It.IsAny<int>(), It.IsAny<int>()))
                                                     .Callback((int user, int age) => this._userInfo.age = age);

                mock.Mock<IProfileSettingsRepository>().Setup(ip => ip.ChangeFirstName(It.IsAny<int>(), It.IsAny<string>()))
                                                     .Callback((int user, string frname) => this._userInfo.firstName = frname);

                mock.Mock<IProfileSettingsRepository>().Setup(ip => ip.ChangeLastName(It.IsAny<int>(), It.IsAny<string>()))
                                                     .Callback((int user, string lsname) => this._userInfo.firstName = lsname);

                mock.Mock<IProfileSettingsRepository>().Setup(ip => ip.ChangeGender(It.IsAny<int>(), It.IsAny<string>()))
                                                     .Callback((int user, string gender) => this._userInfo.gender = gender);

                mock.Mock<IProfileSettingsRepository>().Setup(ip => ip.ChangeMail(It.IsAny<int>(), It.IsAny<string>()))
                                                     .Callback((int user, string mail) => this._userInfo.email = mail);

                mock.Mock<IProfileSettingsRepository>().Setup(ip => ip.ChangePassword(It.IsAny<int>(), It.IsAny<string>()))
                                                     .Callback((int user, string pass) => this._user.password = pass);


                mock.Mock<IProfileSettingsRepository>().Setup(ip => ip.ChangeUserName(It.IsAny<int>(), It.IsAny<string>()))
                                                     .Callback((int user, string username) => this._user.userName = username);

                mock.Mock<IProfileSettingsRepository>().Setup(ip => ip.GetDataForThisUser(It.IsAny<int>())).Returns(this._userInfo);

                mock.Mock<IProfileSettingsRepository>().Setup(ip => ip.GetListOfEMails()).Returns(this.emails);

                mock.Mock<IProfileSettingsRepository>().Setup(ip => ip.GetListOfUserNames()).Returns(this.usernames);

                mock.Mock<IProfileSettingsRepository>().Setup(ip => ip.GetUserFromDB(It.IsAny<int>())).Returns(this._user);

                _profileScreenSettingsRepository = mock.Create<IProfileSettingsRepository>();

            }
        }
    }
}

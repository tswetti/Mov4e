using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Autofac.Extras.Moq;
using Mov4e.Repository.RegisterRepository;
using Mov4e;


namespace Mov4eTests.ServiceTests.RegisterServiceTests
{
    class MockedDummyRegisterRepository
    {
        List<string> usernames = new List<string> { "Pesho", "Niki" };
        List<string> emails = new List<string> { "pg@abv.bg", "z@gmail.com" };
        public User _user=new User();
        public UserInfo _userinfo=new UserInfo();

        public IRegisterRepository _registerRepository;

        public MockedDummyRegisterRepository()
        {
            using (var mock = AutoMock.GetStrict())
            {
                mock.Mock<IRegisterRepository>().Setup(ireg => ireg.GetListOfEMails()).Returns(emails);

                mock.Mock<IRegisterRepository>().Setup(ireg => ireg.GetListOfUserNames()).Returns(usernames);

                mock.Mock<IRegisterRepository>().Setup(ireg => ireg.SaveUser(It.IsAny<User>(), It.IsAny<UserInfo>()))
                                                                 .Callback((User user, UserInfo userinfo) =>
                                                                 {
                                                                     _user.userName = user.userName;
                                                                     _user.password = user.password;
                                                                     _userinfo.age = userinfo.age;
                                                                      _userinfo.email = userinfo.email;
                                                                     _userinfo.firstName = userinfo.firstName;
                                                                     _userinfo.lastName = userinfo.lastName;
                                                                     _userinfo.picture = userinfo.picture;
                                                                     _userinfo.gender = userinfo.gender;
                                                                     _userinfo.position = userinfo.position;
                                                                     _userinfo.user = userinfo.user;
                                                                 });

                _registerRepository = mock.Create<IRegisterRepository>();
            }
        }
    }
}

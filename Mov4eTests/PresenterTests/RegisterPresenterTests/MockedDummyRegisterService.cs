using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Autofac.Extras.Moq;
using Mov4e.Service.RegisterService;
using Mov4e.Model;

namespace Mov4eTests.PresenterTests.RegisterPresenterTests
{
    class MockedDummyRegisterService
    {
        public IRegisterService _registerService;
        public UserInfo _userinfo=new UserInfo();
        public User _user=new User();
        public bool error = true;

        public MockedDummyRegisterService()
        {
            using (var mock = AutoMock.GetStrict())
            {
                mock.Mock<IRegisterService>().Setup(ir => ir.SaveUser(It.IsAny<string>(), It.IsAny<string>()))
                                             .Callback((string one, string two) =>
                                             {
                                                 _user.userName = one;
                                                 _user.password = two;
                                             });

                mock.Mock<IRegisterService>().Setup(ireg => ireg.SaveUserInfo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),It.IsAny<int>()))
                                                                .Callback((string frname,string lsname,string mail,string gender, int age) =>
                                                                {
                                                                    _userinfo.age = age;
                                                                    _userinfo.email = mail;
                                                                    _userinfo.firstName = frname;
                                                                    _userinfo.lastName = lsname;
                                                                    _userinfo.gender = gender;
                                                                });

                mock.Mock<IRegisterService>().Setup(ir => ir.SaveDataInDB())
                                             .Callback(()=> 
                                             {
                                                 if (error==true)
                                                 {
                                                     throw new Exception();
                                                 }
                                             });
                _registerService = mock.Create<IRegisterService>();
            }
        }
    
    }
}

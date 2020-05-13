using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Autofac.Extras.Moq;
using Mov4e.Service.ProfileScreenService;
using Mov4e.Model;

namespace Mov4eTests.PresenterTests.ProfileScreenPresenterSettingsTests
{
    class MockedDummyProfileScreenSettingsService
    {
        public bool error = false;

        public User _user = new User()
        {
            userName = "MasterPesho",
            password = "1234",
            id = 1
        };

        public UserInfo _userInfo = new UserInfo()
        {
            firstName = "Peter",
            lastName = "Peter",
            age = 15,
            gender = "M",
            email = "lucho22@abv.bg",
            id = 1,
            picture = new byte[1]
        };

        public IProfileScreenSettingsService _profileScreenSettingsService;

        public MockedDummyProfileScreenSettingsService()
        {
            
            using (var mock = AutoMock.GetStrict())
            {
                mock.Mock<IProfileScreenSettingsService>().Setup(prs => prs.UpdateMail(It.IsAny<string>()))
                                                 .Callback((string mail) =>
                                                 {
                                                     if (error == true)
                                                     {
                                                         throw new Exception();
                                                     }
                                                     else
                                                         _userInfo.email = mail;
                                                 }
                                                 );

                mock.Mock<IProfileScreenSettingsService>().Setup(prs => prs.UpdateAge(It.IsAny<int>()))
                                                   .Callback((int age) =>
                                                   {
                                                       if (error == true)
                                                       {
                                                           throw new Exception();
                                                       }
                                                       else
                                                           _userInfo.age = age;
                                                   }
                                                  );


                mock.Mock<IProfileScreenSettingsService>().Setup(prs => prs.UpdateGender(It.IsAny<string>()))
                                                   .Callback((string gender) =>
                                                   {
                                                       if (error == true)
                                                       {
                                                           throw new Exception();
                                                       }
                                                       else
                                                           _userInfo.gender = gender;
                                                   });


                mock.Mock<IProfileScreenSettingsService>().Setup(prs => prs.UpdatePassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                                                   .Callback((string old, string newPass,string repPass) =>
                                                   {
                                                       if (error == true)
                                                       {
                                                           throw new Exception();
                                                       }
                                                       else
                                                           _user.password = newPass;
                                                   });

                mock.Mock<IProfileScreenSettingsService>().Setup(prs => prs.UpdateUserName(It.IsAny<string>()))
                                                   .Callback((string userName) =>
                                                   {
                                                       if (error == true)
                                                       {
                                                           throw new Exception();
                                                       }
                                                       else
                                                           _user.userName = userName;
                                                   });


                mock.Mock<IProfileScreenSettingsService>().Setup(prs => prs.UpdateFirstName(It.IsAny<string>()))
                                                  .Callback((string firstName) =>
                                                  {
                                                      if (error == true)
                                                      {
                                                          throw new Exception();
                                                      }
                                                      else
                                                          _userInfo.firstName = firstName;
                                                  });


                mock.Mock<IProfileScreenSettingsService>().Setup(prs => prs.UpdateLastName(It.IsAny<string>()))
                                                  .Callback((string lastName) =>
                                                  {
                                                      if (error == true)
                                                      {
                                                          throw new Exception();
                                                      }
                                                      else
                                                          _userInfo.lastName = lastName;
                                                  });

                _profileScreenSettingsService = mock.Create<IProfileScreenSettingsService>();
            }
        }
    }
}

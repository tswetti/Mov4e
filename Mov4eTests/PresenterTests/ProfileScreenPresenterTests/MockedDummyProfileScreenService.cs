using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Autofac.Extras.Moq;
using Mov4e.Service.ProfileScreenService;
using Mov4e.Model;

namespace Mov4eTests.PresenterTests.ProfileScreenPresenterTests
{
    class MockedDummyProfileScreenService
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
        
        public Dictionary<int, byte[]> watchlist = new Dictionary<int, byte[]>()
        {
            {1,new byte[10] },
            {2,new byte[11] },
            {3,new byte[12] }
        };

        public IProfileScreenService _profileScreenService;

        public MockedDummyProfileScreenService()
        {
            using (var mock = AutoMock.GetStrict())
            {
                mock.Mock<IProfileScreenService>().Setup(prs => prs.UserAndUserInfoFromDBAndStoreitInModels(It.IsAny<int>()));
               

                mock.Mock<IProfileScreenService>().Setup(prs => prs.GiveUserInformation())
                                            .Returns((_user.userName, _userInfo.firstName,
                                                      _userInfo.lastName, _userInfo.email,
                                                      _userInfo.gender,
                                                      _userInfo.age, _userInfo.picture));

               

                mock.Mock<IProfileScreenService>().Setup(prs => prs.UpdateProfilePicture(It.IsAny<byte[]>()))
                                                  .Callback((byte[] pic) =>
                                                  {
                                                      if (error == true)
                                                      {
                                                          throw new Exception();
                                                      }
                                                      else
                                                         _userInfo.picture = pic;
                                                  }); 
                                                 

                mock.Mock<IProfileScreenService>().Setup(prs => prs.GiveWatchList(It.IsAny<int>()))
                                                 .Returns(watchlist);

                mock.Mock<IProfileScreenService>().Setup(prs => prs.SetMovieTitleForMoviesInWatchList(It.IsAny<int>()))
                                                .Returns("Terminator");

                mock.Mock<IProfileScreenService>().Setup(prs => prs.MovieRemover(It.IsAny<int>()))
                                                .Callback((int id) =>
                                                {
                                                    if (error == true)
                                                    {
                                                        throw new Exception();
                                                    }
                                                    else
                                                    this.watchlist.Remove(id);
                                                });

                _profileScreenService = mock.Create<IProfileScreenService>();
            }
        }
    }
}

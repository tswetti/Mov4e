using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Autofac.Extras.Moq;
using Mov4e.Repository.ProfileScreenRepository;


namespace Mov4eTests.ServiceTests.ProfileScreenServiceTests
{
    class MockedDummyProfileScreenRepository
    {      
        Dictionary<int, byte[]> watchlist = new Dictionary<int, byte[]>()
        {
            {1,new byte[10] },
            {2,new byte[11] },
            {3,new byte[12] }
        };

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


        public IProfileScreenRepository _profileScreenRepository;

        public MockedDummyProfileScreenRepository()
        {
            using (var mock = AutoMock.GetStrict())
            {
                mock.Mock<IProfileScreenRepository>().Setup(ip => ip.ChangeProfilePicture(It.IsAny<int>(), It.IsAny<byte[]>()))
                                     .Callback((int user, byte[] pic) => _userInfo.picture = pic);

                mock.Mock<IProfileScreenRepository>().Setup(ip => ip.GetMovieTitle(It.IsAny<int>())).Returns("Terminator");

                mock.Mock<IProfileScreenRepository>().Setup(ip => ip.GetUserFromDB(It.IsAny<int>())).Returns(this._user);

                mock.Mock<IProfileScreenRepository>().Setup(ip => ip.GetUserWatchlist(It.IsAny<int>())).Returns(this.watchlist);

                mock.Mock<IProfileScreenRepository>().Setup(ip => ip.RemoveFromWatchList(It.IsAny<int>(), It.IsAny<int>()))
                                                      .Callback((int user, int movie) =>
                                                      {
                                                          watchlist.Remove(movie);
                                                      }
                                                      );

                mock.Mock<IProfileScreenRepository>().Setup(ip => ip.GetDataForThisUser(It.IsAny<int>())).Returns(_userInfo);

                _profileScreenRepository = mock.Create<IProfileScreenRepository>();
            }
        }
    }
}
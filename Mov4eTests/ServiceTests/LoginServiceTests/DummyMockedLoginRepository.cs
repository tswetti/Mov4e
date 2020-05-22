using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Autofac.Extras.Moq;
using Mov4e.Repository.LogInRepository;
using Mov4e;
using Mov4e.Model;

namespace Mov4eTests.ServiceTests.LoginServiceTests
{
    class DummyMockedLoginRepository
    {
        List<User> users = new List<User>
        {   new User { id = 1, userName = "Wolf", password = "1234"},
            new User { id = 2, userName = "Wolf2", password = "1234" },
            new User { id = 3, userName = "Wolf3", password = "1234"},
            new User { id = 4, userName = "Wolf4", password = "0NFrL36PKuFDzcJhJWmre2RlrOxQ2N6zqevWe8mIdiXx4ds+"}
          
        };

        public ILogInRepository _logInRepository;

        public DummyMockedLoginRepository()
        {
            using (var mock = AutoMock.GetStrict())
            {
                mock.Mock<ILogInRepository>().Setup(im => im.GetCurrentUserID(It.IsAny<string>()))
                                            .Returns((string q) => users.Where(u => u.userName == q).Single().id);

                mock.Mock<ILogInRepository>().Setup(im => im.GetPasswordForUser(It.IsAny<string>()))
                                            .Returns((string q) => users.Where(u => u.userName == q).Single().password);

                mock.Mock<ILogInRepository>().Setup(im => im.checkIfUserIsInDB(It.IsAny<string>()))
                                            .Returns((string q) =>users.Any(u=>u.userName==q));

                mock.Mock<ILogInRepository>().Setup(im=>im.GetCurrentUserPosition(It.IsAny<string>()))
                                          .Returns("Admin");

                mock.Mock<ILogInRepository>().Setup(im => im.UpdatePass(It.IsAny<string>(), It.IsAny<string>()))
                                         .Callback((string username, string pass) =>
                                                    {
                                                        users.Where(u => u.userName == username).First().password = pass;
                                                    });

                mock.Mock<ILogInRepository>().Setup(im => im.GetUserFullName(It.IsAny<string>()))
                                         .Returns("Pesho Petrow");

                mock.Mock<ILogInRepository>().Setup(im => im.GetEmailForUser(It.IsAny<string>()))
                                        .Returns("lucho22@abv.bg");


                _logInRepository = mock.Create<ILogInRepository>();
            }
        }
    }
}

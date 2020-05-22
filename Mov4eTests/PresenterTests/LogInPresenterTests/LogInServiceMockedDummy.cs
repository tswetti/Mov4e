using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Autofac.Extras.Moq;
using Mov4e.Service.LogInService;
using Mov4e;

namespace Mov4eTests.PresenterTests.LogInPresenterTests
{
    class LogInServiceMockedDummy
    {
        public ILogInService _ilogService;

        public string pass=null;
        public bool correct=true;
        public LogInServiceMockedDummy()
        {
            using (var mock = AutoMock.GetStrict())
            {
                mock.Mock<ILogInService>().Setup(m => m.SaveDataFromView(It.IsAny<string>(), It.IsAny<string>()))
                                          .Callback((string name, string pas) => { name = null; pas = null; });


                mock.Mock<ILogInService>().Setup(m => m.GetPosition())
                                          .Returns("Admin");
                                         

                mock.Mock<ILogInService>().Setup(m => m.GetIDLoggedUser())
                                          .Returns(1);


                mock.Mock<ILogInService>().Setup(m => m.CorrectLogin())
                                          .Returns(() =>
                                          {
                                              if (correct)
                                              {
                                                  return true;
                                              }
                                              else
                                                  throw new Exception();
                                          });

                mock.Mock<ILogInService>().Setup(m => m.CreateNewPass(It.IsAny<string>(), It.IsAny<string>()))
                                          .Callback(() => 
                                          {

                                              if (correct)
                                              {
                                                  this.pass = "1234";
                                              }
                                              else
                                                  throw new Exception();
                                          });



                _ilogService = mock.Create<ILogInService>();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Mov4e.Service.LogInService;
using Mov4e;
using Mov4e.Exceptions;

namespace Mov4eTests.ServiceTests.LoginServiceTests
{
    [TestFixture]
    class TestsLoginService
    {
        [Test]
        public void CorrectLogInThrowsException()
        {
            DummyMockedLoginRepository _dummyMockedLoginRepository = new DummyMockedLoginRepository();
            ILogInService _logInService = new LogInService(_dummyMockedLoginRepository._logInRepository);
            _logInService.SaveDataFromView("Wolf4", "123");
            Assert.Throws<LogInException>(() => _logInService.CorrectLogin());
        }
        [Test]
        public void SaveDataFromViewisSavingDataInModel()
        {
            LogInService _logInService= new LogInService();
            _logInService.SaveDataFromView("Wolf", "1234");
            Assert.AreEqual(_logInService.GetUser().userName, "Wolf");
            Assert.AreEqual(_logInService.GetUser().password, "1234");
        }

        [Test]
        public void GetPasswordFromDBIsGettingPassword()
        {
            DummyMockedLoginRepository _dummyMockedLoginRepository = new DummyMockedLoginRepository();
            ILogInService _logInService = new LogInService(_dummyMockedLoginRepository._logInRepository);
            _logInService.SaveDataFromView("Wolf","1234");
            Assert.AreEqual(_logInService.GetIDLoggedUser(),1);
        }
        [Test]
        public void CorrectLogInReturnsTrue()
        {
            DummyMockedLoginRepository _dummyMockedLoginRepository = new DummyMockedLoginRepository();
            ILogInService _logInService = new LogInService(_dummyMockedLoginRepository._logInRepository);
            _logInService.SaveDataFromView("Wolf4", "1234");
            Assert.IsTrue(_logInService.CorrectLogin());
        }

        [Test]
        public void GePositionReturnsPosition()
        {
            DummyMockedLoginRepository _dummyMockedLoginRepository = new DummyMockedLoginRepository();
            ILogInService _logInService = new LogInService(_dummyMockedLoginRepository._logInRepository);
            Assert.AreEqual("Admin", _logInService.GetPosition());
            
        }

        [Test]
        public void CreateNewPassCreates()
        {
            DummyMockedLoginRepository _dummyMockedLoginRepository = new DummyMockedLoginRepository();
            ILogInService _logInService = new LogInService(_dummyMockedLoginRepository._logInRepository);
           _logInService.CreateNewPass("Wolf","lucho22@abv.bg");

            Assert.AreNotEqual("1234",_dummyMockedLoginRepository._logInRepository.GetPasswordForUser("Wolf"));
        }

        [Test]
        public void CreateNewPassThrowsException()
        {
            DummyMockedLoginRepository _dummyMockedLoginRepository = new DummyMockedLoginRepository();
            ILogInService _logInService = new LogInService(_dummyMockedLoginRepository._logInRepository);

            Assert.Throws<LogInException>(() => _logInService.CreateNewPass("Wolf", "lucho22v.bg"));          

        }

    }
}

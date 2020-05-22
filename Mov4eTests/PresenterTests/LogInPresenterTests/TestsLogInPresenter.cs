using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Mov4e;
using Mov4e.Presenter.LogInPresenter;
using NUnit.Framework;


namespace Mov4eTests.PresenterTests.LogInPresenterTests
{
    [TestFixture]
    class TestsLogInPresenter
    {
        [Test]
        public void LogUserLogsAndStay()
        {
            LogInServiceMockedDummy logServiceDummy = new LogInServiceMockedDummy();
            logServiceDummy.correct = true;
            ILogInPresenter _logInresenter = new LogInPresenter(logServiceDummy._ilogService,true);
            _logInresenter.LogUser();
            Assert.AreEqual(Mov4e.Properties.Settings.Default.id, 1);
            Assert.AreEqual(Mov4e.Properties.Settings.Default.userPosition,"Admin");

            Mov4e.Properties.Settings.Default.id = 0;
            Mov4e.Properties.Settings.Default.userPosition = string.Empty;
            Mov4e.Properties.Settings.Default.Logged = false;
            Mov4e.Properties.Settings.Default.LoggedForOneTime = false;
            Mov4e.Properties.Settings.Default.Save();
        }

        [Test]
        public void LogUserLogsAndDontStay()
        {
            LogInServiceMockedDummy logServiceDummy = new LogInServiceMockedDummy();
            logServiceDummy.correct = true;
            ILogInPresenter _logInresenter = new LogInPresenter(logServiceDummy._ilogService,false);
            _logInresenter.LogUser();
            Assert.AreEqual(Mov4e.Properties.Settings.Default.id, 1);
            Assert.AreEqual(Mov4e.Properties.Settings.Default.userPosition, "Admin");

            Mov4e.Properties.Settings.Default.id = 0;
            Mov4e.Properties.Settings.Default.userPosition = string.Empty;
            Mov4e.Properties.Settings.Default.Logged = false;
            Mov4e.Properties.Settings.Default.LoggedForOneTime = false;
            Mov4e.Properties.Settings.Default.Save();
        }

        [Test]
        public void LogUserReturnsException()
        {
            
            LogInServiceMockedDummy logServiceDummy = new LogInServiceMockedDummy();
            logServiceDummy.correct = false;
            ILogInPresenter _logInresenter = new LogInPresenter(logServiceDummy._ilogService, true);
            _logInresenter.LogUser();
            Assert.AreEqual(string.Empty, Mov4e.Properties.Settings.Default.userPosition);

            Mov4e.Properties.Settings.Default.id = 0;
            Mov4e.Properties.Settings.Default.userPosition = null;
            Mov4e.Properties.Settings.Default.Logged = false;
            Mov4e.Properties.Settings.Default.LoggedForOneTime = false;
            Mov4e.Properties.Settings.Default.Save();
        }


        [Test]
        public void ResetPassResets()
        {

            LogInServiceMockedDummy logServiceDummy = new LogInServiceMockedDummy();
            ILogInPresenter _logInresenter = new LogInPresenter(logServiceDummy._ilogService, true);

            _logInresenter.ResetPass("Wolf", "asd");

            Assert.AreEqual("1234", logServiceDummy.pass);
        }

        [Test]
        public void ResetPassThrowsException()
        {

            LogInServiceMockedDummy logServiceDummy = new LogInServiceMockedDummy();
            ILogInPresenter _logInresenter = new LogInPresenter(logServiceDummy._ilogService, true);
            logServiceDummy.correct = false;

            Assert.Throws<Exception>(() => _logInresenter.ResetPass("Wolf", "asd"));
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Mov4e.View.RegisterView;
using Mov4e.Presenter.RegisterPresenter;

namespace Mov4eTests.PresenterTests.RegisterPresenterTests
{
    [TestFixture]
    class TestsRegisterPresenter
    {
        [Test]
        public void RegisterUserRegisters()
        {
            MockedDummyRegisterService _mockedDummy = new MockedDummyRegisterService();
            _mockedDummy.error = false;
            IRegister _regView = new mov4eRegistration(new Mov4e.View.LogInView.mov4eLogin())
            {
                Age = 10,
                UserName = "WolF",
                FirstName = "Lucher",
                LastName = "Nikolow",
                Password = "asdasd",
                Email = "sd@ds.com",
                Gender = "M"               
            };
            RegisterPresenter _registerPresenter = new RegisterPresenter(_regView,_mockedDummy._registerService);
            _registerPresenter.RegisterUser();

            Assert.AreEqual(10, _mockedDummy._userinfo.age);
            Assert.AreEqual("Lucher", _mockedDummy._userinfo.firstName);
            Assert.AreEqual("Nikolow", _mockedDummy._userinfo.lastName);
            Assert.AreEqual("sd@ds.com", _mockedDummy._userinfo.email);
            Assert.AreEqual("M", _mockedDummy._userinfo.gender);
            Assert.AreEqual("asdasd", _mockedDummy._user.password);
            Assert.AreEqual("WolF", _mockedDummy._user.userName);
        }

        [Test]
        public void RegisterUserThrowsException()
        {
            MockedDummyRegisterService _mockedDummy = new MockedDummyRegisterService();
            IRegister _regView = new mov4eRegistration(new Mov4e.View.LogInView.mov4eLogin())
            {
                Age = 10,
                UserName = "WolF",
                FirstName = "Lucher",
                LastName = "Nikolow",
                Password = "asdasd",
                Email = "sd@ds.com",
                Gender = "M"
            };
            RegisterPresenter _registerPresenter = new RegisterPresenter(_regView, _mockedDummy._registerService);
            Assert.AreEqual(false, _registerPresenter.RegisterUser());
        }
    }
}

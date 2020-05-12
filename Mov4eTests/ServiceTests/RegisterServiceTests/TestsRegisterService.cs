using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Mov4e.Service.RegisterService;
using Mov4e.Exceptions;

namespace Mov4eTests.ServiceTests.RegisterServiceTests
{
    [TestFixture]
    class TestsRegisterService
    {
        [Test]
        public void SaveUserSavesUser()
        {
            MockedDummyRegisterRepository mockedDummy = new MockedDummyRegisterRepository();
            IRegisterService testsRegister = new RegisterService(mockedDummy._registerRepository);
            Assert.DoesNotThrow(() => testsRegister.SaveUser("ZakMaster", "@12234Aasdsad!"));
        }

        [Test]
        public void SaveUserThrowsExceptionBecauseOfTheUserName()
        {
            MockedDummyRegisterRepository mockedDummy = new MockedDummyRegisterRepository();
            IRegisterService testsRegister = new RegisterService(mockedDummy._registerRepository);
            Assert.Throws<IncorrectUserDataException>(() => testsRegister.SaveUser("Zak", "@12234Aasdsad!"));
        }

        [Test]
        public void SaveUserThrowsExceptionBecauseOfThePassword()
        {
            MockedDummyRegisterRepository mockedDummy = new MockedDummyRegisterRepository();
            IRegisterService testsRegister = new RegisterService(mockedDummy._registerRepository);
            Assert.Throws<IncorrectUserDataException>(() => testsRegister.SaveUser("ZakMaster", "@1223!"));
        }

        [Test]
        public void SaveUserInfoSaveingOk()
        {
            MockedDummyRegisterRepository mockedDummy = new MockedDummyRegisterRepository();
            IRegisterService testsRegister = new RegisterService(mockedDummy._registerRepository);
            Assert.DoesNotThrow(() => testsRegister.SaveUserInfo("Pesho", "Nikolow", "Peda@abv.bg", "M", 15));
        }

        [Test]
        public void SaveUserInfoThrowsExceptionBecauseOfTheFirstNameOrLastName()
        {
            MockedDummyRegisterRepository mockedDummy = new MockedDummyRegisterRepository();
            IRegisterService testsRegister = new RegisterService(mockedDummy._registerRepository);
            Assert.Throws<IncorrectUserDataException>(() => testsRegister.SaveUserInfo("1", "3", "Peda@abv.bg", "M", 15));
        }

        [Test]
        public void SaveUserInfoThrowsExceptionBecauseOfTheEmail()
        {
            MockedDummyRegisterRepository mockedDummy = new MockedDummyRegisterRepository();
            IRegisterService testsRegister = new RegisterService(mockedDummy._registerRepository);
            Assert.Throws<IncorrectUserDataException>(() => testsRegister.SaveUserInfo("Pesho", "Nikolow", "Pedaabv.bg", "M", 15));
        }

        [Test]
        public void SaveUserInfoThrowsExceptionBecauseOfTheGender()
        {
            MockedDummyRegisterRepository mockedDummy = new MockedDummyRegisterRepository();
            IRegisterService testsRegister = new RegisterService(mockedDummy._registerRepository);
            Assert.Throws<IncorrectUserDataException>(() => testsRegister.SaveUserInfo("Pesho", "Nikolow", "Peda@abv.bg", "Mad", 15));
        }

        [Test]
        public void SaveUserInfoThrowsExceptionBecauseOfTheAge()
        {
            MockedDummyRegisterRepository mockedDummy = new MockedDummyRegisterRepository();
            IRegisterService testsRegister = new RegisterService(mockedDummy._registerRepository);
            Assert.Throws<IncorrectUserDataException>(() => testsRegister.SaveUserInfo("Pesho", "Nikolow", "Peda@abv.bg", "M", -9));
        }

        [Test]
        public void SaveDataInDBIsOK()
        {
            MockedDummyRegisterRepository mockedDummy = new MockedDummyRegisterRepository();
            IRegisterService testsRegister = new RegisterService(mockedDummy._registerRepository);
            testsRegister.SaveUser("ZakMaster", "@12234Aasdsad!");
            testsRegister.SaveUserInfo("Pesho", "Nikolow", "testprojectss31@gmail.com", "M", 9);

            testsRegister.SaveDataInDB();

            Assert.AreEqual("ZakMaster", mockedDummy._user.userName);
            Assert.AreEqual("Pesho", mockedDummy._userinfo.firstName);
            Assert.AreEqual("Nikolow", mockedDummy._userinfo.lastName);
            Assert.AreEqual("testprojectss31@gmail.com", mockedDummy._userinfo.email);
            Assert.AreEqual("M", mockedDummy._userinfo.gender);
            Assert.AreEqual(9, mockedDummy._userinfo.age);
        }

    }
}

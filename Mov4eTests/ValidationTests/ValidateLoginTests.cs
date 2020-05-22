using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Mov4e.Validation;
using Mov4e.Exceptions;

namespace Mov4eTests.ValidationTests
{
    [TestFixture]
    class ValidateLoginTests
    {
        [Test]
        public void isLoginInformatinOkThrowsException()
        {
            Assert.Throws<LogInException>(() => ValidateLogIn.isLoginInformatinOk("123", "0NFrL36PKuFDzcJhJWmre2RlrOxQ2N6zqevWe8mIdiXx4ds+"));
        }

        [Test]
        public void UserExistsThrowsException()
        {
            Assert.Throws<LogInException>(() => ValidateLogIn.userExists(false));
        }

        [Test]
        public void compareEmailsThrowsException()
        {
            Assert.Throws<LogInException>(() => ValidateLogIn.compareEmails("1234","123"));
        }
    }
}

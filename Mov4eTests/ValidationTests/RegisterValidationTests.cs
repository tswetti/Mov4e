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
    class RegisterValidationTests
    {
        List<string> usernames = new List<string> { "Pesho", "Niki" };
        List<string> emails = new List<string> { "pg@abv.bg", "z@gmail.com" };

        [Test]
        public void isUserNameTakenThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateRegister.isUserNameTaken(usernames, "Pesho"));

        }

        [Test]
        public void isUserValidThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateRegister.isUserNameValid("Pesho!"));
        }

        [Test]
        public void isPasswordisPasswordCorrectThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateRegister.isPasswordCorrect("1234"));
        }

        [Test]
        public void areFirstAndLastNameValidThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateRegister.areFirstAndLastNameValid("1234","98"));
        }

        [Test]
        public void isEMailCorrectThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateRegister.isEMailCorrect("1234"));
        }

        [Test]
        public void isEMailCorrectMailIsCorrect()
        {
            Assert.DoesNotThrow(()=> ValidateRegister.isEMailCorrect("luchO0@abv.bg"));
        }

        [Test]
        public void isEMailTakenThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateRegister.isEMailTaken(emails,"z@gmail.com"));
        }

        [Test]
        public void isGenderValidThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateRegister.isGenderValid("zzzz"));
        }

        [Test]
        public void isAgeValidThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateRegister.isAgeValid(-1));
        }
    }
}

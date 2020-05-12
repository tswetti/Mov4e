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
    class ProfileScreenValidationTests
    {
        List<string> usernames = new List<string> { "Pesho", "Niki" };
        List<string> emails = new List<string> { "pg@abv.bg", "z@gmail.com" };

        [Test]
        public void isUserNameTakenThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateProfile.isUserNameTaken(usernames, "Pesho"));

        }

        [Test]
        public void isUserValidThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateProfile.isUserNameValid("Pesho!"));
        }

        [Test]
        public void isPasswordisPasswordCorrectThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateProfile.isPasswordCorrect("1234"));
        }


        [Test]
        public void isEMailCorrectThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateProfile.isEMailCorrect("1234"));
        }

        [Test]
        public void isFirstNameCorrectThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateProfile.isFirstNameCorrect("asd1"));
        }

        [Test]
        public void isLastNameCorrectThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateProfile.isLastNameCorrect("asd1"));
        }

        [Test]
        public void isProfilePictureOKThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateProfile.isProfilePictureOK(new byte[0]));
        }

        [Test]
        public void isMovieSelectedThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateProfile.isMovieSelected(0));
        }

        [Test]
        public void arePasswordsSameThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateProfile.arePasswordsSame("S4i4VgIP4Wg0Gn19QAEeo2jSgF6Aj2NQfiJN+KwcKGFcW7zj", "123"));
        } 

        [Test]
        public void isEMailCorrectMailIsCorrect()
        {
            Assert.DoesNotThrow(() => ValidateProfile.isEMailCorrect("luchO0@abv.bg"));
        }

        [Test]
        public void isEMailTakenThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateProfile.isEMailTaken(emails, "z@gmail.com"));
        }

        [Test]
        public void isGenderValidThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateProfile.isGenderValid("zzzz"));
        }

        [Test]
        public void isAgeValidThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateProfile.isAgeValid(-1));
        }

        [Test]
        public void areNewPassAndRepeatedSameThrowsException()
        {
            Assert.Throws<IncorrectUserDataException>(() => ValidateProfile.areNewPassAndRepeatedSame("131","3232231"));
        }


    }
}

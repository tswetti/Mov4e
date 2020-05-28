using Mov4e.Exceptions;
using Mov4e.Validation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4eTests.ValidationTests
{
    [TestFixture]
    public class MovieValidationTests
    {
        [Test]
        public void CorrectValidateTitleIsTrue()
        {
            Assert.IsTrue(MovieValidation.ValidateTitle("Titanic"));
        }

        [Test]
        public void CorrectValidateGenreIsTrue()
        {
            Assert.IsTrue(MovieValidation.ValidateGenre(6));
        }

        [Test]
        public void CorrectValidatePGIsTrue()
        {
            Assert.IsTrue(MovieValidation.ValidatePG(18));
        }

        [Test]
        public void CorrectValidateDateIsTrue()
        {
            Assert.IsTrue(MovieValidation.ValidateDate(DateTime.Now));
        }

        [Test]
        public void CorrectValidateSummaryIsTrue()
        {
            Assert.IsTrue(MovieValidation.ValidateSummary("This is the description of the Titanic movie..."));
        }

        [Test]
        public void CorrectValidateWrapperIsTrue()
        {
            Assert.IsTrue(MovieValidation.ValidateWrapper(new byte[180]));
        }

        [Test]
        public void CorrectValidateDurationIsTrue()
        {
            Assert.IsTrue(MovieValidation.ValidateDuration(240));
        }

        [Test]
        public void CorrectValidateNewMovieThrowsAnException1()
        {
            Assert.Throws<InvalidFieldInputException>(() => MovieValidation.ValidateNewMovie(null, 3, 14, DateTime.Today, "summary", new byte[100], 135));
        }

        [Test]
        public void CorrectValidateNewMovieThrowsAnException2()
        {
            Assert.Throws<InvalidFieldInputException>(() => MovieValidation.ValidateNewMovie("Movie", -10, 14, DateTime.Today, "summary", new byte[100], 135));
        }

        [Test]
        public void CorrectValidateNewMovieThrowsAnException3()
        {
            Assert.Throws<InvalidFieldInputException>(() => MovieValidation.ValidateNewMovie("Movie", 3, -1, DateTime.Today, "summary", new byte[100], 135));
        }

        [Test]
        public void CorrectValidateNewMovieThrowsAnException4()
        {
            Assert.Throws<InvalidFieldInputException>(() => MovieValidation.ValidateNewMovie("Movie", 3, 14, null, "summary", new byte[100], 135));
        }

        [Test]
        public void CorrectValidateNewMovieThrowsAnException5()
        {
            Assert.Throws<InvalidFieldInputException>(() => MovieValidation.ValidateNewMovie("Movie", 3, 14, DateTime.Today, "", new byte[100], 135));
        }

        [Test]
        public void CorrectValidateNewMovieThrowsAnException6()
        {
            Assert.Throws<InvalidFieldInputException>(() => MovieValidation.ValidateNewMovie("Movie", 3, 14, DateTime.Today, "summary", null, 135));
        }

        [Test]
        public void CorrectValidateNewMovieThrowsAnException7()
        {
            Assert.Throws<InvalidFieldInputException>(() => MovieValidation.ValidateNewMovie("Movie", 3, 14, DateTime.Today, "summary", new byte[100], -15));
        }

        [Test]
        public void CorrectValidateMovieUpdateThrowsAnException1()
        {
            Assert.Throws<InvalidFieldInputException>(() => MovieValidation.ValidateMovieUpdate(-3, "Movie", 3, 14, DateTime.Today, "summary", new byte[100], 135));
        }

        [Test]
        public void CorrectValidateMovieUpdateThrowsAnException2()
        {
            Assert.Throws<InvalidFieldInputException>(() => MovieValidation.ValidateMovieUpdate(1, null, 3, 14, DateTime.Today, "summary", new byte[100], 135));
        }

        [Test]
        public void CorrectValidateMovieUpdateThrowsAnException3()
        {
            Assert.Throws<InvalidFieldInputException>(() => MovieValidation.ValidateMovieUpdate(1, "Movie", 0, 14, DateTime.Today, "summary", new byte[100], 135));
        }

        [Test]
        public void CorrectValidateMovieUpdateThrowsAnException4()
        {
            Assert.Throws<InvalidFieldInputException>(() => MovieValidation.ValidateMovieUpdate(1, "Movie", 3, -14, DateTime.Today, "summary", new byte[100], 135));
        }

        [Test]
        public void CorrectValidateMovieUpdateThrowsAnException5()
        {
            Assert.Throws<InvalidFieldInputException>(() => MovieValidation.ValidateMovieUpdate(1, "Movie", 3, 14, null, "summary", new byte[100], 135));
        }

        [Test]
        public void CorrectValidateMovieUpdateThrowsAnException6()
        {
            Assert.Throws<InvalidFieldInputException>(() => MovieValidation.ValidateMovieUpdate(1, "Movie", 3, 14, DateTime.Today, "", new byte[100], 135));
        }

        [Test]
        public void CorrectValidateMovieUpdateThrowsAnException7()
        {
            Assert.Throws<InvalidFieldInputException>(() => MovieValidation.ValidateMovieUpdate(1, "Movie", 3, 14, DateTime.Today, "summary", null, 135));
        }

        [Test]
        public void CorrectValidateMovieUpdateThrowsAnException8()
        {
            Assert.Throws<InvalidFieldInputException>(() => MovieValidation.ValidateMovieUpdate(1, "Movie", 3, 14, DateTime.Today, "summary", new byte[100], -15));
        }
    }
}

using Mov4e.Exceptions;
using Mov4e.Presenter.AllMoviesPresenter;
using Mov4e.Validation;
using Mov4eTests.PresenterTests.AllMoviesPresenterTests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4eTests.ValidationTests
{
    [TestFixture]
    public class FilteringValidationTests
    {
        [Test]
        public void CorrectValidateFilterMovieThrowsAnException()
        {
            Assert.Throws<InvalidFilteringParamsException>(() => FilteringValidation.ValidateFilterMovies(0, 2, 12));
        }

        [Test]
        public void CorrectValidateFilterMovieThrowsAnException1()
        {
            Assert.Throws<InvalidFilteringParamsException>(() => FilteringValidation.ValidateFilterMovies(6, -1, 12));
        }

        [Test]
        public void CorrectValidateFilterMovieThrowsAnException2()
        {
            Assert.Throws<InvalidFilteringParamsException>(() => FilteringValidation.ValidateFilterMovies(6, 2, -12));
        }

        [Test]
        public void CorrectValidateFilterMoviesByGenreAndDurationThrowsAnException1()
        {
            Assert.Throws<InvalidFilteringParamsException>(() => FilteringValidation.ValidateFilterMoviesByGenreAndDuration(0, 2));
        }

        [Test]
        public void CorrectValidateFilterMoviesByGenreAndDurationThrowsAnException2()
        {
            Assert.Throws<InvalidFilteringParamsException>(() => FilteringValidation.ValidateFilterMoviesByGenreAndDuration(6, -10));
        }

        [Test]
        public void CorrectValidateFilterMoviesByGenreAndPGThrowsAnException1()
        {
            Assert.Throws<InvalidFilteringParamsException>(() => FilteringValidation.ValidateFilterMoviesByGenreAndPG(0, 12));
        }

        [Test]
        public void CorrectValidateFilterMoviesByGenreAndPGThrowsAnException2()
        {
            Assert.Throws<InvalidFilteringParamsException>(() => FilteringValidation.ValidateFilterMoviesByGenreAndPG(6, -1));
        }

        [Test]
        public void CorrectValidateFilterMoviesByDurationAndPGThrowsAnException1()
        {
            Assert.Throws<InvalidFilteringParamsException>(() => FilteringValidation.ValidateFilterMoviesByDurationAndPG(-1, 12));
        }

        [Test]
        public void CorrectValidateFilterMoviesByDurationAndPGThrowsAnException2()
        {
            Assert.Throws<InvalidFilteringParamsException>(() => FilteringValidation.ValidateFilterMoviesByDurationAndPG(60, -1));
        }

        [Test]
        public void CorrectValidateFilterMoviesByGenreThrowsAnException()
        {
            Assert.Throws<InvalidFilteringParamsException>(() => FilteringValidation.ValidateFilterMoviesByGenre(0));
        }

        [Test]
        public void CorrectValidateFilterMoviesByDurationThrowsAnException()
        {
            Assert.Throws<InvalidFilteringParamsException>(() => FilteringValidation.ValidateFilterMoviesByDuration(-1));
        }

        [Test]
        public void CorrectValidateFilterMoviesByPGThrowsAnException()
        {
            Assert.Throws<InvalidFilteringParamsException>(() => FilteringValidation.ValidateFilterMoviesByPG(-1));
        }
    }
}

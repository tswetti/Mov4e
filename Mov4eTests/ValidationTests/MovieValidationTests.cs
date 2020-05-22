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
    }
}

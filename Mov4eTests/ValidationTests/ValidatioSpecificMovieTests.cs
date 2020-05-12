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
    class ValidatioSpecificMovieTests
    {
        List<int> comments = new List<int>();

        [Test]
        public void isCommentOKThrowsException()
        {
            Assert.Throws<SpecificMovieException>(() => ValidateSpecificMovie.isCommentOK(" "));      
        }

        [Test]
        public void isRateOkThrowsException()
        {
            Assert.Throws<SpecificMovieException>(() => ValidateSpecificMovie.isRateOk(-1));
        }

        [Test]
        public void isThereMovieThrowsException()
        {
            Assert.Throws<SpecificMovieException>(() => ValidateSpecificMovie.isThereMovie(-1));
        }

        [Test]
        public void isThereAnUserThrowsException()
        {
            Assert.Throws<SpecificMovieException>(() => ValidateSpecificMovie.isThereAnUser(-1));
        }

        [Test]
        public void isThereAnythingToRemoveOrAddFromWatchListThrowsException()
        {
            Assert.Throws<SpecificMovieException>(() => ValidateSpecificMovie.isThereAnythingToRemoveOrAddFromWatchList(-1));
        }

        [Test]
        public void isThereCommentToRemoveThrowsException()
        {
            Assert.Throws<SpecificMovieException>(() => ValidateSpecificMovie.isThereCommentToRemove(comments));
        }

        [Test]
        public void areThereCommentsInCounterThrowsException()
        {
            Assert.Throws<SpecificMovieException>(() => ValidateSpecificMovie.areThereCommentsInCounter(-1));
        }
    }
}

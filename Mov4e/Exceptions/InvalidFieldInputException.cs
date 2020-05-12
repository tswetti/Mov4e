using System;

namespace Mov4e.Exceptions
{
    /// <summary>
    /// The <c>InvalidFieldInputException</c> is used to show a message when the movie's field's input is incorrect.
    /// </summary>
    /// <inheritdoc cref="System.Exception"/>
    [Serializable]
    internal class InvalidFieldInputException:Exception
    {
        /// <summary>
        /// A simple constructor with an appropriate exception's message.
        /// </summary>
        public InvalidFieldInputException():base(string.Format("All fields should be filled with valid information!"))
        {

        }
    }
}
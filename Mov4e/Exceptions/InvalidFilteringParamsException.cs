using System;

namespace Mov4e.Exceptions
{
    /// <summary>
    /// The <c>InvalidFilteringParmsException</c> is used to show a message 
    /// when the filtering params have incorrect value!
    /// </summary>
    /// <inheritdoc cref="System.Exception"/>
    [Serializable]
    internal class InvalidFilteringParamsException:Exception
    {
        /// <summary>
        /// A simple constructor with an appropriate exception's message.
        /// </summary>
        public InvalidFilteringParamsException():base(string.Format("There is an error with the value " +
            "of the filtering params!"))
        {

        }
    }
}
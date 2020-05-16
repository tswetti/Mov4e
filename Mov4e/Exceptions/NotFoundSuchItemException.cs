using System;

namespace Mov4e.Exceptions
{
    /// <summary>
    /// The <c>NotFoundSuchItemException</c> is used to show a message when the id of a certain item is invalid.
    /// </summary>
    /// <inheritdoc cref="System.Exception"/>
    [Serializable]
    public class NotFoundSuchItemException:Exception
    {
        /// <summary>
        /// A simple constructor with an appropriate exception's message.
        /// </summary>
        public NotFoundSuchItemException():base(string.Format("The id is incorrect." +
            " Please type valid id!"))
        {

        }
    }
}
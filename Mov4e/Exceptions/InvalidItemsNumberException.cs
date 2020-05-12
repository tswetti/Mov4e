using System;

namespace Mov4e.Exceptions
{
    /// <summary>
    /// The <c>InvalidItemsNumberException</c> is used to show a message when the number of the 
    /// movies in the database is less than zero.
    /// </summary>
    /// <inheritdoc cref="System.Exception"/>
    [Serializable]
    internal class InvalidItemsNumberException:Exception
    {
        /// <summary>
        /// A simple constructor with an appropriate exception's message.
        /// </summary>
        public InvalidItemsNumberException():base(string.Format("The number of the items cannot be less than zero!"))
        {

        }
    }
}
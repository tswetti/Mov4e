using System;

namespace Mov4e.Exceptions
{
    /// <summary>
    /// The <c>InvalidItemsSelectionException</c> is used to show a message 
    /// when the selected movie/s are in incorrect format.
    /// </summary>
    /// <inheritdoc cref="System.Exception"/>
    [Serializable]
    internal class InvalidItemsSelectionException:Exception
    {
        /// <summary>
        /// A simple constructor with an appropriate exception's message.
        /// </summary>
        public InvalidItemsSelectionException():base(string.Format("You don't select valid item from the listView!"))
        {

        }
    }
}
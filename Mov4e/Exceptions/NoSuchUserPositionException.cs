using System;

namespace Mov4e.Exceptions
{
    /// <summary>
    /// The <c>NoSuchUserPositionException</c> is used to show a message 
    /// when the user's position is different from 'admin' and 'normal'.
    /// </summary>
    /// <inheritdoc cref="System.Exception"/>
    [Serializable]
    internal class NoSuchUserPositionException:Exception
    {
        /// <summary>
        /// A simple constructor with an appropriate exception's message.
        /// </summary>
        public NoSuchUserPositionException():base(string.Format("There is no user on this position!"))
        {

        }
    }
}
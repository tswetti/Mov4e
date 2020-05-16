using System;

namespace Mov4e.Exceptions
{
    /// <summary>
    /// The <c>NoDataBaseTableRecordsException</c> is used to show a message 
    /// when id of a certain movie is less than zero.
    /// </summary>
    /// <inheritdoc cref="System.Exception"/>
    [Serializable]
    public class NoDataBaseTableRecordsException:Exception
    {
        /// <summary>
        /// A simple constructor with an appropriate exception's message.
        /// </summary>
        public NoDataBaseTableRecordsException():base(string.Format("The id is incorrect." +
            " Id should be bigger than zero!"))
        {

        }
    }
}
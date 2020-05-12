using System;

namespace Mov4e.Exceptions
{
    /// <summary>
    /// The <c>ImpossibleDataBaseRecordCreateException</c> class is used to show a message when there are
    /// some empty fields in a <c>NewMovieForm</c> class and the database cannot create a new movie about that. 
    /// </summary>
    /// <inheritdoc cref="System.Exception"/>
    [Serializable]
    internal class ImpossibleDataBaseRecordCreateException : Exception
    {
        /// <summary>
        /// A simple constructor with an appropriate exception's message.
        /// </summary>
        public ImpossibleDataBaseRecordCreateException():base(string.Format("Some of the fieldss are empty." +
            " Please, check wheter you fill all empty fields!"))
        {

        }
    }
}
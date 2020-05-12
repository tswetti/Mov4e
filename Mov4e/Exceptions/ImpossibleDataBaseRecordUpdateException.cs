using System;

namespace Mov4e.Exceptions
{
    /// <summary>
    /// The <c>ImpossibleDataBaseRecordUpdateException</c> is used to show a message when there are
    /// some empty fields in a <c>NewMovieForm</c> class and the database cannot update a certain movie about that. 
    /// </summary>
    /// <inheritdoc cref="System.Exception"/>
    [Serializable]
    internal class ImpossibleDataBaseRecordUpdateException : Exception
    {
        /// <summary>
        /// A simple constructor with an appropriate exception's message.
        /// </summary>
        public ImpossibleDataBaseRecordUpdateException():base(string.Format("Some of the properties are empty." +
            " Please check wheter you fill all empty field with valid information!"))
        {

        }
    }
}
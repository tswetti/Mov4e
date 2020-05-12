using System;
using System.IO;

namespace Mov4e.Logger
{
    /// <summary>
    /// The <c>Logger</c> class is a class which will write errors' logs in a file.  
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// A private static variable which contains the log file's path. 
        /// </summary>
        private static readonly string _textfilename = @"errors.txt";

        /// <summary>
        /// <c>WriteToLogFile(<typeparam name="error">string</typeparam><param name="error">)</c> is 
        /// a method which writes the sprung up errors in a file. 
        /// </summary>
        /// <param name="error">Used to save the error message.</param>
        /// <exception cref="System.Exception">The exception is thrown when it is impossible 
        /// to be created a file in the given path.</exception>
        public static void WriteToLogFile(string error)
        {
            string line = error + "\n";
            try
            {
                if (!File.Exists(_textfilename))
                {
                    File.Create(_textfilename).Dispose();
                }
            }
            catch (Exception e)
            {
                string er = e.ToString() + "\n";
                using (StreamWriter writer = new StreamWriter(_textfilename, true))
                {
                    writer.Write(DateTime.Now.ToString() + " In the application srang up an error, connected with " +
                        "finding the errors.txt file!" + "\n" + er);
                    writer.Flush();
                }
            }
            using (StreamWriter writer = new StreamWriter(_textfilename, true))
            {
                writer.Write(line);
                writer.Flush();
            }
        }
    }
}
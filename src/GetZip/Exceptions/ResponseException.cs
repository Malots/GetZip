using System;

namespace GetZip.Exceptions
{
    public class ResponseException : Exception
    {
        #region Constants
        private const string ERROR_MESSAGE = "No Response exception";
        #endregion

        public ResponseException() : base(ERROR_MESSAGE) { }

        public ResponseException(string message) : base(message) { }

        public ResponseException(string message, Exception innerException) : base(message, innerException) { }
    }
}

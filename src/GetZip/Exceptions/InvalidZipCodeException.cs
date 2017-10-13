using System;

namespace GetZip.Exceptions
{
    public class InvalidZipCodeException : ArgumentException
    {
        #region Constants
        private const string ERROR_MESSAGE = "Invalid Zip Code";
        #endregion

        public InvalidZipCodeException() : base(ERROR_MESSAGE) { }

        public InvalidZipCodeException(string message) : base(message) { }

        public InvalidZipCodeException(string message, Exception innerException) : base(message, innerException) { }
    }
}

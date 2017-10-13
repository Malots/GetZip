using System;

namespace GetZip.Exceptions
{
    public class InvalidKeyException : ArgumentException
    {
        #region Constants
        private const string ERROR_MESSAGE = "Invalid Key";
        #endregion

        public InvalidKeyException() : base(ERROR_MESSAGE) { }

        public InvalidKeyException(string message) : base(message) { }

        public InvalidKeyException(string message, Exception innerException) : base(message, innerException) { }
    }
}

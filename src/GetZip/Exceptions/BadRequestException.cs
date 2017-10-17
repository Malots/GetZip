using System;
using System.Net.Http;

namespace GetZip.Exceptions
{
    /// <summary>
    /// Custom HttpRequestException
    /// </summary>
    public class BadRequestException : HttpRequestException
    {
        #region Constants
        private const string ERROR_MESSAGE = "Bad Request Exception";
        #endregion

        #region Public methods
        /// <summary>
        /// Create custom HttpRequestException with custom message
        /// </summary>
        public BadRequestException() : base(ERROR_MESSAGE) { }

        /// <summary>
        /// Create custom HttpRequestException with your own message
        /// </summary>
        /// <param name="message">Custom message</param>
        public BadRequestException(string message) : base(message) { }

        /// <summary>
        /// Crate custom HttpRequestException with your own message and inner exception
        /// </summary>
        /// <param name="message">Custom message</param>
        /// <param name="innerException">Inner exception</param>
        public BadRequestException(string message, Exception innerException) : base(message, innerException) { }
        #endregion
    }
}

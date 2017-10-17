using GetZip.Helpers;
using GetZip.Interfaces;
using GetZip.ValueObject;
using System.Net;
using System.Threading.Tasks;

namespace GetZip.Services
{
    /// <summary>
    /// Asbtract base webservice
    /// </summary>
    public abstract class BaseSearch : ISearch
    {
        #region Properties
        /// <summary>
        /// Url Webservice
        /// </summary>
        protected abstract string URL { get; }
        /// <summary>
        /// Domain Webservice
        /// </summary>
        protected abstract string Domain { get; }
        #endregion

        #region Public async methods
        /// <summary>
        /// Check is webservice is online
        /// </summary>
        /// <returns>true or false</returns>
        public async Task<bool> IsOnline() => await ResponseHelper.ResultStatusCode(Domain) == HttpStatusCode.OK;

        /// <summary>
        /// Get zip code information
        /// </summary>
        /// <param name="zipCode">Number of zipcode</param>
        /// <returns>Address value object</returns>
        public abstract Task<Address> GetAddress(string zipCode);
        #endregion
    }
}

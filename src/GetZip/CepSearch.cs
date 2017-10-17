using GetZip.Emums;
using GetZip.Services;
using GetZip.ValueObject;
using System.Threading.Tasks;

namespace GetZip
{
    public class CepSearch
    {
        #region Properties Readonly
        private readonly BaseSearch cepSearch;
        private readonly string Key;
        #endregion


        #region Public methods
        /// <summary>
        /// Create a instance of CepSearch
        /// </summary>
        /// <param name="webservice">Type of webservice</param>
        public CepSearch(ServiceOption webservice) => cepSearch = GetInstance(webservice);

        /// <summary>
        /// Create a instance of CepSearch
        /// </summary>
        /// <param name="webservice">Type of webservice</param>
        /// <param name="key">Key to use in some webservices</param>
        public CepSearch(ServiceOption webservice, string key)
        {
            Key = key;
            cepSearch = GetInstance(webservice);
        }
        #endregion

        #region Public async methods
        /// <summary>
        /// Check if service is online
        /// </summary>
        /// <returns>true or false</returns>
        public async Task<bool> IsOnline() => await cepSearch.IsOnline();

        /// <summary>
        /// Get zip code information
        /// </summary>
        /// <param name="zipCode">Number os zip code</param>
        /// <returns>Valid or invalid address object</returns>
        public async Task<Address> GetAddress(string zipCode) => await cepSearch.GetAddress(zipCode);
        #endregion

        #region Private methods
        private BaseSearch GetInstance(ServiceOption webservice)
        {
            switch (webservice)
            {
                case ServiceOption.ViaCep: return new ViaCepSearch();
                case ServiceOption.CepLivre: return new CepLivreSearch(Key);
                case ServiceOption.RepublicaVirtual: return new RepublicaVirtualSearch();
                default: return new CorreiosCepSearch();
            }
        }
        #endregion
    }
}

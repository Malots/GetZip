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
        public CepSearch(ServiceOption webservice) => cepSearch = GetInstance(webservice);

        public CepSearch(ServiceOption webservice, string key)
        {
            Key = key;
            cepSearch = GetInstance(webservice);
        }

        public async Task<bool> IsOnline() => await cepSearch.IsOnline();

        public async Task<Address> GetAddress(string zipCode) => await cepSearch.GetAddress(zipCode);
        #endregion

        #region Private methods
        private BaseSearch GetInstance(ServiceOption webservice)
        {
            switch (webservice)
            {
                case ServiceOption.ViaCep: return new ViaCepSearch();
                case ServiceOption.CepLivre: return new CepLivreSearch(Key);
                default: return new CorreiosCepSearch();
            }
        }
        #endregion
    }
}

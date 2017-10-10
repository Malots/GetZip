using GetZip.Services;
using GetZip.ValueObject;
using System.Threading.Tasks;

namespace GetZip
{
    public class ServiceSearch
    {
        private readonly ServiceOption _webservice;
        private readonly ICepSearch cepSearch;
        public ServiceSearch(ServiceOption webservice)
        {
            _webservice = webservice;
            switch (_webservice)
            {
                case ServiceOption.ViaCep: cepSearch = new ViaCepSearch(); break;
                case ServiceOption.Correios: cepSearch = new CorreiosCepSearch(); break;
            }
        }

        public async Task<bool> IsOnline()
        {
            return await cepSearch.IsOnline();
        }

        public async Task<Address> GetByZip(string zipCode)
        {
            return await cepSearch.GetByZip(zipCode);
        }
    }
}

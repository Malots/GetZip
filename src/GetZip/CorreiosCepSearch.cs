using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetZip
{
    internal sealed class CorreiosCepSearch : ICepSearch
    {
        #region properties
        private const string URL = "https://apps.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente?wsdl";
        #endregion

        public async Task<bool> IsOnline()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(URL);
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch
            {
                return false;
            }
        }

        public ICollection<Address> GetByPlace(string uf, string city, string publicPlace, string publicPlaceType = null, string Neighborhood = null)
        {
            throw new NotImplementedException();
        }

        public ICollection<Address> GetByZip(string zipCode)
        {
            throw new NotImplementedException();
        }
    }
}

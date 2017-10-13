using GetZip.Enums;
using GetZip.Http;
using GetZip.ValueObject;
using HelperConversion;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GetZip.Services
{
    public class CepLivreSearch : ISearch
    {
        #region constants
        private const string URL = "http://ceplivre.com.br/consultar";
        private const string DOMAIN = "http://ceplivre.com.br";
        #endregion

        #region Properties
        private readonly string Key;
        #endregion

        public CepLivreSearch(string key)
        {
            Key = key;
        }

        public async Task<bool> IsOnline()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(DOMAIN);
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<Address> GetAddress(string zipCode)
        {
            try
            {
                var cep = String.Format("{0:00000-000}", zipCode);
                var data = $"{URL}/cep/{Key}/{cep}/xml";

                string result = await RequestSearch.GetResponse(URL, data, MethodOption.GET);
                if (result != null)
                {
                    var doc = XDocument.Parse(result);
                    var element = doc.Descendants("cep").FirstOrDefault();
                    var address = new Address(element.Element("cep").Value.GetOnlyNumbers(), element.Element("tp_logradouro").Value,
                        element.Element("tp_logradouro").Value+" "+element.Element("logradouro").Value, "", element.Element("bairro").Value,
                        element.Element("cidade").Value, element.Element("uf_sigla").Value, "");
                    return address;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}

using HelperConversion;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GetZip
{
    public class ViaCepSearch : ICepSearch
    {
        #region constants
        private const string URL = "https://viacep.com.br/ws";
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

        public async Task<Address> GetByZip(string zipCode)
        {
            try
            {
                var postData = $"{URL}{zipCode.GetOnlyNumbers()}/xml";

                string result = await ZipWebRequest.GetResponse(URL, postData);
                if (result != null)
                {
                    var doc = XDocument.Parse(result);
                    var element = doc.Descendants("enderecos").FirstOrDefault();
                    var address = new Address(element.Element("cep").Value, element.Element("logradouro").Value,
                        element.Element("logradouro").Value, element.Element("complemento").Value, element.Element("bairro").Value,
                        element.Element("localidade").Value, element.Element("uf").Value);
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

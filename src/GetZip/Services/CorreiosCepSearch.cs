using GetZip.Http;
using GetZip.ValueObject;
using HelperConversion;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GetZip.Services
{
    internal sealed class CorreiosCepSearch : ICepSearch
    {
        #region constants
        private const string URL = "https://apps.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente?wsdl";
        #endregion

        #region methods
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
                var postData = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>" +
                               "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
                               "xmlns:cli=\"http://cliente.bean.master.sigep.bsb.correios.com.br/\"> " +
                               " <soapenv:Header/>" +
                               " <soapenv:Body>" +
                               " <cli:consultaCEP>" +
                               " <cep>" + zipCode.GetOnlyNumbers() + "</cep>" +
                               " </cli:consultaCEP>" +
                               " </soapenv:Body>" +
                               " </soapenv:Envelope>";

                string result = await RequestSearch.GetResponse(URL,postData);
                if (result != null)
                {
                    var doc = XDocument.Parse(result);
                    var element = doc.Descendants("return").FirstOrDefault();
                    var address = new Address(element.Element("cep").Value, element.Element("end").Value,
                        element.Element("end").Value, element.Element("complemento").Value, element.Element("bairro").Value,
                        element.Element("cidade").Value, element.Element("uf").Value, "");
                    return address;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}

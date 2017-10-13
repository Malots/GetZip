using GetZip.Enums;
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
    internal sealed class CorreiosCepSearch : ISearch
    {
        #region constants
        private const string URL = "https://apps.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente?wsdl";
        private const string DOMAIN = "https://apps.correios.com.br";
        #endregion

        #region methods
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
                var data = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>" +
                               "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
                               "xmlns:cli=\"http://cliente.bean.master.sigep.bsb.correios.com.br/\"> " +
                               " <soapenv:Header/>" +
                               " <soapenv:Body>" +
                               " <cli:consultaCEP>" +
                               " <cep>" + zipCode.GetOnlyNumbers() + "</cep>" +
                               " </cli:consultaCEP>" +
                               " </soapenv:Body>" +
                               " </soapenv:Envelope>";

                string result = await RequestSearch.GetResponse(URL, data, MethodOption.POST);
                if (result != null)
                {
                    var doc = XDocument.Parse(result);
                    var element = doc.Descendants("return").FirstOrDefault();
                    var address = new Address(element.Element("cep").Value.GetOnlyNumbers(), element.Element("end").Value.Split(" ")[0].Trim(),
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

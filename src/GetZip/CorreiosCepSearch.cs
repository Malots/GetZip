using HelperConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GetZip
{
    internal sealed class CorreiosCepSearch : ICepSearch
    {
        #region properties
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

        public async Task<ICollection<Address>> GetByZip(string zipCode)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(URL);
                request.ProtocolVersion = HttpVersion.Version10;
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = ".NET Framework";
                request.Method = "POST";

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

                var byteArray = Encoding.UTF8.GetBytes(postData);
                var dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                string retorno;

                using (var stHtml = new System.IO.StreamReader(request.GetResponse().GetResponseStream(), Encoding.GetEncoding("ISO8859-1")))
                    retorno = stHtml.ReadToEnd();

                var doc = XDocument.Parse(retorno);
                var element = doc.Descendants("return").FirstOrDefault();
                var address = new Address(element.Element("cep").Value, element.Element("end").Value, 
                    element.Element("end").Value, element.Element("complemento").Value, element.Element("bairro").Value, 
                    element.Element("cidade").Value, element.Element("uf").Value);
                return new[] { address };
            }
            catch
            {
                return null;
            }
        }

        public ICollection<Address> GetByPlace(string uf, string city, string publicPlace, string publicPlaceType = null, string Neighborhood = null)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

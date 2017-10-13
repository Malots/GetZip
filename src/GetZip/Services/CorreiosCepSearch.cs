using GetZip.Enums;
using GetZip.Exceptions;
using GetZip.Http;
using GetZip.ValueObject;
using HelperConversion;
using SmartValidations.ValueObjects;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GetZip.Services
{
    internal sealed class CorreiosCepSearch : BaseSearch
    {
        #region Methods
        protected override string URL => "https://apps.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente?wsdl";

        protected override string Domain => "https://apps.correios.com.br";

        public override async Task<Address> GetAddress(string zipCode)
        {
            var address = new Address();
            var cep = new CEP(zipCode);
            if (cep.IsValid())
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

                try
                {
                    string result = await RequestSearch.GetResponse(URL, data, MethodOption.POST);
                    var doc = XDocument.Parse(result);
                    var element = doc.Descendants("return").FirstOrDefault();
                    address.CEP = element.Element("cep").Value.GetOnlyNumbers();
                    address.PublicPlaceType = element.Element("end").Value.Split(" ")[0].Trim();
                    address.PublicPlace = element.Element("end").Value;
                    address.Complement = element.Element("complemento").Value;
                    address.Neighborhood = element.Element("bairro").Value;
                    address.City = element.Element("cidade").Value;
                    address.UF = element.Element("uf").Value;
                    address.IBGE = "";
                }
                catch (ArgumentException ex)
                {
                    address.ErrorMessage = ex.Message;
                }
                catch (HttpRequestException ex)
                {
                    address.ErrorMessage = ex.Message;
                }
                catch (AggregateException ex)
                {
                    address.ErrorMessage = ex.Message;
                }
                catch (ResponseException ex)
                {
                    address.ErrorMessage = ex.Message;
                }
                catch (Exception ex)
                {
                    address.ErrorMessage = ex.Message;
                }
            }
            else
            {
                address.ErrorMessage = "Invalid Zip Code";
            }
            return address;
        }
        #endregion
    }
}

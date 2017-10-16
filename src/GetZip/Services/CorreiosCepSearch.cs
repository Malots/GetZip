using GetZip.Enums;
using GetZip.Helpers;
using GetZip.ValueObject;
using HelperConversion;
using System.Threading.Tasks;

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

            var element = await ResponseHelper.ResultRequest(URL, data, "return", MethodOption.POST);
            if (element.Name == "error")
            {
                address.ErrorMessage = element.Value;
            }
            else
            {
                address.CEP = element.Element("cep").Value.GetOnlyNumbers();
                address.PublicPlaceType = element.Element("end").Value.Split(" ")[0].Trim();
                address.PublicPlace = element.Element("end").Value;
                address.Complement = element.Element("complemento").Value;
                address.Neighborhood = element.Element("bairro").Value;
                address.City = element.Element("cidade").Value;
                address.UF = element.Element("uf").Value;
                address.IBGE = "";
            }
            return address;
        }
        #endregion
    }
}

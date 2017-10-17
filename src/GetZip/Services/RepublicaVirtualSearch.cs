using GetZip.Enums;
using GetZip.Helpers;
using GetZip.ValueObject;
using HelperConversion;
using System.Threading.Tasks;

namespace GetZip.Services
{
    /// <summary>
    /// RepublicaVirtual webservice
    /// </summary>
    internal sealed class RepublicaVirtualSearch : BaseSearch
    {
        #region Public override methods
        protected override string URL => "http://cep.republicavirtual.com.br/";

        protected override string Domain => "http://cep.republicavirtual.com.br/";

        public override async Task<Address> GetAddress(string zipCode)
        {
            var address = new Address();
            var data = $"{URL}web_cep.php?cep={zipCode.GetOnlyNumbers()}&formato=xml";

            var element = await ResponseHelper.ResultRequest(URL, data, "webservicecep", MethodOption.GET);
            if (element.Name == "error")
            {
                address.ErrorMessage = element.Value;
            }
            else
            {
                if (element.Element("resultado").Value == "0")
                {
                    address.ErrorMessage = element.Element("resultado_txt").Value;
                }
                else
                {
                    address.CEP = zipCode.GetOnlyNumbers();
                    address.PublicPlaceType = element.Element("tipo_logradouro").Value;
                    address.PublicPlace = element.Element("tipo_logradouro").Value + " " + element.Element("logradouro").Value;
                    address.Complement = "";
                    address.Neighborhood = element.Element("bairro").Value;
                    address.City = element.Element("cidade").Value;
                    address.UF = element.Element("uf").Value;
                    address.IBGE = "";
                }
            }
            return address;
        }
        #endregion
    }
}

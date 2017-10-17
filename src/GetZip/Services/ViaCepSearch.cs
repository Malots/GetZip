using GetZip.Enums;
using GetZip.Helpers;
using GetZip.ValueObject;
using HelperConversion;
using System.Threading.Tasks;

namespace GetZip.Services
{
    /// <summary>
    /// ViaCepSearch webservice
    /// </summary>
    internal sealed class ViaCepSearch : BaseSearch
    {
        #region Public override methods
        protected override string URL => "https://viacep.com.br/ws";

        protected override string Domain => "https://viacep.com.br";

        public override async Task<Address> GetAddress(string zipCode)
        {
            var address = new Address();
            var data = $"{URL}/{zipCode.GetOnlyNumbers()}/xml";

            var element = await ResponseHelper.ResultRequest(URL, data, "xmlcep", MethodOption.GET);
            if (element.Name == "error")
            {
                address.ErrorMessage = element.Value;
            }
            else
            {
                address.CEP = element.Element("cep").Value.GetOnlyNumbers();
                address.PublicPlaceType = element.Element("logradouro").Value.Split(" ")[0].Trim();
                address.PublicPlace = element.Element("logradouro").Value;
                address.Complement = element.Element("complemento").Value;
                address.Neighborhood = element.Element("bairro").Value;
                address.City = element.Element("localidade").Value;
                address.UF = element.Element("uf").Value;
                address.IBGE = "";
            }
            return address;
        }
        #endregion
    }
}

using GetZip.Enums;
using GetZip.Http;
using GetZip.ValueObject;
using HelperConversion;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GetZip.Services
{
    internal sealed class ViaCepSearch : BaseSearch
    {
        #region Methods
        protected override string URL => "https://viacep.com.br/ws";

        protected override string Domain => "https://viacep.com.br";

        public override async Task<Address> GetAddress(string zipCode)
        {
            try
            {
                var data = $"{URL}/{zipCode.GetOnlyNumbers()}/xml";

                string result = await RequestSearch.GetResponse(URL, data, MethodOption.GET);
                if (result != null)
                {
                    var doc = XDocument.Parse(result);
                    var element = doc.Descendants("xmlcep").FirstOrDefault();
                    var address = new Address
                    {
                        CEP = element.Element("cep").Value.GetOnlyNumbers(),
                        PublicPlaceType = element.Element("logradouro").Value.Split(" ")[0].Trim(),
                        PublicPlace = element.Element("logradouro").Value,
                        Complement = element.Element("complemento").Value,
                        Neighborhood = element.Element("bairro").Value,
                        City = element.Element("localidade").Value,
                        UF = element.Element("uf").Value,
                        IBGE = ""
                    };
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

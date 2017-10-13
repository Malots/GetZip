using GetZip.Enums;
using GetZip.Http;
using GetZip.ValueObject;
using HelperConversion;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GetZip.Services
{
    internal sealed class CepLivreSearch : BaseSearch
    {
        public CepLivreSearch(string key)
        {
            Key = key;
        }

        #region Properties
        private readonly string Key;
        #endregion

        #region Methods
        protected override string URL => "http://ceplivre.com.br/consultar";

        protected override string Domain => "http://ceplivre.com.br";

        public override async Task<Address> GetAddress(string zipCode)
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
                    var address = new Address
                    {
                        CEP = element.Element("cep").Value.GetOnlyNumbers(),
                        PublicPlaceType = element.Element("tp_logradouro").Value,
                        PublicPlace = element.Element("tp_logradouro").Value + " " + element.Element("logradouro").Value,
                        Complement = "",
                        Neighborhood = element.Element("bairro").Value,
                        City = element.Element("cidade").Value,
                        UF = element.Element("uf_sigla").Value,
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

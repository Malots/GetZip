using GetZip.Enums;
using GetZip.Helpers;
using GetZip.ValueObject;
using HelperConversion;
using System;
using System.Threading.Tasks;

namespace GetZip.Services
{
    /// <summary>
    /// Ceplivre webservice
    /// </summary>
    internal sealed class CepLivreSearch : BaseSearch
    {
        /// <summary>
        /// Create instance of Ceplivre with key
        /// </summary>
        /// <param name="key"></param>
        public CepLivreSearch(string key)
        {
            Key = key;
        }

        #region Properties
        /// <summary>
        /// Required Key 
        /// </summary>
        private readonly string Key;
        #endregion

        #region Public override methods
        protected override string URL => "http://ceplivre.com.br/consultar";

        protected override string Domain => "http://ceplivre.com.br";

        public override async Task<Address> GetAddress(string zipCode)
        {
            var address = new Address();
            var cep = String.Format("{0:00000-000}", zipCode);
            var data = $"{URL}/cep/{Key}/{cep}/xml";

            var element = await ResponseHelper.ResultRequest(URL, data, "cep", MethodOption.GET);
            if (element.Name == "error")
            {
                address.ErrorMessage = element.Value;
            }
            else
            {
                address.CEP = element.Element("cep").Value.GetOnlyNumbers();
                address.PublicPlaceType = element.Element("tp_logradouro").Value;
                address.PublicPlace = element.Element("tp_logradouro").Value + " " + element.Element("logradouro").Value;
                address.Complement = "";
                address.Neighborhood = element.Element("bairro").Value;
                address.City = element.Element("cidade").Value;
                address.UF = element.Element("uf_sigla").Value;
                address.IBGE = "";
            }
            return address;
        }
        #endregion
    }
}

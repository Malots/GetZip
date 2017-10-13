using GetZip.Emums;
using GetZip.ValueObject;
using HelperConversion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace GetZip.Test
{
    [TestClass]
    public class UsabilityTest
    {
        #region Correios
        [TestMethod]
        [TestCategory("Correios")]
        public async Task CheckWebServiceCorreiosStatus()
        {
            var getZip = new CepSearch(ServiceOption.Correios);
            Assert.IsTrue(await getZip.IsOnline());
        }

        [TestMethod]
        [TestCategory("Correios")]
        public async Task GiveValidZipCodeGetInformationUseCorreiosWebService()
        {
            string cep = "01002-020";
            var getZip = new CepSearch(ServiceOption.Correios);
            var addressSearch = (await getZip.GetAddress(cep));
            var address = new Address(cep.GetOnlyNumbers(), "Viaduto", "Viaduto do Chá","","Centro","São Paulo","SP","");
            Assert.AreEqual(addressSearch.CEP, address.CEP);
        }

        [TestMethod]
        [TestCategory("Correios")]
        public async Task GiveInvalidZipCodeGetInformationUseCorreiosWebService()
        {
            string cep = "01A02-B20";
            var getZip = new CepSearch(ServiceOption.Correios);
            var addressSearch = (await getZip.GetAddress(cep));
            Assert.IsTrue(addressSearch == null);
        }
        #endregion

        #region ViaCep
        [TestMethod]
        [TestCategory("ViaCep")]
        public async Task CheckWebServiceViaCepStatus()
        {
            var getZip = new CepSearch(ServiceOption.ViaCep);
            Assert.IsTrue(await getZip.IsOnline());
        }

        [TestMethod]
        [TestCategory("ViaCep")]
        public async Task GiveValidZipCodeGetInformationUseViaCepWebService()
        {
            string cep = "01002-020";
            var getZip = new CepSearch(ServiceOption.ViaCep);
            var addressSearch = (await getZip.GetAddress(cep));
            var address = new Address(cep.GetOnlyNumbers(), "Viaduto", "Viaduto do Chá", "", "Centro", "São Paulo", "SP", "");
            Assert.AreEqual(addressSearch.CEP, address.CEP);
        }

        [TestMethod]
        [TestCategory("ViaCep")]
        public async Task GiveInvalidZipCodeGetInformationUseViaCepWebService()
        {
            string cep = "01A02-B20";
            var getZip = new CepSearch(ServiceOption.ViaCep);
            var addressSearch = (await getZip.GetAddress(cep));
            Assert.IsTrue(addressSearch == null);
        }
        #endregion

        #region CepLivre
        [TestMethod]
        [TestCategory("CepLivre")]
        public async Task CheckWebServiceCepLivreStatus()
        {
            var getZip = new CepSearch(ServiceOption.CepLivre);
            Assert.IsTrue(await getZip.IsOnline());
        }

        [TestMethod]
        [TestCategory("CepLivre")]
        public async Task GiveValidZipCodeGetInformationUseCepLivreWebService()
        {
            string cep = "01002-020";
            var getZip = new CepSearch(ServiceOption.CepLivre, "5f2826fef3b80b2c57da7bc3330b4132");
            var addressSearch = (await getZip.GetAddress(cep));
            var address = new Address(cep.GetOnlyNumbers(), "Viaduto", "Viaduto do Chá", "", "Centro", "São Paulo", "SP", "");
            Assert.AreEqual(addressSearch.CEP, address.CEP);
        }

        [TestMethod]
        [TestCategory("CepLivre")]
        public async Task GiveInvalidZipCodeGetInformationUseCepLivreWebService()
        {
            string cep = "01A02-B20";
            var getZip = new CepSearch(ServiceOption.CepLivre, "5f2826fef3b80b2c57da7bc3330b4132");
            var addressSearch = (await getZip.GetAddress(cep));
            Assert.IsTrue(addressSearch == null);
        }
        #endregion
    }
}

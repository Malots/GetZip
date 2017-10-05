using HelperConversion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace GetZip.Test
{
    [TestClass]
    public class UsabilityTest
    {
        [TestMethod]
        [TestCategory("Correios")]
        public async Task CheckWebServiceCorreiosStatus()
        {
            Assert.IsTrue(await CepSearch.IsOnline(WebService.Correios));
        }

        [TestMethod]
        [TestCategory("Correios")]
        public async Task GiveValidZipCodeGetInformationUseCorreiosWebService()
        {
            string cep = "01002-020";
            var addressSearch = (await CepSearch.GetByZip(cep, WebService.Correios));
            var address = new Address(cep.GetOnlyNumbers(), "Viaduto do Chá", "Viaduto do Chá","","Centro","São Paulo","SP");
            Assert.AreEqual(addressSearch.CEP, address.CEP);
        }

        [TestMethod]
        [TestCategory("Correios")]
        public async Task GiveInvalidZipCodeGetInformationUseCorreiosWebService()
        {
            string cep = "01A02-B20";
            var addressSearch = (await CepSearch.GetByZip(cep, WebService.Correios));
            Assert.IsTrue(addressSearch == null);
        }

        [TestMethod]
        [TestCategory("ViaCep")]
        public async Task CheckWebServiceViaCepStatus()
        {
            Assert.IsTrue(await CepSearch.IsOnline(WebService.ViaCep));
        }

        [TestMethod]
        [TestCategory("ViaCep")]
        public async Task GiveValidZipCodeGetInformationUseViaCepWebService()
        {
            string cep = "01002-020";
            var addressSearch = (await CepSearch.GetByZip(cep, WebService.ViaCep));
            var address = new Address(cep.GetOnlyNumbers(), "Viaduto do Chá", "Viaduto do Chá", "", "Centro", "São Paulo", "SP");
            Assert.AreEqual(addressSearch.CEP, address.CEP);
        }
    }
}

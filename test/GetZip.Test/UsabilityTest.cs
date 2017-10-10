using GetZip.ValueObject;
using HelperConversion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var getZip = new ServiceSearch(ServiceOption.Correios);
            Assert.IsTrue(await getZip.IsOnline());
        }

        [TestMethod]
        [TestCategory("Correios")]
        public async Task GiveValidZipCodeGetInformationUseCorreiosWebService()
        {
            string cep = "01002-020";
            var getZip = new ServiceSearch(ServiceOption.Correios);
            var addressSearch = (await getZip.GetByZip(cep));
            var address = new Address(cep.GetOnlyNumbers(), "Viaduto do Chá", "Viaduto do Chá","","Centro","São Paulo","SP","");
            Assert.AreEqual(addressSearch.CEP, address.CEP);
        }

        [TestMethod]
        [TestCategory("Correios")]
        public async Task GiveInvalidZipCodeGetInformationUseCorreiosWebService()
        {
            string cep = "01A02-B20";
            var getZip = new ServiceSearch(ServiceOption.Correios);
            var addressSearch = (await getZip.GetByZip(cep));
            Assert.IsTrue(addressSearch == null);
        }

        [TestMethod]
        [TestCategory("ViaCep")]
        public async Task CheckWebServiceViaCepStatus()
        {
            var getZip = new ServiceSearch(ServiceOption.ViaCep);
            Assert.IsTrue(await getZip.IsOnline());
        }

        [TestMethod]
        [TestCategory("ViaCep")]
        public async Task GiveValidZipCodeGetInformationUseViaCepWebService()
        {
            string cep = "01002-020";
            var getZip = new ServiceSearch(ServiceOption.ViaCep);
            var addressSearch = (await getZip.GetByZip(cep));
            var address = new Address(cep.GetOnlyNumbers(), "Viaduto do Chá", "Viaduto do Chá", "", "Centro", "São Paulo", "SP", "");
            Assert.AreEqual(addressSearch.CEP, address.CEP);
        }
    }
}

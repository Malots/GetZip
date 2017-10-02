using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace GetZip.Test
{
    [TestClass]
    public class UsageTest
    {
        [TestMethod]
        [TestCategory("Correios")]
        public async Task CheckWebServiceStatus()
        {
            Assert.IsTrue(await CepSearch.IsOnline(WebService.Correios));
        }

        [TestMethod]
        [TestCategory("Correios")]
        public void GiveValidZipCodeGetInformationUseCorreiosWebService()
        {
            /*string cep = "01002-020";
            var addressList = CepSearch.GetByZip(cep, WebService.Correios);
            var address = new Address(cep,"Viaduto","Viaduto do Chá","","Centro","São Paulo","SP", "3550308","35");
            Assert.AreEqual(addressList, address);*/
        }
    }
}

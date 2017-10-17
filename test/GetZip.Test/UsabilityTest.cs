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
            var address = new Address
            {
                CEP = cep.GetOnlyNumbers(),
                PublicPlaceType = "Viaduto",
                PublicPlace = "Viaduto do Chá",
                Complement = "",
                Neighborhood = "Centro",
                City = "São Paulo",
                UF = "SP",
                IBGE = ""
            };
            Assert.IsTrue(addressSearch.IsValid());
            Assert.AreEqual(addressSearch.CEP, address.CEP);
        }

        [TestMethod]
        [TestCategory("Correios")]
        public async Task GiveInvalidZipCodeGetInformationUseCorreiosWebService()
        {
            string cep = "01A02-B20";
            var getZip = new CepSearch(ServiceOption.Correios);
            var addressSearch = (await getZip.GetAddress(cep));
            Assert.IsFalse(addressSearch.IsValid());
        }

        [TestMethod]
        [TestCategory("Correios")]
        public async Task GiveEmptyZipCodeGetInformationUseCorreiosWebService()
        {
            string cep = "";
            var getZip = new CepSearch(ServiceOption.Correios);
            var addressSearch = (await getZip.GetAddress(cep));
            Assert.IsFalse(addressSearch.IsValid());
        }

        [TestMethod]
        [TestCategory("Correios")]
        public async Task GiveNullZipCodeGetInformationUseCorreiosWebService()
        {
            string cep = null;
            var getZip = new CepSearch(ServiceOption.Correios);
            var addressSearch = (await getZip.GetAddress(cep));
            Assert.IsFalse(addressSearch.IsValid());
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
            var address = new Address
            {
                CEP = cep.GetOnlyNumbers(),
                PublicPlaceType = "Viaduto",
                PublicPlace = "Viaduto do Chá",
                Complement = "",
                Neighborhood = "Centro",
                City = "São Paulo",
                UF = "SP",
                IBGE = ""
            };
            Assert.AreEqual(addressSearch.CEP, address.CEP);
        }

        [TestMethod]
        [TestCategory("ViaCep")]
        public async Task GiveInvalidZipCodeGetInformationUseViaCepWebService()
        {
            string cep = "01A02-B20";
            var getZip = new CepSearch(ServiceOption.ViaCep);
            var addressSearch = (await getZip.GetAddress(cep));
            Assert.IsFalse(addressSearch.IsValid());
        }

        [TestMethod]
        [TestCategory("ViaCep")]
        public async Task GiveEmptyZipCodeGetInformationUseViaCepWebService()
        {
            string cep = "";
            var getZip = new CepSearch(ServiceOption.ViaCep);
            var addressSearch = (await getZip.GetAddress(cep));
            Assert.IsFalse(addressSearch.IsValid());
        }

        [TestMethod]
        [TestCategory("ViaCep")]
        public async Task GiveNullZipCodeGetInformationUseViaCepWebService()
        {
            string cep = null;
            var getZip = new CepSearch(ServiceOption.ViaCep);
            var addressSearch = (await getZip.GetAddress(cep));
            Assert.IsFalse(addressSearch.IsValid());
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
            var address = new Address
            {
                CEP = cep.GetOnlyNumbers(),
                PublicPlaceType = "Viaduto",
                PublicPlace = "Viaduto do Chá",
                Complement = "",
                Neighborhood = "Centro",
                City = "São Paulo",
                UF = "SP",
                IBGE = ""
            };
            Assert.AreEqual(addressSearch.CEP, address.CEP);
        }

        [TestMethod]
        [TestCategory("CepLivre")]
        public async Task GiveInvalidZipCodeGetInformationUseCepLivreWebService()
        {
            string cep = "01A02-B20";
            var getZip = new CepSearch(ServiceOption.CepLivre, "5f2826fef3b80b2c57da7bc3330b4132");
            var addressSearch = (await getZip.GetAddress(cep));
            Assert.IsFalse(addressSearch.IsValid());
        }

        [TestMethod]
        [TestCategory("CepLivre")]
        public async Task GiveValidZipCodeWithInvalidKeyGetInformationUseCepLivreWebService()
        {
            string cep = "01002-020";
            var getZip = new CepSearch(ServiceOption.CepLivre, "123456");
            var addressSearch = (await getZip.GetAddress(cep));
            Assert.IsFalse(addressSearch.IsValid());
        }

        [TestMethod]
        [TestCategory("CepLivre")]
        public async Task GiveValidZipCodeWithEmptyKeyGetInformationUseCepLivreWebService()
        {
            string cep = "01002-020";
            var getZip = new CepSearch(ServiceOption.CepLivre, "");
            var addressSearch = (await getZip.GetAddress(cep));
            Assert.IsFalse(addressSearch.IsValid());
        }

        [TestMethod]
        [TestCategory("CepLivre")]
        public async Task GiveValidZipCodeWithNullKeyGetInformationUseCepLivreWebService()
        {
            string cep = "01002-020";
            var getZip = new CepSearch(ServiceOption.CepLivre, null);
            var addressSearch = (await getZip.GetAddress(cep));
            Assert.IsFalse(addressSearch.IsValid());
        }

        [TestMethod]
        [TestCategory("CepLivre")]
        public async Task GiveEmptyZipCodeGetInformationUseCepLivreWebService()
        {
            string cep = "";
            var getZip = new CepSearch(ServiceOption.Correios);
            var addressSearch = (await getZip.GetAddress(cep));
            Assert.IsFalse(addressSearch.IsValid());
        }

        [TestMethod]
        [TestCategory("CepLivre")]
        public async Task GiveNullZipCodeGetInformationUseCepLivreWebService()
        {
            string cep = null;
            var getZip = new CepSearch(ServiceOption.Correios);
            var addressSearch = (await getZip.GetAddress(cep));
            Assert.IsFalse(addressSearch.IsValid());
        }
        #endregion

        #region Republica Virtual
        [TestMethod]
        [TestCategory("RepublicaVirtual")]
        public async Task CheckWebServiceRepublicaVirtualStatus()
        {
            var getZip = new CepSearch(ServiceOption.RepublicaVirtual);
            Assert.IsTrue(await getZip.IsOnline());
        }

        [TestMethod]
        [TestCategory("RepublicaVirtual")]
        public async Task GiveValidZipCodeGetInformationUseRepublicaVirtualWebService()
        {
            string cep = "01002-020";
            var getZip = new CepSearch(ServiceOption.RepublicaVirtual);
            var addressSearch = (await getZip.GetAddress(cep));
            var address = new Address
            {
                CEP = cep.GetOnlyNumbers(),
                PublicPlaceType = "Viaduto",
                PublicPlace = "Viaduto do Chá",
                Complement = "",
                Neighborhood = "Centro",
                City = "São Paulo",
                UF = "SP",
                IBGE = ""
            };
            Assert.AreEqual(addressSearch.CEP, address.CEP);
        }

        [TestMethod]
        [TestCategory("RepublicaVirtual")]
        public async Task GiveInvalidZipCodeGetInformationUseRepublicaVirtualWebService()
        {
            string cep = "01A02-B20";
            var getZip = new CepSearch(ServiceOption.RepublicaVirtual);
            var addressSearch = (await getZip.GetAddress(cep));
            Assert.IsFalse(addressSearch.IsValid());
        }

        [TestMethod]
        [TestCategory("RepublicaVirtual")]
        public async Task GiveEmptyZipCodeGetInformationUseRepublicaVirtualWebService()
        {
            string cep = "";
            var getZip = new CepSearch(ServiceOption.RepublicaVirtual);
            var addressSearch = (await getZip.GetAddress(cep));
            Assert.IsFalse(addressSearch.IsValid());
        }

        [TestMethod]
        [TestCategory("RepublicaVirtual")]
        public async Task GiveNullZipCodeGetInformationUseRepublicaVirtualWebService()
        {
            string cep = null;
            var getZip = new CepSearch(ServiceOption.RepublicaVirtual);
            var addressSearch = (await getZip.GetAddress(cep));
            Assert.IsFalse(addressSearch.IsValid());
        }
        #endregion
    }
}

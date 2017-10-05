using System.Threading.Tasks;

namespace GetZip
{
    public static class CepSearch
    {
        public static Task<bool> IsOnline(WebService webservice)
        {
            switch (webservice)
            {
                case WebService.ViaCep: return new ViaCepSearch().IsOnline();
                default: return new CorreiosCepSearch().IsOnline();
            }
        }

        public static Task<Address> GetByZip(string zipCode, WebService webservice)
        {
            switch (webservice)
            {
                case WebService.ViaCep: return new ViaCepSearch().GetByZip(zipCode);
                default: return new CorreiosCepSearch().GetByZip(zipCode);
            }
        }
    }
}

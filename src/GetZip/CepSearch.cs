using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetZip
{
    public static class CepSearch
    {
        public static Task<bool> IsOnline(WebService webservice)
        {
            switch (webservice)
            {
                default: return new CorreiosCepSearch().IsOnline();
            }
        }

        public static Task<ICollection<Address>> GetByZip(string zipCode, WebService webservice)
        {
            switch (webservice)
            {
                default: return new CorreiosCepSearch().GetByZip(zipCode);
            }
        }
    }
}

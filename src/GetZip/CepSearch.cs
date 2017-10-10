using GetZip.ValueObject;
using System.Threading.Tasks;

namespace GetZip
{
    public class CepSearch
    {
        private readonly ICepSearch _cepsearch;

        public CepSearch(ICepSearch cepsearch)
        {
            _cepsearch = cepsearch;
        }

        public async Task<bool> IsOnline()
        {
            return await _cepsearch.IsOnline();
        }

        public async Task<Address> GetByZip(string zipCode)
        {
            return await _cepsearch.GetByZip(zipCode);
        }
    }
}

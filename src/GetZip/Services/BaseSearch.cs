using GetZip.Interfaces;
using GetZip.ValueObject;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetZip.Services
{
    public abstract class BaseSearch : ISearch
    {
        #region Properties
        protected abstract string URL { get; }
        protected abstract string Domain { get; }
        #endregion

        #region Methods
        public async Task<bool> IsOnline()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(Domain);
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch
            {
                return false;
            }
        }

        public abstract Task<Address> GetAddress(string zipCode);
        #endregion
    }
}

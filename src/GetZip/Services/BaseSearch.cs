using GetZip.Helpers;
using GetZip.Interfaces;
using GetZip.ValueObject;
using System.Net;
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
        public async Task<bool> IsOnline() => await ResponseHelper.ResultStatusCode(Domain) == HttpStatusCode.OK;

        public abstract Task<Address> GetAddress(string zipCode);
        #endregion
    }
}

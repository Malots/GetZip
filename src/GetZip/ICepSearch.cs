using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetZip
{
    internal interface ICepSearch
    {
        Task<bool> IsOnline();
        Task<Address> GetByZip(string zipCode);
        ICollection<Address> GetByPlace(string uf, string city, string publicPlace, string publicPlaceType = null, string Neighborhood = null);
    }
}
